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
        public ActionResult atndce(int id)
        {

            return View(db.Teacherattendences.SqlQuery("Exec teacherattn @add= {0}",id).ToList());
        }
        public ActionResult attendence()
        {
            return View();
        }
        public ActionResult addperson()
        {
            var Class1 = db.Lookups.SqlQuery("SELECT * FROM dbo.Lookup WHERE dbo.Lookup.category = 'GENDER'").ToList();
            if (Class1 != null)
            {
                ViewBag.Class = Class1;
            }
            return View();
        }
        [HttpPost]
        public ActionResult addperson(Person c)
        {
            int id;
            if (ModelState.IsValid)
            {
                
                db.People.Add(c);
                db.SaveChanges();
                id = c.PersonId;
                RedirectToAction("addperson");
            }
            
            return View("studentinfo(id)");
        }
        public ActionResult addperson1()
        {
            var Class1 = db.Lookups.SqlQuery("SELECT * FROM dbo.Lookup WHERE dbo.Lookup.category = 'GENDER'").ToList();
            if (Class1 != null)
            {
                ViewBag.Class = Class1;
            }
            return View();
        }
        [HttpPost]
        public ActionResult addperson1(Person c)
        {

            if (ModelState.IsValid)
            {

                db.People.Add(c);
                db.SaveChanges();
                int id = c.PersonId;
                RedirectToAction("teacherinfo(id)");
            }

            return View("teachers");
        }
        [HttpGet]
        public ActionResult teacherinfo(int id)
        {
            var Class1 = db.Lookups.SqlQuery("SELECT * FROM dbo.Lookup WHERE dbo.Lookup.category = 'DESIGNATION'").ToList();
            if (Class1 != null)
            {
                ViewBag.Designation = Class1;
            }
            return View();
        }
        [HttpPost]
        public ActionResult teacherinfo(Teacher c, int id)
        {
            if (ModelState.IsValid)
            {
                c.Id = id;
                db.Teachers.Add(c);
                db.SaveChanges();
                RedirectToAction("teacherinfo");
            }
            return View("teacherinfo");
        }
        [HttpGet]
        public ActionResult studentinfo(int id)
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult studentinfo(Student c, int id)
        {
            if (ModelState.IsValid)
            {
                c.Id = id;
                db.Students.Add(c);
                db.SaveChanges();
                RedirectToAction("studentinfo");
            }
            return View("studentinfo");
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
        public ActionResult deleteclass(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Class personalDetail = db.Classes.Find(id);
            if (personalDetail == null)
            {
                return HttpNotFound();
            }
            return View(personalDetail);
        }


        [HttpPost, ActionName("deleteclass")]
        [ValidateAntiForgeryToken]
        public ActionResult deleteConfirmed(int id)
        {
            Class personalDetail = db.Classes.Find(id);
            db.Classes.Remove(personalDetail);
            db.SaveChanges();
            return RedirectToAction("listsection");
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
        public ActionResult tchrs()
        {
            return View(db.Teachers.ToList());
        }
        public ActionResult studentattendence()
        {
            return View(db.Students.ToList());
        }
        public ActionResult stdatn(int id)
        {

            return View(db.Studentattendences.SqlQuery("Exec studentattn @add= {0}", id).ToList());
        }
        public ActionResult courses()
        {

            return View();
        }
        [HttpGet]
        public ActionResult addcourse()
        {

            return View();
        }
        [HttpPost]
        public ActionResult addcourse(Course c)
        {
            if (ModelState.IsValid)
            {
                db.Courses.Add(c);
                db.SaveChanges();
                RedirectToAction("courses");
            }
            return View("courses");
            
        }
        public ActionResult courselist()
        {

            return View(db.Courses.ToList());
        }
        [HttpGet]
        public ActionResult Deletecourse(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course personalDetail = db.Courses.Find(id);
            if (personalDetail == null)
            {
                return HttpNotFound();
            }
            return View(personalDetail);
        }


        [HttpPost, ActionName("Deletecourse")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int id) 
        {
            Course personalDetail = db.Courses.Find(id);
            db.Courses.Remove(personalDetail);
            db.SaveChanges();
            return RedirectToAction("courselist");
        }
        [HttpGet]
        public ActionResult addcoursetoclass()
        {
            var Class1 = db.Courses.SqlQuery("SELECT * FROM dbo.Course").ToList();
            if (Class1 != null)
            {
                ViewBag.courses = Class1;
            }
            var Class = db.Classes.SqlQuery("SELECT * FROM dbo.Class").ToList();
            if (Class != null)
            {
                ViewBag.classes = Class;
            }
            return View();
        }
        [HttpPost]
        public ActionResult addcoursetoclass(ClassCourse c)
        {
            if (ModelState.IsValid)
            {
                db.ClassCourses.Add(c);
                db.SaveChanges();
                RedirectToAction("courses");
            }
            return View("courses");

        }
        public ActionResult deletecoursetoclass()
        {

            return View(db.ClassCourses.ToList());
        }
        [HttpGet]
        public ActionResult delclasscourse(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassCourse personalDetail = db.ClassCourses.Find(id);
            if (personalDetail == null)
            {
                return HttpNotFound();
            }
            return View(personalDetail);
        }


        [HttpPost, ActionName("delclasscourse")]
        [ValidateAntiForgeryToken]
        public ActionResult deleteConfirm(int id)
        {
            ClassCourse personalDetail = db.ClassCourses.Find(id);
            db.ClassCourses.Remove(personalDetail);
            db.SaveChanges();
            return RedirectToAction("deletecoursetoclass");
        }
        [HttpGet]
        public ActionResult assign()
        {
            var Class1 = db.Courses.SqlQuery("SELECT * FROM dbo.Course").ToList();
            if (Class1 != null)
            {
                ViewBag.courses = Class1;
            }
            var Class = db.Classes.SqlQuery("SELECT * FROM dbo.Class").ToList();
            if (Class != null)
            {
                ViewBag.classes = Class;
            }
            var Class2 = db.Teachers.SqlQuery("SELECT * FROM dbo.Teacher").ToList();
            if (Class != null)
            {
                ViewBag.teachers = Class2;
            }
            return View();
        }
        [HttpPost]
        public ActionResult assign(ClassCourseTeacher c)
        {
            if (ModelState.IsValid)
            {
                db.ClassCourseTeachers.Add(c);
                db.SaveChanges();
                RedirectToAction("courses");
            }
            return View("courses");

        }
        [HttpGet]
        public ActionResult addtimetable()
        {
            var Class1 = db.Courses.SqlQuery("SELECT * FROM dbo.Course").ToList();
            if (Class1 != null)
            {
                ViewBag.courses = Class1;
            }
            var Class = db.Classes.SqlQuery("SELECT * FROM dbo.Class").ToList();
            if (Class != null)
            {
                ViewBag.classes = Class;
            }
            return View();
        }
        [HttpPost]
        public ActionResult addtimetable(Timetable c)
        {
            if (ModelState.IsValid)
            {
                db.Timetables.Add(c);
                db.SaveChanges();
                RedirectToAction("courses");
            }
            return View("courses");

        }
        public ActionResult timetable()
        {
            return View();
        }
        public ActionResult timetablelist()
        {
            return View(db.Timetables.ToList());
        }
        [HttpGet]
        public ActionResult deletetimeslot(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Timetable personalDetail = db.Timetables.Find(id);
            if (personalDetail == null)
            {
                return HttpNotFound();
            }
            return View(personalDetail);
        }


        [HttpPost, ActionName("deletetimeslot")]
        [ValidateAntiForgeryToken]
        public ActionResult deleteconfirm(int id)
        {
            Timetable personalDetail = db.Timetables.Find(id);
            db.Timetables.Remove(personalDetail);
            db.SaveChanges();
            return RedirectToAction("timetable");
        }
        public ActionResult datesheet()
        {
            return View();
        }
        [HttpGet]
        public ActionResult adddatesheet()
        {
            var Class1 = db.Courses.SqlQuery("SELECT * FROM dbo.Course").ToList();
            if (Class1 != null)
            {
                ViewBag.courses = Class1;
            }
            var Class = db.Classes.SqlQuery("SELECT * FROM dbo.Class").ToList();
            if (Class != null)
            {
                ViewBag.classes = Class;
            }
            return View();
        }
        [HttpPost]
        public ActionResult adddatesheet(Timetable c)
        {
            if (ModelState.IsValid)
            {
                db.Timetables.Add(c);
                db.SaveChanges();
                RedirectToAction("courses");
            }
            return View("courses");

        }
        public ActionResult datesheetlist()
        {
            return View(db.Datesheets.ToList());
        }
        [HttpGet]
        public ActionResult Deletedatesheet(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Datesheet personalDetail = db.Datesheets.Find(id);
            if (personalDetail == null)
            {
                return HttpNotFound();
            }
            return View(personalDetail);
        }


        [HttpPost, ActionName("Deletedatesheet")]
        [ValidateAntiForgeryToken]
        public ActionResult deleteconfrm(int id)
        {
            Datesheet personalDetail = db.Datesheets.Find(id);
            db.Datesheets.Remove(personalDetail);
            db.SaveChanges();
            return RedirectToAction("datesheet");
        }
        public ActionResult students()
        {

            return View();
        }
        public ActionResult studentlist()
        {
            return View(db.Students.ToList());
        }
    }
}