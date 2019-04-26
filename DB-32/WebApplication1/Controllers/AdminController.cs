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
        public ActionResult addteacher()
        {
            var Class1 = db.Lookups.SqlQuery("SELECT * FROM dbo.Lookup WHERE dbo.Lookup.category = 'GENDER'").ToList();
            if (Class1 != null)
            {
                ViewBag.Class = Class1;
            }
            return View();
        }
        [HttpPost]
        public ActionResult addteacher(Person c)
        {
            if (ModelState.IsValid)
            {
                
                db.People.Add(c);
                db.SaveChanges();
                RedirectToAction("teacherinfo");
            }
            return View("teacherinfo");
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
        [HttpGet]
        public ActionResult studentsection()
        {
            var Class1 = db.Students.ToList();
            if (Class1 != null)
            {

                ViewBag.Student = Class1;
            }

            var s = db.Sections.ToList();
            if (Class1 != null)
            {
                ViewBag.Section = s;
            }
            return View();
        }
        [HttpPost]
        public ActionResult studentsection(SectionStudent c)
        {
            if (ModelState.IsValid)
            {
                
                ViewBag.v    = db.SectionStudents.SqlQuery("Select id from lookup where value= ACTIVE");
                c.status = ViewBag.v;
                db.SectionStudents.Add(c);
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
        public ActionResult listsectionstudent()
        {

            return View(db.SectionStudents.ToList());
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
        public ActionResult teachers()
        {
            return View();
        }

    }
}