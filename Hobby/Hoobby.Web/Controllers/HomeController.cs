using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hobby.Services.Interfaces;
using Hobby.Web.Authorize;
using Hobby.Web.Controllers;

namespace Hobby.Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IUserService _userService;

        public HomeController(IUserService userService)
        {
            _userService = userService;
        }

        [CustomAuthorize(Roles = "Admin")]
        public ActionResult Index()
        {
            if (User != null)
            {
                ViewBag.user = User.Identity.IsAuthenticated;
                ViewBag.user1 = User.Login;
                ViewBag.user2 = User.Email;
                ViewBag.user3 = User.UserId;
                ViewBag.user4 = User.roles.Count;
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Account");                
            }
        }

        [CustomAuthorize(Users = "darek4")]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}