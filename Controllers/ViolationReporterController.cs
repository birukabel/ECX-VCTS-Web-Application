using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ECX.VCTS.ldap;
using ECX.VCTS.Models;
using ECX.VCTS.Util;
using ECX.VCTS.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace ECX.VCTS.Controllers
{
    public class ViolationReporterController : Controller
    {
        private MySetting MySetting { get; set; }
        private readonly IAuthenticationService _authService;
        ReporterDataAccess dataAccess = new ReporterDataAccess();
        SentBackDataAccess sentDataAccess = new SentBackDataAccess();
        DataAccessUtility da = new DataAccessUtility();
        private readonly IMemoryCache memoryCache;

        public ViolationReporterController(IOptions<MySetting> settings, IAuthenticationService authService, IMemoryCache memory)
        {
            MySetting = settings.Value;
            _authService = authService;
            memoryCache = memory;
        }
        public IActionResult ReportViolation()
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
                    srm[i].ToString() == "isReporter" || 
                    srm[i].ToString() == "isManager" || 
                    srm[i].ToString() == "isOfficer"
                    )
                {
                    try
                    {
                        ViolationReporterViewModel reporter = new ViolationReporterViewModel
                        {
                            othersModel = new OtherViolationAttributesModel(),
                            qualityModel = new QualityViolationAttributesModel(),
                            tradeModel = new TradeViolationAttributesModel(),
                            surveillanceModel = new SurveillanceViolationAttributesModel(),
                            violationCases = new ViolationCaseModel(),
                            QualitySubCategories = UtilityModels.GetSelectListItems(DataAccessUtility.GetAllQualitySubCategories(conString)),
                            TradeTypes = UtilityModels.GetSelectListItems(DataAccessUtility.GetAllTradeTypes(conString)),
                            ViolationTypes = UtilityModels.GetSelectListItems(DataAccessUtility.GetAllViolationTypes(conString)),
                            Warehouses = DataAccessUtility.GetSelectListItems(DataAccessUtility.GetCenterNamesByViolationType(MySetting, "Quality")),
                            Centers = DataAccessUtility.GetSelectListItems(DataAccessUtility.GetCenterNamesByViolationType(MySetting, "some")),
                        };

                        return View(reporter);
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
        public async Task<ActionResult> ReportViolation(ViolationReporterViewModel reporterModel, IFormFile supportingfile)
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
                    srm[i].ToString() == "isReporter" || 
                    srm[i].ToString() == "isManager" || 
                    srm[i].ToString() == "isOfficer"
                    )
                {
                    
                    try
                    {
                        if(supportingfile != null)
                        {
                            var File = supportingfile;
                            var uploads = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Evidences/Reporters");
                            var fileName = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(File.FileName);
                            using (var fileStream = new FileStream(Path.Combine(uploads, fileName), FileMode.Create))
                            {
                                await supportingfile.CopyToAsync(fileStream);
                                reporterModel.violationCases.SupportingDocuments = uploads + "/" + fileName;
                            }
                        }
                        else
                        {
                            reporterModel.violationCases.SupportingDocuments = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Evidences/NoFileUpload") + "/" + "No_File.docx";
                        }
                        
                        dataAccess.ReportViolation(conString, reporterModel, employeeName);
                        return RedirectToAction("SuccessMsg", "ViolationReporter");
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

        public IActionResult SentBackCases()
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
                    srm[i].ToString() == "isReporter" || 
                    srm[i].ToString() == "isManager" || 
                    srm[i].ToString() == "isOfficer"
                    )
                {
                    try
                    {
                        List<SentBackCasesViewModel> SentBackCases = sentDataAccess.GetSentBackCases(conString, employeeName).ToList();
                        return View(SentBackCases);
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

        public IActionResult ReExamineCase(Guid id)
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
                    srm[i].ToString() == "isReporter" ||
                    srm[i].ToString() == "isManager" ||
                    srm[i].ToString() == "isOfficer"
                    )
                {
                    try
                    {
                        List<SentBackCasesViewModel> SentBackCases = sentDataAccess.GetSentBackCases(conString, employeeName).ToList();
                        SentBackCasesViewModel sentModel = new SentBackCasesViewModel();
                        foreach (SentBackCasesViewModel model in SentBackCases)
                        {
                            if (model.qualityModel.QualityViolationsAttributeId == id)
                                sentModel = model;
                        }
                        return View(sentModel);
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
        public async Task<IActionResult> ReExamineCase(SentBackCasesViewModel SentBack, string modifiable, IFormFile file)
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
                    srm[i].ToString() == "isReporter" ||
                    srm[i].ToString() == "isManager" ||
                    srm[i].ToString() == "isOfficer"
                    )
                {
                    if (!ModelState.IsValid)
                    {
                        try
                        {
                            SentBackCasesViewModel model = new SentBackCasesViewModel
                            {
                                qualityModel = SentBack.qualityModel,
                                violationModel = SentBack.violationModel
                            };
                            return View(model);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            return View();
                        }
                    }

                    if (!string.IsNullOrEmpty(modifiable))
                    {
                        try
                        {
                            var File = file;
                            var uploads = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Evidences/Reporters");
                            var fileName = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(File.FileName);
                            using (var fileStream = new FileStream(Path.Combine(uploads, fileName), FileMode.Create))
                            {
                                await file.CopyToAsync(fileStream);
                                SentBack.violationModel.SupportingDocuments = uploads + "/" + fileName;
                            }
                            dataAccess.AddSentBackReport(conString, SentBack);
                            return RedirectToAction("SuccessMsg", "ViolationReporter");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            return View();
                        }
                    }
                    else
                    {
                        try
                        {
                            dataAccess.AddSentBackReport(conString, SentBack);
                            return RedirectToAction("SuccessMsg", "ViolationReporter");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            return View();
                        }
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

        [HttpPost]
        public JsonResult GetCentersByType(string type)
        {
            string conString2 = MySetting.DefaultConnectionstring;
            string conString1 = MySetting.ECXLookupConnectionstring;
            List<string> cenList = new List<string>();
            if (type == "Quality")
            {
                cenList = DataAccessUtility.GetCenterNamesByViolationType(MySetting, "Quality").ToList();
            }
            else
            {
                cenList = DataAccessUtility.GetCenterNamesByViolationType(MySetting, "some").ToList();
            }
            return Json(cenList);
        }

        public JsonResult GetViolators(string term)
        {
            string conStringViols = MySetting.ECXMembershipConnectionstring;
            List<string> emps;
            List<string> viols;
            bool exists = memoryCache.TryGetValue("Violators", out viols);
            if (!exists)
            {
                viols = da.GetViolators(conStringViols).ToList();
                emps = viols.Where(x => x.StartsWith(term, StringComparison.OrdinalIgnoreCase)).Select(y => y).ToList();
                var cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromMinutes(120));
                memoryCache.Set("Violators", viols, cacheEntryOptions);
            }
            else
            {
                emps = viols.Where(x => x.StartsWith(term, StringComparison.OrdinalIgnoreCase)).Select(y => y).ToList();
            }

            return Json(emps);
        }

        public JsonResult GetAllGRNReferences(string term)
        {
            string conStringGRN = MySetting.ECXGRNConnectionstring;
            List<string> grnrefs;
            bool exists = memoryCache.TryGetValue("GRNRefs", out grnrefs);
            if (!exists)
            {
                grnrefs = da.GetAllGRNRefs(conStringGRN).Where(x => x.StartsWith(term, StringComparison.OrdinalIgnoreCase)).Select(y => y).ToList();
            }

            return Json(grnrefs);
        }

        [HttpGet]
        public JsonResult GetAllGRNData(string GRN_Number)
        {
            string conStringGRN = MySetting.ECXGRNConnectionstring;
            QualityViolationAttributesModel quality = new QualityViolationAttributesModel();
            quality = da.GetAllGRNData(conStringGRN, GRN_Number);
            string output = JsonConvert.SerializeObject(quality);

            return Json(quality);
        }

        public ActionResult SuccessMsg()
        {
            //HttpContext.Session.Clear();
            //HttpContext.Session.Remove(HttpContext.Session.Id);
            //Response.Cookies.Delete(HttpContext.Session.Id);
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
                    srm[i].ToString() == "isReporter" ||
                    srm[i].ToString() == "isManager" ||
                    srm[i].ToString() == "isOfficer"
                    )
                {
                    ViewData["Message"] = "Your Report is Successfully Sent!!!";
                    return View();
                }
            }
            return View("ErrorPage", "Home");            
        }

        public ActionResult SuccesModifiedMsg()
        {
            //HttpContext.Session.Clear();
            //HttpContext.Session.Remove(HttpContext.Session.Id);
            //Response.Cookies.Delete(HttpContext.Session.Id);
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
                    srm[i].ToString() == "isReporter" ||
                    srm[i].ToString() == "isManager" ||
                    srm[i].ToString() == "isOfficer"
                    )
                {
                    return View();
                }
            }
            return View("ErrorPage", "Home");
        }

    }
}