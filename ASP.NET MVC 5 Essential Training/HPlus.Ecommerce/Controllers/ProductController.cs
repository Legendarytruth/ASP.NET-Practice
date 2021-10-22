using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HPlus.Ecommerce.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View("List");
        }
        
        [Route("product/{productName}")]
        public ActionResult Detail(string productName)
        {
            return View();
        }
    }
}