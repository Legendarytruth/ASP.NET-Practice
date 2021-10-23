using HPlus.Ecommerce.Models;
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
            return View();
        }
        
        [Route("product/{productName}")]
        public ActionResult Detail(string productName)
        {
            ViewBag.Product = new Product
            {
                Name = "Women's Winter Jacket",
                FullPrice = 30.00M,
                CurrentPrice = 10.00M,
                PercentOff = 33,
                ImagePath = "/Content/Images/Products/1.jpg",
                StarRating = 3
            };
            return View();
        }
    }
}