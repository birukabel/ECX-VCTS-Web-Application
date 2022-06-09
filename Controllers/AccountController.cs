using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECX.VCTS.ldap;
using ECX.VCTS.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Novell.Directory.Ldap;

namespace ECX.VCTS.Controllers
{
    public class AccountController : Controller
    {
        //--- Global Initialzation 
        private readonly LdapConfig _config;
        private readonly LdapConnection _connection;
        //--- Constructor of a controller 
        public AccountController(IOptions<LdapConfig> config)
        {
            _config = config.Value;
            _connection = new LdapConnection();

        }
        /// <summary>
        ///  Get:To return Login view
        /// </summary>
        /// <returns>View</returns>
        [HttpGet]
        public IActionResult Login()
        {
            var model = new LoginViewModel();
            return View(model);
        }

        /// <summary>
        /// POST:To Login user using AD username and password to application
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _connection.Connect(_config.LdapHost, _config.LdapPort);
                    _connection.Bind(_config.LoginDN, _config.Password);

                    string name = model.Username.Replace(".", " ");
                    _connection.Bind(name, model.Password);

                    if (_connection.Bound)
                    {

                        return Redirect("/Home/Index");

                    }

                }


                catch
                {

                    return Redirect("/Home/ErrorAll");
                }

            }

            return Redirect("/");
        }
        /// <summary>
        /// To logout user from Application
        /// </summary>
        /// <returns></returns>


        public IActionResult Logout()
        {
            var model = new LoginViewModel();
            HttpContext.Session.Clear();
            HttpContext.Session.Remove(HttpContext.Session.Id);
            var cookiess = Request.Cookies.Keys;
            ViewBag.calljavascriptfunction = "logout();";
            Response.Cookies.Delete(".AspNetCore.Antiforgery.kLmeyaPL6YU");

            foreach (var cookie in Request.Cookies.Keys)
            {
                Response.Cookies.Delete(cookie);

            }
            foreach (var cookie in HttpContext.Request.Cookies)
            {
                Response.Cookies.Delete(cookie.Key);
            }
            Response.Cookies.Append(".AspNetCore.Antiforgery.kLmeyaPL6YU1", "", new CookieOptions()
            {
                Expires = DateTime.Now.AddDays(-1)
            });

            return RedirectToAction("Login", "Account");
        }
        /* public ActionResult Create()
         {
             HttpCookie cookie = new HttpCookie("Cookie");
             cookie.Value = "Hello Cookie! CreatedOn: " + DateTime.Now.ToShortTimeString();

             this.ControllerContext.HttpContext.Response.Cookies.Add(cookie);
             return RedirectToAction("Index", "Home");
         }

         public ActionResult Remove()
         {
             if (this.ControllerContext.HttpContext.Request.Cookies.AllKeys.Contains("Cookie"))
             {
                 HttpCookie cookie = this.ControllerContext.HttpContext.Request.Cookies["Cookie"];
                 cookie.Expires = DateTime.Now.AddDays(-1);
                 this.ControllerContext.HttpContext.Response.Cookies.Add(cookie);
             }
             return RedirectToAction("Index", "Home");
         }*/
    }
}