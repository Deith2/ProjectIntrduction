using Hobby.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hobby.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _uow;
        public HomeController(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public ActionResult Index()
        {
            var test = _uow.Users.Single(p => p.Id == 1);
            return View();
        }

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