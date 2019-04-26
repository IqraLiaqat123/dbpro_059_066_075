using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class ManageTeacherController : Controller
    {
        // GET: ManageTeacher
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Attendance()
        {
            return View();
        }
        public ActionResult DeleteAttendance()
        {
            return View();
        }
        public ActionResult StudentEvaluation()
        {
            return View();
        }
    }
}