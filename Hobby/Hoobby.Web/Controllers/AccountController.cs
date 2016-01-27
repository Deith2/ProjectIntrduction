using Hobby.Services.Interfaces;
using Hobby.Utilities;
using Hobby.Web.Authorize;
using Hobby.Web.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Hobby.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginViewModel model, string returnUrl = "")
        {
            if (ModelState.IsValid)
            {
                var user = _userService.CheckUser(model.Username, model.Password);

                if (user != null)
                {
                    var roles = _userService.PermissionActiveNameList(user.Id).ToList();

                    CustomPrincipalSerializeModel serializeModel = new CustomPrincipalSerializeModel();
                    serializeModel.UserId = user.Id;
                    serializeModel.Email = user.Email;
                    serializeModel.Login = user.Login;
                    serializeModel.roles = roles;

                    string userData = JsonConvert.SerializeObject(serializeModel);
                    FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(
                             1,
                             user.Email,
                             DateTime.Now,
                             DateTime.Now.AddMinutes(15),
                             false,
                             userData);

                    string encTicket = FormsAuthentication.Encrypt(authTicket);
                    HttpCookie setCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
                    Response.Cookies.Add(setCookie);

                    //if (roles.Contains("Admin"))
                    //{
                    //    return RedirectToAction("Index", "Admin");
                    //}
                    //else if (roles.Contains("User"))
                    //{
                    //    return RedirectToAction("Index", "User");
                    //}
                    //else
                    //{
                    return RedirectToAction("Index", "Home");
                    //}
                }

                ModelState.AddModelError(String.Empty, "Incorrect username and/or password");
            }

            return View(model);
        }

        [AllowAnonymous]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account", null);
        }
    }
}