using Hobby.Services.Interfaces;
using Hobby.Web.Controllers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hobby.Web.Parts.UserSettings
{
    public class UserSettingsController : BaseController
    {
        private readonly IUserService _userService;

        public UserSettingsController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: UserSettings
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetUser()
        {
            var user = _userService.GetUserDTO(User.UserId);

            return Json(new
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email
            }, 
            JsonRequestBehavior.AllowGet);
        }
    }
}