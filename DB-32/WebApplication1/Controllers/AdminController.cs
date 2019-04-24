using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using WebApplication1.Models;
using System.Net;

namespace WebApplication1.Controllers
{
    public class AdminController : Controller
    {
        DB32Entities1 db = new DB32Entities1();
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
        [HttpGet]
        public ActionResult creatsection()
        {
            var Class1 = db.Classes.ToList();
            if(Class1 != null)
            {
                ViewBag.Class = Class1;
            }
            return View();
        }
        [HttpPost]
        public ActionResult creatsection(Section c)
        {
            if (ModelState.IsValid)
            {
                db.Sections.Add(c);
                db.SaveChanges();
                RedirectToAction("class_section");
            }
            return View("class_section");
        }
        public ActionResult createclass()
        {
            return View();
        }
        [HttpPost]
        public ActionResult createclass(Class c)
        {
            if (ModelState.IsValid)
            {
                db.Classes.Add(c);
                db.SaveChanges();
                RedirectToAction("class_section");
            }
            return View("class_section");
        }
        public ActionResult listclass()
        {
             
            return View(db.Classes.ToList());
        }
        public ActionResult listsection()
        {

            return View(db.Sections.ToList());
        }

        [HttpGet]
        public ActionResult deletesection(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Section personalDetail = db.Sections.Find(id);
            if (personalDetail == null)
            {
                return HttpNotFound();
            }
            return View(personalDetail);
        }
        
          
        [HttpPost, ActionName("deletesection")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Section personalDetail = db.Sections.Find(id);
            db.Sections.Remove(personalDetail);
            db.SaveChanges();
            return RedirectToAction("listsection");
        }

        
     }
}