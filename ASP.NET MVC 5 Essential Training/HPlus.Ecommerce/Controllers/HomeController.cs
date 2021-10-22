using HPlus.Ecommerce.Filters;
using System.Web.Mvc;

namespace HPlus.Ecommerce.Controllers
{
    [CrawlerFilter]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}