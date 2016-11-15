using Hobby.Common.Authentication;
using Hobby.DTO;
using Hobby.Entities;
using Hobby.Services.Interfaces;
using Hobby.Web.Controllers;
using Hobby.Web.Parts.UserSettings.Models;
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

        [HttpPost]
        public ActionResult EditSettings(SettingsModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _userService.GetUserDTO(User.UserId);
                var password = model.Password.getSHA1().ToUpper();
                if (password.Equals(user.Password))
                {
                    user.LastName = model.LastName;
                    user.FirstName = model.FirstName;
                    user.Email = model.Email;

                    var change = _userService.UpdateUser(user);
                    if (change != null)
                    {
                        return Json(new
                        {
                            FirstName = user.FirstName,
                            LastName = user.LastName,
                            Email = user.Email
                        });
                    }
                    else
                    {
                        return Json(new { Email = "Email is busy" });
                    }
                                 }
            }

            return Json(new { });
        }
    }
}