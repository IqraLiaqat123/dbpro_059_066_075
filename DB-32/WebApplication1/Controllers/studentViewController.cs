using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using System.IO;

namespace WebApplication1.Controllers
{
    public class studentViewController : Controller
    {
        DB32Entities2 db = new DB32Entities2();
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
         
        public ActionResult Person()
        {
            return View(db.Students.SqlQuery("Exec studentInfo @add={0}, id").ToList());
        }
       /* public ActionResult ShowStudentList()
        {
            WebApplication1.Models.DB32Entities2 db = new WebApplication1.Models.DB32Entities2();
            //CrMVCApp.Models.Customer c;
            //var c = (Select b from b in db.person)
            //var c = (from b in db.PersonalInformation select b).ToList();
            StudentList rpt = new StudentList();
            rpt.Load();
            rpt.SetDataSource(c);
            Stream s = rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            return File(s, "application/pdf");
        }*/

    }
}