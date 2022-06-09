using System;
using System.Collections.Generic;
using System.IO;
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
    public class ViolationManagerController : Controller
    {
        private MySetting MySetting { get; set; }
        private readonly IAuthenticationService _authService;
        static CasesAssignmentViewModel AssModel = new CasesAssignmentViewModel();
        static PassBCCDecisionViewModel PassModel = new PassBCCDecisionViewModel();
        static ManagerDecisionToDropViewModel ToDropClassModel = new ManagerDecisionToDropViewModel();
        DataAccessUtility da = new DataAccessUtility();
        ManagerDataAccess mda = new ManagerDataAccess();
        static bool searched = false;
        private readonly IMemoryCache memoryCache;
        public List<BCCCasesViewModel> model  { get; set; }
        public static BCCCasesListClass BCCCasesListStat { get; set; }

        public ViolationManagerController(IOptions<MySetting> settings, IAuthenticationService authService, IMemoryCache Cache)
        {
            MySetting = settings.Value;
            _authService = authService;
            memoryCache = Cache;
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
                        List<string> emps;
                        List<ExchangeEmployeesModel> employees = new List<ExchangeEmployeesModel>();
                        bool exists = memoryCache.TryGetValue("Investigators", out emps);
                        if (!exists)
                        {
                            emps = da.GetAllInvestigators(conString).ToList();//.Where(x => x.StartsWith(term, StringComparison.OrdinalIgnoreCase)).Select(y => y).ToList();
                            var cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromMinutes(120));
                            memoryCache.Set("Investigators", emps, cacheEntryOptions);
                        }

                        foreach (string name in emps)
                        {
                            ExchangeEmployeesModel em = new ExchangeEmployeesModel();
                            em.EmployeeName = name;
                            employees.Add(em);
                        }

                        return View(employees);
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

        public IActionResult AssignCases()
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
                        CasesAssignmentViewModel ViewModel = da.GetAllCasesToAssign(conString);
                        ViewModel.ViolationTypes = DataAccessUtility.GetSelectListItems(DataAccessUtility.GetAllViolationTypes(conString)).ToList();
                        return View(ViewModel);
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
        public IActionResult AssignCases(string ViolatorName, string ViolationType)
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
                        searched = true;
                        CasesAssignmentViewModel AssignCases = da.GetAllCasesToAssign(conString);
                        CasesAssignmentViewModel model = new CasesAssignmentViewModel
                        {
                            OthersModel = new List<OthersViewModel>(),
                            SurveillanceModel = new List<SurveillanceViewModel>(),
                            TradeModel = new List<TradeViewModel>(),
                            ViolationTypes = DataAccessUtility.GetSelectListItems(DataAccessUtility.GetAllViolationTypes(conString)).ToList()
                        };
                        if (string.IsNullOrEmpty(ViolatorName) && string.IsNullOrEmpty(ViolationType))
                        {
                            model = AssignCases;
                        }
                        else if (!string.IsNullOrEmpty(ViolatorName) && string.IsNullOrEmpty(ViolationType))
                        {
                            foreach (OthersViewModel vm in AssignCases.OthersModel)
                            {
                                if (vm.ViolationModel.ViolatorName.StartsWith(ViolatorName, StringComparison.OrdinalIgnoreCase))
                                    model.OthersModel.Add(vm);
                            }

                            foreach (SurveillanceViewModel vm in AssignCases.SurveillanceModel)
                            {
                                if (vm.ViolationModel.ViolatorName.StartsWith(ViolatorName, StringComparison.OrdinalIgnoreCase))
                                    model.SurveillanceModel.Add(vm);
                            }

                            foreach (TradeViewModel vm in AssignCases.TradeModel)
                            {
                                if (vm.ViolationModel.ViolatorName.StartsWith(ViolatorName))
                                    model.TradeModel.Add(vm);
                            }
                        }
                        else if (!string.IsNullOrEmpty(ViolationType) && string.IsNullOrEmpty(ViolatorName))
                        {
                            foreach (OthersViewModel vm in AssignCases.OthersModel)
                            {
                                if (vm.ViolationModel.ViolationType.StartsWith(ViolationType))
                                    model.OthersModel.Add(vm);
                            }

                            foreach (SurveillanceViewModel vm in AssignCases.SurveillanceModel)
                            {
                                if (vm.ViolationModel.ViolationType.StartsWith(ViolationType))
                                    model.SurveillanceModel.Add(vm);
                            }

                            foreach (TradeViewModel vm in AssignCases.TradeModel)
                            {
                                if (vm.ViolationModel.ViolationType.StartsWith(ViolationType))
                                    model.TradeModel.Add(vm);
                            }
                        }
                        else if (!string.IsNullOrEmpty(ViolationType) && !string.IsNullOrEmpty(ViolatorName))
                        {
                            foreach (OthersViewModel vm in AssignCases.OthersModel)
                            {
                                if (
                                    vm.ViolationModel.ViolationType.StartsWith(ViolationType)
                                    &&
                                    vm.ViolationModel.ViolatorName.StartsWith(ViolatorName, StringComparison.OrdinalIgnoreCase)
                                    )
                                    model.OthersModel.Add(vm);
                            }

                            foreach (SurveillanceViewModel vm in AssignCases.SurveillanceModel)
                            {
                                if (
                                    vm.ViolationModel.ViolationType.StartsWith(ViolationType)
                                    &&
                                    vm.ViolationModel.ViolatorName.StartsWith(ViolatorName, StringComparison.OrdinalIgnoreCase)
                                    )
                                    model.SurveillanceModel.Add(vm);
                            }

                            foreach (TradeViewModel vm in AssignCases.TradeModel)
                            {
                                if (vm.ViolationModel.ViolationType.StartsWith(ViolationType)
                                    &&
                                    vm.ViolationModel.ViolatorName.StartsWith(ViolatorName, StringComparison.OrdinalIgnoreCase)
                                    )
                                    model.TradeModel.Add(vm);
                            }
                        }

                        AssModel.OthersModel = new List<OthersViewModel>();
                        AssModel.OthersModel = model.OthersModel;
                        AssModel.SurveillanceModel = new List<SurveillanceViewModel>();
                        AssModel.SurveillanceModel = model.SurveillanceModel;
                        AssModel.TradeModel = new List<TradeViewModel>();
                        AssModel.TradeModel = model.TradeModel;

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

        public IActionResult AssignInvestigator(string InvestigatorName)
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
                        if (!searched)
                            AssModel = da.GetAllCasesToAssign(conString);
                        AssModel.InvestigatorName = InvestigatorName;
                        mda.AssignInvestigatorToCases(conString, AssModel);
                        return View("AssignSuccess", "ViolationManager");
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

        public IActionResult CasesToDrop()
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
                        CasesToDropViewModel model = mda.GetAllCasesToDrop(conString, employeeName);
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

        public IActionResult ReviewToDecide(Guid id)
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
                        ViolationCaseModel model = da.GetViolationModel(conString, id);
                        ManagerDecisionToDropViewModel toDrop = new ManagerDecisionToDropViewModel();
                        object viewModel = new object();
                        switch (model.ViolationType)
                        {
                            case "Other":
                                toDrop.ViolationType = "Other";
                                viewModel = da.GetCaseForView(conString, id, 'o', "spGetAllOtherJoined");
                                toDrop.Others = new OthersViewModel();
                                toDrop.Others = (OthersViewModel)viewModel;
                                toDrop.ManagerDecisionId = toDrop.Others.ViolationModel.ViolationCaseId;
                                break;
                            case "Quality":
                                toDrop.ViolationType = "Quality";
                                viewModel = da.GetCaseForView(conString, id, 'q', "spGetAllQualityJoined");
                                toDrop.Quality = new QualityViewModel();
                                toDrop.Quality = (QualityViewModel)viewModel;
                                toDrop.ManagerDecisionId = toDrop.Quality.ViolationModel.ViolationCaseId;
                                break;
                            case "Surveillance":
                                toDrop.ViolationType = "Surveillance";
                                viewModel = da.GetCaseForView(conString, id, 's', "spGetAllSurveillanceJoined");
                                toDrop.Surveillance = new SurveillanceViewModel();
                                toDrop.Surveillance = (SurveillanceViewModel)viewModel;
                                toDrop.ManagerDecisionId = toDrop.Surveillance.ViolationModel.ViolationCaseId;
                                break;
                            case "Trade":
                                toDrop.ViolationType = "Trade";
                                viewModel = da.GetCaseForView(conString, id, 't', "spGetAllTradeJoined");
                                toDrop.Trade = new TradeViewModel();
                                toDrop.Trade = (TradeViewModel)viewModel;
                                toDrop.ManagerDecisionId = toDrop.Trade.ViolationModel.ViolationCaseId;
                                break;
                        }
                        ToDropClassModel = toDrop;
                        return View(toDrop);
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
        public async Task<IActionResult> ReviewToDecide(string reinstate, string drop, string managerremark, string downloadbtn)
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
                        da.AddToHistoryHelper(conString, "To Drop", ToDropClassModel.ManagerDecisionId);
                        ToDropClassModel.ManagerDecisionRemark = managerremark;
                        string stdpr = "";
                        if (!string.IsNullOrEmpty(drop))
                        {
                            stdpr = "spUpDateMnagerRemarkDrop";
                            mda.UpdateManagerRemark(conString, ToDropClassModel.ManagerDecisionId, managerremark, stdpr);
                            return View("DropSuccess");
                        }
                        if (!string.IsNullOrEmpty(reinstate))
                        {
                            stdpr = "spUpDateMnagerRemarkReinstate";
                            mda.UpdateManagerRemark(conString, ToDropClassModel.ManagerDecisionId, managerremark, stdpr);
                            return View("ReinstateSuccess");
                        }
                        if (!string.IsNullOrEmpty(downloadbtn))
                        {
                            var memory = new MemoryStream();
                            string path = null;
                            if (ToDropClassModel.ViolationType == "Other")
                            {
                                path = ToDropClassModel.Others.ViolationModel.SupportingDocuments;
                            }
                            else if (ToDropClassModel.ViolationType == "Quality")
                            {
                                path = ToDropClassModel.Quality.ViolationModel.SupportingDocuments;
                            }
                            else if (ToDropClassModel.ViolationType == "Surveillance")
                            {
                                path = ToDropClassModel.Surveillance.ViolationModel.SupportingDocuments;
                            }
                            else if (ToDropClassModel.ViolationType == "Trade")
                            {
                                path = ToDropClassModel.Trade.ViolationModel.SupportingDocuments;
                            }
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
                    return NotFound();
                }
            }
            return View("ErrorPage", "Home");
        }
               

        public IActionResult PassBCC()
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
                    srm[i].ToString() == "isOfficer" || 
                    srm[i].ToString() == "isSecretary"
                    )
                {
                    try
                    {
                        List<BCCCasesViewModel> casesModel = new List<BCCCasesViewModel>();
                        casesModel = mda.GetAllBCCCases(conString);

                        return View(casesModel);
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
        public IActionResult PassBccSelectedDecision(string financial, string begindate, string enddate,
                    string terminationdate, string effectivedate, string bccsum)
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
                    srm[i].ToString() == "isSecretary" || 
                    srm[i].ToString() == "isOfficer"
                    )
                {
                    try
                    {
                        BCCCasesListClass model = new BCCCasesListClass();
                        model.BCCCasesList = new List<BCCCasesViewModel>();
                        model.BCCCasesList = BCCCasesListStat.BCCCasesList;
                        model.BCCSummary = bccsum;

                        if (!string.IsNullOrEmpty(financial))
                        {
                            model.DecisionAmountPenalized = Convert.ToDouble(financial);
                            model.DecisionPassedDate = effectivedate;
                            model.DecisionPenaltyType = "Financial";
                        }
                        else if (!string.IsNullOrEmpty(terminationdate) && terminationdate != "mm/dd/yyyy")
                        {
                            model.DecisionPenaltyType = "Termination";
                            model.TerminationDate = terminationdate;
                        }
                        else if (!string.IsNullOrEmpty(begindate) && !string.IsNullOrEmpty(enddate) &&
                            begindate != "mm/dd/yyyy" && enddate != "mm/dd/yyyy")
                        {
                            model.DecisionPenaltyType = "Suspension";
                            model.SuspensionBeginingDate = begindate;
                            model.SuspensionEndingDate = enddate;
                        }
                        else
                        {
                            model.DecisionPenaltyType = "Dismissed";
                        }

                        mda.PassBCCDecision(conString, model);
                        return View("SuccessDecisionPassed", "ViolationManager");
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
        public IActionResult DecideSelectedBCCCases(string violatorName)
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
                    srm[i].ToString() == "isSecretary" || 
                    srm[i].ToString() == "isOfficer"
                    )
                {
                    try
                    {
                        BCCCasesListClass CasesList = new BCCCasesListClass();
                        CasesList.BCCCasesList = new List<BCCCasesViewModel>();
                        List<BCCCasesViewModel> myModel = new List<BCCCasesViewModel>();
                        List<BCCCasesViewModel> casesModel = new List<BCCCasesViewModel>();
                        casesModel = mda.GetAllBCCCases(conString);

                        if (string.IsNullOrEmpty(violatorName))
                        {
                            myModel = casesModel;
                        }
                        else
                        {
                            foreach (BCCCasesViewModel vm in casesModel)
                            {
                                if (vm.DecisionViolatorName.StartsWith(violatorName, StringComparison.OrdinalIgnoreCase))
                                {
                                    myModel.Add(vm);
                                }
                            }
                        }
                        //CasesList.BCCCasesList = myModel;
                        return View(myModel);
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
        public ActionResult DecideonSelectedCases(List<BCCCasesViewModel> CasesList)
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
                    srm[i].ToString() == "isSecretary" || 
                    srm[i].ToString() == "isOfficer"
                    )
                {
                    try
                    {

                        BCCCasesListClass BCCCasesList = new BCCCasesListClass();
                        BCCCasesList.BCCCasesList = new List<BCCCasesViewModel>();
                        BCCCasesList.BCCCasesList = CasesList;
                        BCCCasesListStat = BCCCasesList;
                        return View(BCCCasesList);
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
        public IActionResult GetSelectedListforBCC()
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
                        BCCCasesListClass model = new BCCCasesListClass();
                        model = BCCCasesListStat;
                        model.PenaltyTypes = DataAccessUtility.GetSelectListItems(DataAccessUtility.GetAllPenaltyTypes(conString));
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

        [HttpPost("/ViolationManager/RemoveInvestigator/{name}")]
        public IActionResult RemoveInvestigator(string name)
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
                    string sp = "spRemoveInvestigator";
                    da.AddOrRemoveInvestigator(conString, sp, name);
                    List<string> emps;
                    emps = da.GetAllInvestigators(conString).ToList();
                    List<ExchangeEmployeesModel> elm = new List<ExchangeEmployeesModel>();
                    foreach (string n in emps)
                    {
                        ExchangeEmployeesModel mod = new ExchangeEmployeesModel();
                        mod.EmployeeName = n;
                        elm.Add(mod);
                    }
                    var cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromMinutes(120));
                    memoryCache.Set("Investigators", emps, cacheEntryOptions);

                    return RedirectToAction("Index", "ViolationManager");
                }
            }
            return View("ErrorPage", "Home");
        }

        [HttpPost("/ViolationManager/AddInvestigator")]
        public IActionResult AddInvestigator(string invname)
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
                    string sp = "spAddInvestigator";
                    da.AddOrRemoveInvestigator(conString, sp, invname);
                    List<string> emps;
                    emps = da.GetAllInvestigators(conString).ToList();
                    List<ExchangeEmployeesModel> elm = new List<ExchangeEmployeesModel>();
                    foreach (string n in emps)
                    {
                        ExchangeEmployeesModel mod = new ExchangeEmployeesModel();
                        mod.EmployeeName = n;
                        elm.Add(mod);
                    }
                    var cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromMinutes(120));
                    memoryCache.Set("Investigators", emps, cacheEntryOptions);


                    return RedirectToAction("Index", "ViolationManager");
                }
            }
            return View("ErrorPage", "Home");
        }

        public IActionResult InvestigatorRemovedSuccess()
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
                    return View();
                }
            }
            return View("ErrorPage", "Home");
        }

        public IActionResult AssignSuccess()
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
                    return View();
                }
            }
            return View("ErrorPage", "Home");
        }

        public IActionResult DropSuccess()
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
                    return View();
                }
            }
            return View("ErrorPage", "Home");
        }

        public IActionResult ReinstateSuccess()
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
                    return View();
                }
            }
            return View("ErrorPage", "Home");
        }

        public IActionResult SuccessDecisionPassed()
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
                    srm[i].ToString() == "isSecretary" || 
                    srm[i].ToString() == "isOfficer"
                    )
                {
                    return View();
                }
            }
            return View("ErrorPage", "Home");
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

    }
}