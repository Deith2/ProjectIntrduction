using Hobby.DTO;
using Hobby.Services.Interfaces;
using Hobby.Web.Authorize;
using Hobby.Web.Parts.Authorization.Models;
using Newtonsoft.Json;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Hobby.Web.Parts.Authorization
{
    public class AuthorizationController : Controller
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private readonly IUserService _userService;

        public AuthorizationController(IUserService userService)
        {
            _userService = userService;
        }
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Login(LoginModel model, string returnUrl = "")
        {
            if (ModelState.IsValid)
            {
                var user = _userService.CheckUser(model.Email, model.Password);

                if (user != null)
                {
                    var roles = _userService.PermissionActiveNameList(user.Id).ToList();

                    CustomPrincipalSerializeModel serializeModel = new CustomPrincipalSerializeModel();
                    serializeModel.UserId = user.Id;
                    serializeModel.Email = user.Email;
                    serializeModel.FirstName = user.FirstName;
                    serializeModel.LastName = user.LastName;
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

                    return Json(new
                    {
                        redirectUrl = Url.Action("Index", "Home"),
                        isRedirect = true
                    });
                }

                ModelState.AddModelError(String.Empty, "Incorrect username and/or password");
            }

            return Json(model);
        }

        [HttpPost]
        public JsonResult Register(RegisterModel model)
        {          
            if (ModelState.IsValid)
            {  
                try
                {
                    UserDTO entity = new UserDTO()
                    {
                        Email = model.Email,
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        Password = model.Password
                    };
                    bool userExist = _userService.Register(entity);

                    return Json(new
                    {
                        userExist = userExist,
                        userModel = model
                    });
                }
                catch (Exception ex)
                {
                    logger.Error("Error to register a new user", ex);

                    return Json("Error save");
                }
            }

            return Json(new { });
        }

        [AllowAnonymous]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account", null);
        }
    }
}