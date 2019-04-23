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
        DB32Entities2 db = new DB32Entities2();
        // GET: Admin
        public ActionResult Dashboard()
        {


            ViewBag.Course = db.Courses.SqlQuery("SELECT * FROM dbo.Course").Count();
            ViewBag.Student = db.Students.SqlQuery("SELECT * FROM dbo.Student").Count();
            ViewBag.Teacher = db.Teachers.SqlQuery("SELECT * FROM dbo.Teacher").Count();
            ViewBag.Class = db.Classes.SqlQuery("SELECT * FROM dbo.Class").Count();
            return View();
        }
        public ActionResult class_section()
        {
            return View();
        }
        public ActionResult createclass()
        {
            return View();
        }
        [HttpPost]
        public ActionResult createclass(Class c)
        {
            if (ModelState.IsValid) {
                db.Classes.Add(c);
                db.SaveChanges();
                RedirectToAction("Index");
            }
            return View("Index");
        }
     }
}