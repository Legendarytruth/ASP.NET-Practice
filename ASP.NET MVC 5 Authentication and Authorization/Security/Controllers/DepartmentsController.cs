using Security.Models;
using System.Web.Mvc;

namespace Security.Controllers
{
    public class DepartmentsController : Controller
    {
        // GET: Departments
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Create([Bind(Include = "Name, Description")]Department department)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            return View(department);
        }
    }
}