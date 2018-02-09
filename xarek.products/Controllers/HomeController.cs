using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace xarek.products.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult List()
        {
            return View();
        }
        public ActionResult detail()
        {

            return View();
        }
        public ActionResult Index()
        {
            ViewBag.Title = "Перечень продуктов";

            return View();
        }
    }
}
