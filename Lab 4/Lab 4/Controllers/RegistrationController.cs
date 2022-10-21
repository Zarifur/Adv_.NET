using Lab_4.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab_4.Controllers
{
    public class RegistrationController : Controller
    {
        // GET: Registration
        [HttpGet]
        public ActionResult Index()
        {
            RegistrationEntities db = new RegistrationEntities();
            return View(db.Courses.ToList());
        }
        
        [HttpPost]
        public ActionResult Index(int[] courses)
        {
            RegistrationEntities db = new RegistrationEntities();
            foreach (var course in courses)
            {
                db.CouseStudents.Add(new CouseStudent()
                {
                    CourseId = course,
                    StudentId = 2
                });

            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}