using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class AdminController : Controller
    {
        DB32Entities db = new DB32Entities();
        // GET: Admin
        public ActionResult Dashboard()
        {
            ViewBag.Courses = db.Courses.SqlQuery(" SELECT * FROM dbo.Course").Count();
            return View();
        }
        public ActionResult class_section()
        {
            return View();
        }
    }
}