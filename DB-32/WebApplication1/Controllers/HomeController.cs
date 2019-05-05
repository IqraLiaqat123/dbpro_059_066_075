using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        //index page
        public ActionResult Index()
        {
            return View();
        }
        //about page
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        //contact page
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}