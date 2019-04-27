using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class studentViewController : Controller
    {
        // GET: studentView
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Timetable()
        {
            return View();
        }

        public ActionResult Datesheet()
        {
            return View();
        }

        public ActionResult Assignment()
        {
            return View();
        }
    }
}