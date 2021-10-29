using HPlusSport.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;


using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System.Security.Claims;

namespace HPlusSport.Web.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account/Login
        public ActionResult Login()
        {
            return View();
        }

        // POST: Account/Login
        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            using (var db = new ShopContext())
            {
                var user = db.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
                if (user == null)
                {
                    ViewBag.Message = "User name or password invalid";
                    return View();
                }

                var claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
                claims.Add(new Claim(ClaimTypes.Email, user.Email));

                //var identity = new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie);
                var identity = new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie, ClaimTypes.Email, "");

                AuthenticationManager.SignIn(identity);
                
                return RedirectToAction("Index", "Shop");
            }
        }

        public ActionResult Logout()
        {
            return View();
        }

        // POST: Account/Logout
        [HttpPost, ActionName("Logout")]
        public ActionResult LogoutPost()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Index", "Home");
        }

        private IAuthenticationManager AuthenticationManager
        {
            get { return HttpContext.GetOwinContext().Authentication; }
        }
    }
}