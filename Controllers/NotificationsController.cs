using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECX.VCTS.ldap;
using ECX.VCTS.Models;
using ECX.VCTS.Util;
using ECX.VCTS.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;

namespace ECX.VCTS.Controllers
{
    public class NotificationsController : Controller
    {
        private MySetting MySetting { get; set; }
        private readonly IAuthenticationService _authService;
        NotificationsDataAccess nda = new NotificationsDataAccess();
        DataAccessUtility da = new DataAccessUtility();
        private readonly IMemoryCache memoryCache;

        public NotificationsController(IOptions<MySetting> settings, IAuthenticationService authService, IMemoryCache memoryCache)
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
            string con = MySetting.DefaultConnectionstring;

            for (int i = 0; srm.Count > i; i++)
            {
                if (
                    srm[i].ToString() == "isManager" || 
                    srm[i].ToString() == "isOfficer" 
                    )
                {
                    try
                    {
                        NotificationsViewModel notifications = new NotificationsViewModel
                        {
                            OverdueCasesList = nda.GetCasesListForNotification(conString, "spGetOverdueCases").ToList(),
                            PenalizedCasesList = nda.GetCasesListForNotification(conString, "spGetPenalizedList").ToList(),
                            OverduePenalizedCasesList = nda.GetCasesListForNotification(conString, "spGetOverduePenalties").ToList(),
                            ExtendedCasesList = nda.GetCasesListForNotification(conString, "spGetExtendedOverdueCase").ToList(),
                            PenalizedFirstNoticeList = nda.GetCasesListForNotification(conString, "spGetAllCasesWithFirstNotice").ToList(),
                            PenalizedSecondNoticeList = nda.GetCasesListForNotification(conString, "spGetAllCasesWithSecondNotice").ToList(),
                            SuspensionsToLiftCasesList = nda.GetCasesListForNotification(conString, "spGetAllSuspensionsToLift").ToList()
                        };
                        notifications.OverdueCaseCount = notifications.OverdueCasesList.Count();
                        notifications.PenalizedCasesCount = notifications.PenalizedCasesList.Count();
                        notifications.OverduePenaltyCount = notifications.OverduePenalizedCasesList.Count();
                        notifications.ExtendedCasesCount = notifications.ExtendedCasesList.Count();
                        notifications.FirstNoticeCount = notifications.PenalizedFirstNoticeList.Count();
                        notifications.SecondNoticeCount = notifications.PenalizedSecondNoticeList.Count();
                        notifications.SuspensionsToLiftCount = notifications.SuspensionsToLiftCasesList.Count();
                        return View(notifications);
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
        public IActionResult OverdueCases()
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
                if (
                    srm[i].ToString() == "isManager" || 
                    srm[i].ToString() == "isOfficer"
                    )
                {
                    try
                    {
                        List<ViolationCaseModel> overdueCases = nda.GetCasesListForNotification(conString, "spGetOverdueCases").ToList();
                        return View(overdueCases);
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
        public IActionResult ExtendOverdueCase(Guid id)
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
                try
                {
                    if (
                        srm[i].ToString() == "isManager" || 
                        srm[i].ToString() == "isOfficer"
                        )
                    {
                        nda.ExtendOverdueViolationCase(conString, id);
                        return RedirectToAction("SuccessOverdueCaseExtension", "Notifications");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return View();
                }
            }
            return View("ErrorPage", "Home");

        }

        [HttpGet("/Notifications/ReassignExtendCase/{id}")]
        public IActionResult ReassignExtendedCase(Guid id)
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
                if (
                    srm[i].ToString() == "isManager" || 
                    srm[i].ToString() == "isOfficer"
                    )
                {
                    try
                    {
                        ViolationCaseModel model = da.GetViolation(conString, id);
                        NotificationsViewModel notify = new NotificationsViewModel
                        {
                            ExchangeCenterName = model.ExchangeCenterName,
                            ViolationSummary = model.ViolationSummary,
                            ViolationCaseId = model.ViolationCaseId,
                            ViolationType = model.ViolationType,
                            ViolatorName = model.ViolatorName
                        };
                        return View(notify);
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
        public IActionResult ReassignExtendedCase([Bind]NotificationsViewModel notify)
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
                if (
                    srm[i].ToString() == "isManager" || 
                    srm[i].ToString() == "isOfficer"
                    )
                {
                    try
                    {
                        da.AddToHistoryHelper(conString, "Under Investigation", notify.ViolationCaseId);
                        da.UpdateInvestigatorName(conString, notify.ViolationCaseId, notify.InvestigatorName, "Under Investigation");
                        return RedirectToAction("CaseReassignedSuccess");
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

        [HttpPost(("/Notifications/SettlePayment/{id}"))]
        public IActionResult SettlePayment(Guid id)
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
                if (
                    srm[i].ToString() == "isManager" || 
                    srm[i].ToString() == "isOfficer"
                    )
                {
                    try
                    {
                        nda.SettlePenaltyPayment(conString, id);
                        return RedirectToAction("Index", "Notifications");
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

        [HttpPost("/Notifications/PostFirstWarning/{id}")]
        public IActionResult PostFirstWarning(Guid id)
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
                if (
                    srm[i].ToString() == "isManager" || 
                    srm[i].ToString() == "isOfficer"
                    )
                {
                    try
                    {
                        nda.PostWarning(conString, id, "First");
                        return RedirectToAction("Index", "Notifications");
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

        [HttpPost("/Notifications/PostSecondWarning/{id}")]
        public IActionResult PostSecondWarning(Guid id)
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
                if (
                    srm[i].ToString() == "isManager" || 
                    srm[i].ToString() == "isOfficer"
                    )
                {
                    try
                    {
                        nda.PostWarning(conString, id, "Second");
                        return RedirectToAction("Index", "Notifications");
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

        [HttpPost("/Notifications/ClaimPenaltyUnenforced/{id}")]
        public IActionResult ClaimPenaltyUnenforced(Guid id)
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
                if (
                    srm[i].ToString() == "isManager" || 
                    srm[i].ToString() == "isOfficer"
                    )
                {
                    try
                    {
                        nda.PostWarning(conString, id, "Unenforced");
                        return RedirectToAction("Index", "Notifications");
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

        [HttpPost("/Notifications/LiftSuspension/{id}")]
        public IActionResult LiftSuspension(Guid id)
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
                if (
                    srm[i].ToString() == "isManager" || 
                    srm[i].ToString() == "isOfficer"
                    )
                {
                    try
                    {
                        da.AddToHistoryHelper(conString, "Penalized", id);
                        da.UpdateCaseStatus(conString, id, "Done");
                        return View("SuspensionLiftedSuccess");
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

        public IActionResult CaseReassignedSuccess()
        {
            HttpContext.Session.Clear();
            HttpContext.Session.Remove(HttpContext.Session.Id);
            Response.Cookies.Delete(HttpContext.Session.Id);
            //--- Code for getting the properties of the logged in user from AD 
            var directoryentriy = _authService.getUserdetail(User.Identity.Name);
            var employeeName = directoryentriy.Properties["CN"][0].ToString();
            var employeeId = _authService.loadList(employeeName);


            //--- Code for getting setting of application
            string endpoint = MySetting.Url;

            //--- Code for getting the user permission from web service
            SecurityController sc = new SecurityController();
            List<SecurityRights> srm = new List<SecurityRights>();
            srm = sc.GetUserRights(employeeId.ToString(), endpoint);

            for (int i = 0; srm.Count > i; i++)
            {
                if (
                    srm[i].ToString() == "isManager" || 
                    srm[i].ToString() == "isOfficer"
                    )
                {
                    return View();
                }
            }
            return View("ErrorPage", "Home");
        }
        public IActionResult SuspensionLiftedSuccess()
        {
            HttpContext.Session.Clear();
            HttpContext.Session.Remove(HttpContext.Session.Id);
            Response.Cookies.Delete(HttpContext.Session.Id);
            //--- Code for getting the properties of the logged in user from AD 
            var directoryentriy = _authService.getUserdetail(User.Identity.Name);
            var employeeName = directoryentriy.Properties["CN"][0].ToString();
            var employeeId = _authService.loadList(employeeName);

            //--- Code for getting setting of application
            string endpoint = MySetting.Url;

            //--- Code for getting the user permission from web service
            SecurityController sc = new SecurityController();
            List<SecurityRights> srm = new List<SecurityRights>();
            srm = sc.GetUserRights(employeeId.ToString(), endpoint);

            for (int i = 0; srm.Count > i; i++)
            {
                if (
                    srm[i].ToString() == "isManager" ||
                    srm[i].ToString() == "isOfficer"
                    )
                {
                    return View();
                }
            }
            return View("ErrorPage", "Home");
        }

        public IActionResult SuccessOverdueCaseExtension()
        {
            HttpContext.Session.Clear();
            HttpContext.Session.Remove(HttpContext.Session.Id);
            Response.Cookies.Delete(HttpContext.Session.Id);
            //--- Code for getting the properties of the logged in user from AD 
            var directoryentriy = _authService.getUserdetail(User.Identity.Name);
            var employeeName = directoryentriy.Properties["CN"][0].ToString();
            var employeeId = _authService.loadList(employeeName);

            //--- Code for getting setting of application
            string endpoint = MySetting.Url;

            //--- Code for getting the user permission from web service
            SecurityController sc = new SecurityController();
            List<SecurityRights> srm = new List<SecurityRights>();
            srm = sc.GetUserRights(employeeId.ToString(), endpoint);

            for (int i = 0; srm.Count > i; i++)
            {
                if (
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