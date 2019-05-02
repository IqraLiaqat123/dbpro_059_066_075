using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class teacherViewController : Controller
    {
        // GET: teacherView
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Attendance()
        {
            return View();
        }

        public ActionResult Evaluation()
        {
            return View();
        }

        public ActionResult DeleteEvaluation()
        {
            return View();
        }

        public ActionResult Assignment()
        {
            return View();
        }

        public ActionResult DeleteAssignment()
        {
            return View();
        }

        public ActionResult Datesheet()
        {
            return View();
        }

        public ActionResult DeleteDatesheet()
        {
            return View();
        }
    }
}