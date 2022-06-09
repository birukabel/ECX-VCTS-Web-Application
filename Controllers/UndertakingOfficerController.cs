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
using Microsoft.Extensions.Options;

namespace ECX.VCTS.Controllers
{
    public class UndertakingOfficerController : Controller
    {
        private MySetting MySetting { get; set; }
        private readonly IAuthenticationService _authService;
        UndertakingDataAccess uda = new UndertakingDataAccess();
        DataAccessUtility da = new DataAccessUtility();
        private static Guid vioId;
        private static Guid quaId;
        public UndertakingOfficerController(IOptions<MySetting> settings, IAuthenticationService authService)
        {
            MySetting = settings.Value;
            _authService = authService;
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
                    srm[i].ToString() == "isUndertaker" || 
                    srm[i].ToString() == "isManager" || 
                    srm[i].ToString() == "isOfficer"
                    )
                {
                    try
                    {
                        List<UndertakingOfficerViewModel> undertakingOfficer = uda.GetAllCasesforUndertaking(conString).ToList();

                        return View(undertakingOfficer);
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

        [HttpGet]
        public IActionResult ReviewCase(Guid id)
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
                    srm[i].ToString() == "isUndertaker" || 
                    srm[i].ToString() == "isManager" || 
                    srm[i].ToString() == "isOfficer"
                    )
                {
                    try
                    {
                        UndertakingOfficerModel officer = new UndertakingOfficerModel();
                        UndertakingOfficerViewModel officerModel = uda.GetCaseforUndertaking(conString, id);
                        vioId = officerModel.violationModel.ViolationCaseId;
                        quaId = officerModel.qualityModel.QualityViolationsAttributeId;
                        officerModel.officerModel = officer;
                        return View(officerModel);
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
        public async Task<IActionResult> ReviewCase([Bind]UndertakingOfficerViewModel sentModel, string send, 
            string sign, string unsign, string down, IFormFile UploadedDocument)
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
                    srm[i].ToString() == "isUndertaker" || 
                    srm[i].ToString() == "isManager" || 
                    srm[i].ToString() == "isOfficer"
                    )
                {
                    if (!string.IsNullOrEmpty(down))
                    {
                        try
                        {
                            var memory = new MemoryStream();
                            //var path = classRecommend.Others.ViolationModel.SupportingDocuments;
                            var path = sentModel.violationModel.SupportingDocuments;
                            using (var stream = new FileStream(path, FileMode.Open))
                            {
                                await stream.CopyToAsync(memory);
                            }
                            memory.Position = 0;
                            return File(memory, DataAccessUtility.GetContentType(path), Path.GetFileName(path));
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            return View();
                        } 
                    }
                    try
                    {
                        var File = UploadedDocument;
                        var uploads = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Evidences/Undertakings");
                        var fileName = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(File.FileName);
                        using (var fileStream = new FileStream(Path.Combine(uploads, fileName), FileMode.Create))
                        {
                            await UploadedDocument.CopyToAsync(fileStream);
                            sentModel.officerModel.SignedDocument = uploads + "/" + fileName;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        return View();
                    }
                    da.AddToHistoryHelper(conString, "Waiting", vioId);

                    if (!string.IsNullOrEmpty(send))
                    {

                        try
                        {
                            uda.AddUndertakingOfficerRemark(conString, quaId, sentModel.qualityModel.UndertakingOfficerRemark);
                            da.UpdateCaseStatus(conString, vioId, "Sent Back");

                            return View("SentDoc", "UndertakingOfficer");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            return View();
                        }
                    }
                    if (!string.IsNullOrEmpty(sign))
                    {
                        try
                        {
                            UndertakingOfficerModel model = new UndertakingOfficerModel();
                            model.PreparedBy = sentModel.officerModel.PreparedBy;
                            model.QualityViolationsAttributeId = quaId;
                            model.SignedDate = sentModel.officerModel.SignedDate;
                            model.SignedDocument = sentModel.officerModel.SignedDocument;
                            model.UploadDate = DateTime.Now.ToString();
                            model.IsSigned = true;
                            uda.UpdateUndertaking(conString, model);
                            da.UpdateCaseStatus(conString, vioId, "Signed");
                            return View("SignedDoc", "UndertakingOfficer");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            return View();
                        }
                    }
                    if (!string.IsNullOrEmpty(unsign))
                    {
                        try
                        {
                            UndertakingOfficerModel model = new UndertakingOfficerModel();
                            model.PreparedBy = sentModel.officerModel.PreparedBy;
                            model.QualityViolationsAttributeId = quaId;
                            model.SignedDate = DateTime.Now.ToString();
                            model.SignedDocument = sentModel.officerModel.SignedDocument;
                            model.UploadDate = DateTime.Now.ToString();
                            model.IsSigned = false;
                            uda.UpdateUndertaking(conString, model);
                            da.UpdateCaseStatus(conString, vioId, "Signed");
                            return View("UnSignedDoc", "UndertakingOfficer");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            return View();
                        }
                    }
                    return RedirectToAction("Index", "Home");
                }
            }
            return View("ErrorPage", "Home");
        }

        public IActionResult SentDoc()
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
                    srm[i].ToString() == "isUndertaker" || 
                    srm[i].ToString() == "isManager" || 
                    srm[i].ToString() == "isOfficer"
                    )
                {
                    return View();
                }
            }
            return View("ErrorPage", "Home");
        }

        public IActionResult SignedDoc()
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
                    srm[i].ToString() == "isUndertaker" || 
                    srm[i].ToString() == "isManager" || 
                    srm[i].ToString() == "isOfficer"
                    )
                {
                    return View();
                }
            }
            return View("ErrorPage", "Home");
        }

        public IActionResult UnSignedDoc()
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
                    srm[i].ToString() == "isUndertaker" || 
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