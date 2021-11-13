using SocialIdentity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SocialIdentity.Controllers
{
    [Authorize(Roles = "Administrators, Managers")]
    public class HomeController : Controller
    {
        [Authorize(Roles = "Managers")]
        public ActionResult Index()
        {
            return View();
        }

        //[AllowAnonymous]
        [Authorize]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            ViewBag.Message = "Your contact page.";
            var VM = new MyViewModel();
            VM.IsAdmin = false;
            return View(VM);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            var VM = new MyViewModel();
            VM.IsAdmin = true;
            return View(VM);
        }
    }
}