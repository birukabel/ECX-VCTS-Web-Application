using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AspNetCore.Reporting;
using AspNetCore.Reporting.ReportExecutionService;
using ECX.VCTS.ldap;
using ECX.VCTS.Models;
using ECX.VCTS.Util;
using ECX.VCTS.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using OfficeOpenXml;

namespace ECX.VCTS.Controllers
{
    public class VCTSReportsController : Controller
    {
        private MySetting MySetting { get; set; }
        private readonly IAuthenticationService _authService;
        VCTSReportsDataAccess vda = new VCTSReportsDataAccess();
        static VCTSReportsViewModel classReport = new VCTSReportsViewModel();
        DataAccessUtility da = new DataAccessUtility();
        private readonly IMemoryCache memoryCache;
        public VCTSReportsController(IOptions<MySetting> settings, IAuthenticationService authService, IMemoryCache memoryCache)
        {
            MySetting = settings.Value;
            _authService = authService;
            this.memoryCache = memoryCache;
        }
        public IActionResult Index()
        {
            HttpContext.Session.Clear();
            HttpContext.Session.Remove(HttpContext.Session.Id);
            Response.Cookies.Delete(HttpContext.Session.Id);
            //--- Code for getting the properties of the logged in user from AD 
            var directoryentriy = _authService.getUserdetail(User.Identity.Name);
            var employeeName = directoryentriy.Properties["CN"][0].ToString();
            var employeeId = _authService.loadList(employeeName);


            //--- Code for getting setting of application
            string conString = MySetting.DefaultConnectionstring;
            string endpoint = MySetting.Url;

            //--- Code for getting the user permission from web service
            SecurityController sc = new SecurityController();
            List<SecurityRights> srm = new List<SecurityRights>();
            srm = sc.GetUserRights(employeeId.ToString(), endpoint);
            //string con = MySetting.DefaultConnectionstring;

            for (int i = 0; srm.Count > i; i++)
            {
                if (
                    srm[i].ToString() == "isManager" || 
                    srm[i].ToString() == "isOfficer"
                    )
                {
                    try
                    {
                        VCTSReportsViewModel report = new VCTSReportsViewModel
                        {
                            OthersModel = new List<OthersViewModel>(),
                            QualityModel = new List<QualityViewModel>(),
                            SurveillanceModel = new List<SurveillanceViewModel>(),
                            TradeModel = new List<TradeViewModel>(),
                            PenaltyTypes = DataAccessUtility.GetSelectListItems(DataAccessUtility.GetAllPenaltyTypes(conString)),
                            Warehouses = DataAccessUtility.GetSelectListItems(DataAccessUtility.GetCenterNamesByViolationType(MySetting, "Quality")),
                            Centers = DataAccessUtility.GetSelectListItems(DataAccessUtility.GetCenterNamesByViolationType(MySetting, "some")),
                            StatusTypes = DataAccessUtility.GetSelectListItems(DataAccessUtility.GetAllCaseStatus(conString)),
                            ViolationTypes = DataAccessUtility.GetSelectListItems(DataAccessUtility.GetAllViolationTypes(conString))
                        };

                        List<object> otherObjects = vda.GetAllCasesForReporting(conString, 'o', "spGetAllOtherCasesComplete");
                        List<object> qualityObjects = vda.GetAllCasesForReporting(conString, 'q', "spGetAllQualityCasesComplete");
                        List<object> survObjects = vda.GetAllCasesForReporting(conString, 's', "spGetAllSurveillanceCasesComplete");
                        List<object> tradeObjects = vda.GetAllCasesForReporting(conString, 't', "spGetAllTradeCasesComplete");

                        foreach (OthersViewModel other in otherObjects)
                            report.OthersModel.Add(other);
                        foreach (QualityViewModel quality in qualityObjects)
                            report.QualityModel.Add(quality);
                        foreach (SurveillanceViewModel surv in survObjects)
                            report.SurveillanceModel.Add(surv);
                        foreach (TradeViewModel trade in tradeObjects)
                            report.TradeModel.Add(trade);
                        classReport = report;
                        return View(report);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        return View();
                    }
                }
            }
            return View("ErrorPage", "Home");
        }


        public IActionResult DecidedCases()
        {
            HttpContext.Session.Clear();
            HttpContext.Session.Remove(HttpContext.Session.Id);
            Response.Cookies.Delete(HttpContext.Session.Id);
            //--- Code for getting the properties of the logged in user from AD 
            var directoryentriy = _authService.getUserdetail(User.Identity.Name);
            var employeeName = directoryentriy.Properties["CN"][0].ToString();
            var employeeId = _authService.loadList(employeeName);


            //--- Code for getting setting of application
            string conString = MySetting.DefaultConnectionstring;
            string endpoint = MySetting.Url;

            //--- Code for getting the user permission from web service
            SecurityController sc = new SecurityController();
            List<SecurityRights> srm = new List<SecurityRights>();
            srm = sc.GetUserRights(employeeId.ToString(), endpoint);
            for (int i = 0; srm.Count > i; i++)
            {
                if (srm[i].ToString() == "isManager" ||
                    srm[i].ToString() == "isOfficer" ||
                    srm[i].ToString() == "isSecretary" ||
                    srm[i].ToString() == "isInvestigator" ||
                    srm[i].ToString() == "isUndertaker"
                    )
                {
                    try
                    {
                        string sp = "spAnnualEnforcementList";
                        List<AnnualEnforcementStatusViewModel> EnforcementList = new List<AnnualEnforcementStatusViewModel>();
                        EnforcementList = vda.GetAllCasesforEnforcement(conString, sp);

                        int extension = 1;
                        var _reportPath = @"wwwroot\Evidences\Reports\AnnualEnforce.rdlc";

                        LocalReport localReport = new LocalReport(_reportPath);
                        System.Data.DataTable dt = new System.Data.DataTable();
                        dt.Clear();

                        //List<AnnualEnforcementStatusViewModel> EnforcementList = new List<AnnualEnforcementStatusViewModel>();
                        using (SqlConnection connection = new SqlConnection(conString))
                        {
                            SqlCommand command = new SqlCommand(sp, connection);
                            command.CommandType = CommandType.StoredProcedure;
                            connection.Open();
                            SqlDataReader reader = command.ExecuteReader();

                            dt.Columns.Add("ViolatorName", typeof(string));
                            dt.Columns.Add("ViolationDate", typeof(string));
                            dt.Columns.Add("ViolationType", typeof(string));
                            dt.Columns.Add("DecisionSummary", typeof(string));
                            dt.Columns.Add("DecisionPassedDate", typeof(string));
                            dt.Columns.Add("EnforcementStatus", typeof(string));

                            while (reader.Read())
                            {
                                AnnualEnforcementStatusViewModel model = new AnnualEnforcementStatusViewModel
                                {
                                    DateOfViolation = reader["ReportDate"].ToString(),
                                    DecisionPassedDate = reader["DecisionPassedDate"].ToString(),
                                    DecisionSummary = reader["BCCSummary"].ToString(),
                                    EnforcementStatus = reader["Enforcement"].ToString(),
                                    ViolationType = reader["ViolationType"].ToString(),
                                    ViolatorName = reader["ViolatorName"].ToString(),
                                    ViolationCaseId = (Guid)reader["ViolationCaseId"]
                                };
                                dt.Rows.Add(model.ViolatorName, model.DateOfViolation, model.ViolationType,
                                    model.DecisionSummary, model.DecisionPassedDate, model.EnforcementStatus);
                            }
                            connection.Close();
                        }

                        localReport.AddDataSource("DataSet1", dt);

                        var reportParams = new Dictionary<string, string>();
                        if (reportParams != null && reportParams.Count > 0)
                        {
                            List<ReportParameter> reportparameter = new List<ReportParameter>();
                            foreach (var record in reportParams)
                            {
                                reportparameter.Add(new ReportParameter());
                            }
                        }

                        var result = localReport.Execute(RenderType.Excel, extension, parameters: reportParams);
                        byte[] file = result.MainStream;

                        Stream stream = new MemoryStream(file);
                        string excelName = $"Report-{DateTime.Now.ToString("yyyy-MM-dd-HH:mm:ssfff")}.xls";

                        return File(stream, "application/doc", excelName);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        return View();
                    }
                    //return File(stream, "application/doc", f + c.ToString() + "_Report.xls");
                }
            }
            return View("ErrorPage", "Home");
        }

        [HttpGet]
        public IActionResult GetData([Bind]VCTSReportsViewModel report)
        {
            HttpContext.Session.Clear();
            HttpContext.Session.Remove(HttpContext.Session.Id);
            Response.Cookies.Delete(HttpContext.Session.Id);
            //--- Code for getting the properties of the logged in user from AD 
            var directoryentriy = _authService.getUserdetail(User.Identity.Name);
            var employeeName = directoryentriy.Properties["CN"][0].ToString();
            var employeeId = _authService.loadList(employeeName);


            //--- Code for getting setting of application
            string conString = MySetting.DefaultConnectionstring;            
            string endpoint = MySetting.Url;

            //--- Code for getting the user permission from web service
            SecurityController sc = new SecurityController();
            List<SecurityRights> srm = new List<SecurityRights>();
            srm = sc.GetUserRights(employeeId.ToString(), endpoint);
            //string con = MySetting.DefaultConnectionstring;

            for (int i = 0; srm.Count > i; i++)
            {
                if (
                    srm[i].ToString() == "isManager" || 
                    srm[i].ToString() == "isOfficer"
                    )
                {
                    try
                    {
                        VCTSReportsViewModel vctsReports = new VCTSReportsViewModel
                        {
                            OthersModel = new List<OthersViewModel>(),
                            QualityModel = new List<QualityViewModel>(),
                            SurveillanceModel = new List<SurveillanceViewModel>(),
                            TradeModel = new List<TradeViewModel>()
                        };
                        List<object> otherObject = vda.GetDataforReporting(conString, 'o', "spOtherCasesGenericReporting", report);
                        List<object> qualityObject = vda.GetDataforReporting(conString, 'q', "spQualityCasesGenericReporting", report);
                        List<object> survObject = vda.GetDataforReporting(conString, 's', "spSurveillanceCasesGenericReporting", report);
                        List<object> tradeObject = vda.GetDataforReporting(conString, 't', "spTradeCasesGenericReporting", report);
                        DataTable dt = new DataTable();
                        dt.Clear();
                        if (report.ViolationType == "Other")
                        {
                            foreach (OthersViewModel other in otherObject)
                                vctsReports.OthersModel.Add(other);
                            dt = vda.AddOtherCasesColumns(vctsReports.OthersModel);
                        }
                        else if (report.ViolationType == "Quality")
                        {
                            foreach (QualityViewModel quality in qualityObject)
                                vctsReports.QualityModel.Add(quality);
                            dt = vda.AddQualityCasesColumns(vctsReports.QualityModel);
                        }
                        else if (report.ViolationType == "Surveillance")
                        {
                            foreach (SurveillanceViewModel surv in survObject)
                                vctsReports.SurveillanceModel.Add(surv);
                            dt = vda.AddSurveillanceCasesColumns(vctsReports.SurveillanceModel);
                        }
                        else if (report.ViolationType == "Trade")
                        {
                            foreach (TradeViewModel trade in tradeObject)
                                vctsReports.TradeModel.Add(trade);
                            dt = vda.AddTradeCasesColumns(vctsReports.TradeModel);
                        }

                        var stream = new MemoryStream();
                        using (var package = new ExcelPackage(stream))
                        {
                            var workSheet = package.Workbook.Worksheets.Add("Sheet1");
                            workSheet.Cells.LoadFromDataTable(dt, true);
                            package.Save();
                        }

                        stream.Position = 0;
                        string excelName = $"ViolationCases-{DateTime.Now.ToString("yyyy-MM-dd-HH:mm:ssfff")}.xlsx";

                        return File(stream, "application/doc", excelName);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        return View();
                    }
                }
            }
            return View("ErrorPage", "Home");
        }

        public JsonResult GetInvestigators(string term)
        {
            string conString = MySetting.DefaultConnectionstring;
            List<string> emps;
            bool exists = memoryCache.TryGetValue("Investigators", out emps);
            if (!exists)
            {
                emps = da.GetAllInvestigators(conString).Where(x => x.StartsWith(term, StringComparison.OrdinalIgnoreCase)).Select(y => y).ToList();
                var cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromMinutes(120));
                memoryCache.Set("Investigators", emps, cacheEntryOptions);
            }

            return Json(emps);
        }

        public JsonResult GetViolators(string term)
        {
            string conStringViols = MySetting.ECXMembershipConnectionstring;
            List<string> emps;
            bool exists = memoryCache.TryGetValue("Violators", out emps);
            if (!exists)
            {
                emps = da.GetViolators(conStringViols).Where(x => x.StartsWith(term, StringComparison.OrdinalIgnoreCase)).Select(y => y).ToList();
                var cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromMinutes(120));
                memoryCache.Set("Violators", emps, cacheEntryOptions);
            }

            return Json(emps);
        }
       
    }
}