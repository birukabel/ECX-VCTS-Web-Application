using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AspNetCore.Reporting;
using AspNetCore.Reporting.ReportExecutionService;
using ECX.VCTS.ldap;
using ECX.VCTS.Models;
using ECX.VCTS.Util;
using ECX.VCTS.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;

namespace ECX.VCTS.Controllers
{
    public class ViolationInvestigatorController : Controller
    {
        private MySetting MySetting { get; set; }
        private readonly IAuthenticationService _authService;
        static RecommendCasesViewModel classRecommend = new RecommendCasesViewModel();
        InvestigatorDataAccess ida = new InvestigatorDataAccess();
        static AvailableQualityCasesViewModel CurrentModel;
        static InvestigatorDecisionsViewModel classDecision = new InvestigatorDecisionsViewModel();
        DataAccessUtility da = new DataAccessUtility();
        private readonly IMemoryCache memoryCache;

        public ViolationInvestigatorController(IOptions<MySetting> settings, IAuthenticationService authService, IMemoryCache cache)
        {
            MySetting = settings.Value;
            _authService = authService;
            memoryCache = cache;
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
                    srm[i].ToString() == "isInvestigator" || 
                    srm[i].ToString() == "isManager" || 
                    srm[i].ToString() == "isOfficer"
                    )
                {
                    try
                    {
                        List<AvailableQualityCasesViewModel> AvailCases = ida.GetAvailCases(conString);
                        return View(AvailCases);
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

        public IActionResult ProcessCase(Guid id)
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
                    srm[i].ToString() == "isInvestigator" || 
                    srm[i].ToString() == "isManager" || 
                    srm[i].ToString() == "isOfficer"
                    )
                {
                    try
                    {
                        List<AvailableQualityCasesViewModel> AvailCases = ida.GetAvailCases(conString);
                        AvailableQualityCasesViewModel model = ida.GetCase(conString, AvailCases, id);
                        CurrentModel = model;
                        return View(model);
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

        [HttpPost]
        public IActionResult ProcessCase(string accept, string consider)
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
                    srm[i].ToString() == "isInvestigator" || 
                    srm[i].ToString() == "isManager" || 
                    srm[i].ToString() == "isOfficer"
                    )
                {
                    try
                    {
                        if (!string.IsNullOrEmpty(accept))
                        {
                            CurrentModel.InvestigatorName = employeeName;
                            ida.AcceptedCase(conString, CurrentModel, "Signed");
                            return View("CaseAccepted", "ViolationInvestigator");
                        }
                        else if (!string.IsNullOrEmpty(consider))
                        {
                            return RedirectToAction("Index", "ViolationInvestigator");
                        }
                        return RedirectToAction("Index", "Home");
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

        public IActionResult CaseAccepted()
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
                    srm[i].ToString() == "isInvestigator" || 
                    srm[i].ToString() == "isManager" || 
                    srm[i].ToString() == "isOfficer"
                    )
                {
                    return View();
                }
            }
            return View("ErrorPage", "Home");
        }

        public IActionResult InvestigatorCases()
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
                    srm[i].ToString() == "isInvestigator" || 
                    srm[i].ToString() == "isManager" || 
                    srm[i].ToString() == "isOfficer"
                    )
                {
                    try
                    {
                        OwnedCasesViewModel model = ida.GetAllOwnedCases(conString, employeeName);
                        return View(model);
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

        public IActionResult RecommendOnCase(Guid id)
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
                    srm[i].ToString() == "isInvestigator" ||
                    srm[i].ToString() == "isManager" ||
                    srm[i].ToString() == "isOfficer"
                    )
                {
                    try
                    {
                        ViolationCaseModel model = da.GetViolationModel(conString, id);
                        RecommendCasesViewModel recommend = new RecommendCasesViewModel();
                        object viewModel = new object();
                        switch (model.ViolationType)
                        {
                            case "Other":
                                recommend.ViolationType = "Other";
                                viewModel = da.GetCaseForView(conString, id, 'o', "[spGetAllOtherCasesAssigned]");
                                recommend.Others = new OthersViewModel();
                                recommend.Others = (OthersViewModel)viewModel;
                                recommend.RecommendId = id;
                                recommend.Others.ViolationModel = model;
                                break;
                            case "Quality":
                                recommend.ViolationType = "Quality";
                                viewModel = da.GetCaseForView(conString, id, 'q', "[spGetAllQualityCasesAssigned]");
                                recommend.Quality = new QualityViewModel();
                                recommend.Quality = (QualityViewModel)viewModel;
                                recommend.RecommendId = id;
                                recommend.Quality.ViolationModel = model;
                                break;
                            case "Surveillance":
                                recommend.ViolationType = "Surveillance";
                                viewModel = da.GetCaseForView(conString, id, 's', "[spGetAllSurveillanceCasesAssigned]");
                                recommend.Surveillance = new SurveillanceViewModel();
                                recommend.Surveillance = (SurveillanceViewModel)viewModel;
                                recommend.RecommendId = id;
                                recommend.Surveillance.ViolationModel = model;
                                break;
                            case "Trade":
                                recommend.ViolationType = "Trade";
                                viewModel = da.GetCaseForView(conString, id, 't', "[spGetAllTradeCasesAssigned]");
                                recommend.Trade = new TradeViewModel();
                                recommend.Trade = (TradeViewModel)viewModel;
                                recommend.RecommendId = id;
                                recommend.Trade.ViolationModel = model;
                                break;
                        }
                        classRecommend = recommend;
                        return View(recommend);
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

        [HttpPost]
        public async Task<IActionResult> RecommendOnCases(string recommendarea,
            string recommendbtn, string downloadbtn, string supDoc)
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
            RecommendCasesViewModel recommend = new RecommendCasesViewModel();
            //classRecommend.InvestigatorSummary = recommendarea;

            for (int i = 0; srm.Count > i; i++)
            {
                if (
                    srm[i].ToString() == "isInvestigator" ||
                    srm[i].ToString() == "isManager" ||
                    srm[i].ToString() == "isOfficer"
                    )
                {
                    try
                    {
                        if (!string.IsNullOrEmpty(recommendbtn))
                        {
                            da.AddToHistoryHelper(conString, "Under Investigation", classRecommend.RecommendId);
                            classRecommend.InvestigatorSummary = recommendarea;
                            string sp = "spUpdateInvestigatorSummaryRecommend";
                            ida.UpdateInvestigatorSummary(conString, classRecommend, sp);
                            return View("RecommendationSuccess", "ViolationInvestigator");
                        }
                        if (!string.IsNullOrEmpty(downloadbtn))
                        {
                            var memory = new MemoryStream();
                            //var path = classRecommend.Others.ViolationModel.SupportingDocuments;
                            var path = supDoc;
                            using (var stream = new FileStream(path, FileMode.Open))
                            {
                                await stream.CopyToAsync(memory);
                            }
                            memory.Position = 0;
                            return File(memory, DataAccessUtility.GetContentType(path), Path.GetFileName(path));

                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        return View();
                    }
                    return View("Index", "ViolationInvestigator");
                }
            }
            return View("ErrorPage", "Home");
        }

        public IActionResult DecideOnCase(Guid id)
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
                    srm[i].ToString() == "isInvestigator" ||
                    srm[i].ToString() == "isManager" ||
                    srm[i].ToString() == "isOfficer"
                    )
                {
                    try
                    {
                        InvestigatorDecisionsViewModel decision = new InvestigatorDecisionsViewModel();
                        ViolationCaseModel model = da.GetViolationModel(conString, id);
                        object viewModel = new object();
                        switch (model.ViolationType)
                        {
                            case "Other":
                                decision.ViolationType = "Other";
                                viewModel = da.GetCaseForView(conString, id, 'o', "[spGetAllOtherCasesAssigned]");
                                decision.Others = new OthersViewModel();
                                decision.Others = (OthersViewModel)viewModel;
                                decision.Others.ViolationModel = model;
                                decision.DecisionId = decision.Others.ViolationModel.ViolationCaseId;
                                break;
                            case "Quality":
                                decision.ViolationType = "Quality";
                                viewModel = da.GetCaseForView(conString, id, 'q', "[spGetAllQualityCasesAssigned]");
                                decision.Quality = new QualityViewModel();
                                decision.Quality = (QualityViewModel)viewModel;
                                decision.Quality.ViolationModel = model;
                                decision.DecisionId = decision.Quality.ViolationModel.ViolationCaseId;
                                break;
                            case "Surveillance":
                                decision.ViolationType = "Surveillance";
                                viewModel = da.GetCaseForView(conString, id, 's', "[spGetAllSurveillanceCasesAssigned]");
                                decision.Surveillance = new SurveillanceViewModel();
                                decision.Surveillance = (SurveillanceViewModel)viewModel;
                                decision.Surveillance.ViolationModel = model;
                                decision.DecisionId = decision.Surveillance.ViolationModel.ViolationCaseId;
                                break;
                            case "Trade":
                                decision.ViolationType = "Trade";
                                viewModel = da.GetCaseForView(conString, id, 't', "[spGetAllTradeCasesAssigned]");
                                decision.Trade = new TradeViewModel();
                                decision.Trade = (TradeViewModel)viewModel;
                                decision.Trade.ViolationModel = model;
                                decision.DecisionId = decision.Trade.ViolationModel.ViolationCaseId;
                                break;
                        }
                        decision.ReportDate = model.ReportDate;
                        classDecision = decision;
                        return View(decision);
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

        [HttpPost]
        public async Task<IActionResult> DecideOnCase([Bind]InvestigatorDecisionsViewModel model, 
            string down, string sent, string decisionarea, string drop, IFormFile file)
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
                    srm[i].ToString() == "isInvestigator" ||
                    srm[i].ToString() == "isManager" ||
                    srm[i].ToString() == "isOfficer"
                    )
                {
                    try
                    {
                        var gile = file;//DecisionEvidence;
                        var uploads = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Evidences/Investigators");
                        string fileName = "";
                        string invDoc = null;

                        if(file != null)
                        {
                            fileName = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(gile.FileName);
                            invDoc = uploads + "/" + fileName;
                            using (var fileStream = new FileStream(Path.Combine(uploads, fileName), FileMode.Create))
                            {
                                await file.CopyToAsync(fileStream);
                            }
                        }
                        //var invSum = decisionarea;


                        da.AddToHistoryHelper(conString, "Preparing Charge", classDecision.DecisionId);
                        if (!string.IsNullOrEmpty(sent))
                        {
                            string sp = "spInvestigatorDecisionSent";
                            ida.SendInvestigatorDecision(conString, classDecision.DecisionId, sp, decisionarea, invDoc);
                            return View("DecisionSentSuccess", "ViolationInvestigator");
                        }

                        if (!string.IsNullOrEmpty(drop))
                        {
                            string sp = "spInvestigatorDecisionDrop";
                            ida.SendInvestigatorDecision(conString, classDecision.DecisionId, sp, decisionarea, invDoc);
                            return View("DecisionSentSuccess", "ViolationInvestigator");
                        }

                        if (!string.IsNullOrEmpty(down))
                        {
                            classDecision.InvestigatorDecisionSummary = decisionarea;
                            var data = classDecision;
                            var _reportPath = "";
                            LocalReport localReport = null;
                            System.Data.DataTable dt = new System.Data.DataTable();
                            var reportParams = new Dictionary<string, string>();
                            int extension = 1;

                            if(data.ViolationType == "Other")
                            {
                                _reportPath = @"wwwroot\Evidences\Reports\InvestigatorOther.rdlc";
                                localReport = new LocalReport(_reportPath);

                                reportParams.Add("ExchangeCenterName", data.Others.ViolationModel.ExchangeCenterName);
                                reportParams.Add("ViolatorName", data.Others.ViolationModel.ViolatorName);
                                reportParams.Add("ViolationSummary", data.Others.ViolationModel.ViolationSummary);
                                reportParams.Add("ViolationDate", data.Others.OthersModel.ViolationDate.ToString());
                                reportParams.Add("FurtherComment", data.InvestigatorDecisionSummary);
                                reportParams.Add("Witnesses", data.Others.OthersModel.Witnesses);
                                reportParams.Add("ViolationType", data.ViolationType);
                                reportParams.Add("ReportDate", data.ReportDate);

                            }
                            else if(data.ViolationType == "Quality")
                            {
                                _reportPath = @"wwwroot\Evidences\Reports\InvestigatorQuality.rdlc";
                                localReport = new LocalReport(_reportPath);

                                reportParams.Add("ExchangeCenterName", data.Quality.ViolationModel.ExchangeCenterName);
                                reportParams.Add("ViolatorName", data.Quality.ViolationModel.ViolatorName);
                                reportParams.Add("ViolationSummary", data.Quality.ViolationModel.ViolationSummary);
                                reportParams.Add("ArrivalDate", data.Quality.QualityModel.ArrivalDate.ToString());
                                reportParams.Add("FurtherComment", data.InvestigatorDecisionSummary);
                                reportParams.Add("ViolationType", data.ViolationType);
                                reportParams.Add("ReportDate", data.ReportDate);
                                reportParams.Add("DriverName", data.Quality.QualityModel.DriverName);
                                reportParams.Add("DispatchNumber", data.Quality.QualityModel.DispatchNumber);
                                reportParams.Add("GRNReference", data.Quality.QualityModel.GRNReference);
                                reportParams.Add("LaboratoryDecision", data.Quality.QualityModel.LaboratoryDecision);
                                reportParams.Add("LabResultComment", data.Quality.QualityModel.LabResultComment);
                                reportParams.Add("MemRepName", data.Quality.QualityModel.MemberRepresentativeName);
                                reportParams.Add("NumberofBags", data.Quality.QualityModel.NumberofAdultratedBags.ToString());
                                reportParams.Add("SamplingInspectorComment", data.Quality.QualityModel.SamplingInspectorName);
                                reportParams.Add("SamplerName", data.Quality.QualityModel.SamplerName);
                                reportParams.Add("QualityGradeResult", data.Quality.QualityModel.QualityGradeResult);
                                reportParams.Add("QualitySubCategory", data.Quality.QualityModel.QualitySubCategory);

                            }
                            else if(data.ViolationType == "Trade")
                            {
                                _reportPath = @"wwwroot\Evidences\Reports\InvestigatorTrade.rdlc";
                                localReport = new LocalReport(_reportPath);

                                reportParams.Add("ExchangeCenterName", data.Trade.ViolationModel.ExchangeCenterName);
                                reportParams.Add("ViolatorName", data.Trade.ViolationModel.ViolatorName);
                                reportParams.Add("ViolationSummary", data.Trade.ViolationModel.ViolationSummary);
                                reportParams.Add("ViolationDate", data.Trade.TradeModel.ViolationDate.ToString());
                                reportParams.Add("FurtherComment", data.InvestigatorDecisionSummary);
                                reportParams.Add("ViolationType", data.ViolationType);
                                reportParams.Add("ReportDate", data.ReportDate);
                                reportParams.Add("BuyClientName", data.Trade.TradeModel.BuyClientName);
                                reportParams.Add("BuyMemberrName", data.Trade.TradeModel.BuyMemberName);
                                reportParams.Add("BuyRepName", data.Trade.TradeModel.BuyRepresentativeName);
                                reportParams.Add("SellRepName", data.Trade.TradeModel.SellRepresentativeName);
                                reportParams.Add("BuyTicketNumber", data.Trade.TradeModel.BuyTicketNumber);
                                reportParams.Add("SellTicketNumber", data.Trade.TradeModel.SellTicketNumber);
                                reportParams.Add("TradePrice", data.Trade.TradeModel.TradePrice.ToString());
                                reportParams.Add("TradeType", data.Trade.TradeModel.TradeType);
                                //reportParams.Add("BuyClientName", data.Trade.TradeModel.Symbol);
                                //reportParams.Add("BuyMemberrName", data.Trade.TradeModel.BuyMemberName);

                            }
                            else if(data.ViolationType == "Surveillance")
                            {
                                _reportPath = @"wwwroot\Evidences\Reports\InvestigatorSurv.rdlc"; ;
                                localReport = new LocalReport(_reportPath);

                                reportParams.Add("ExchangeCenterName", data.Surveillance.ViolationModel.ExchangeCenterName);
                                reportParams.Add("ViolatorName", data.Surveillance.ViolationModel.ViolatorName);
                                reportParams.Add("ViolationSummary", data.Surveillance.ViolationModel.ViolationSummary);
                                reportParams.Add("ViolationDate", data.Surveillance.SurveillanceModel.ViolationDate.ToString());
                                reportParams.Add("FurtherComment", data.InvestigatorDecisionSummary);
                                reportParams.Add("Witnesses", data.Surveillance.SurveillanceModel.Witnesses);
                                reportParams.Add("ViolationType", data.ViolationType);
                                reportParams.Add("ReportDate", data.ReportDate);
                                reportParams.Add("TypeofAlert", data.Surveillance.SurveillanceModel.TypeOfAlert);
                                reportParams.Add("FurtherExplanation", data.Surveillance.SurveillanceModel.FurtherExplanation);
                                reportParams.Add("SellMemberName", data.Surveillance.SurveillanceModel.SellMemberName);
                                reportParams.Add("BuyMemberName", data.Surveillance.SurveillanceModel.BuyMemberName);
                            }

                            if (reportParams != null && reportParams.Count > 0)
                            {
                                List<ReportParameter> reportparameter = new List<ReportParameter>();
                                foreach (var record in reportParams)
                                {
                                    reportparameter.Add(new ReportParameter());
                                }
                            }
                            var result = localReport.Execute(RenderType.WordOpenXml, extension, parameters: reportParams);
                            byte[] file1 = result.MainStream;

                            Stream stream = new MemoryStream(file1);

                            return File(stream, "application/doc", "Report.docx");


                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        return View();
                    }

                    return RedirectToAction("InvestigatorCases");
                }
            }
            return View("ErrorPage", "Home");
        }

        //[HttpPost]
        //public async Task<IActionResult> DownloadDocument()

        public IActionResult RecommendationSuccess()
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
                    srm[i].ToString() == "isInvestigator" ||
                    srm[i].ToString() == "isManager" ||
                    srm[i].ToString() == "isOfficer"
                    )
                {
                    return View();
                }
            }
            return View("ErrorPage", "Home");
        }

        public IActionResult DecisionSentSuccess()
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
                    srm[i].ToString() == "isInvestigator" ||
                    srm[i].ToString() == "isManager" ||
                    srm[i].ToString() == "isOfficer"
                    )
                {
                    return View();
                }
            }
            return View("ErrorPage", "Home");
        }

        public IActionResult DecisionDropSuccess()
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
                    srm[i].ToString() == "isInvestigator" ||
                    srm[i].ToString() == "isManager" ||
                    srm[i].ToString() == "isOfficer"
                    )
                {
                    return View();
                }
            }
            return View("ErrorPage", "Home");
        }

        public JsonResult GetInvestigators(string term)
        {
            List<string> emps;
            string conStringViols = MySetting.ECXMembershipConnectionstring;
            bool exists = memoryCache.TryGetValue("Investigators", out emps);
            if (!exists)
            {
                emps = da.GetAllInvestigators(conStringViols).Where(x => x.StartsWith(term, StringComparison.OrdinalIgnoreCase)).Select(y => y).ToList();
                var cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromMinutes(120));
                memoryCache.Set("Investigators", emps, cacheEntryOptions);
            }

            return Json(emps);
        }
    }
}