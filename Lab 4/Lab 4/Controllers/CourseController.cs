using Lab_4.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab_4.Controllers
{
    public class CourseController : Controller
    {
        // GET: Course
        public ActionResult Index()
        {
            var db = new RegistrationEntities();
            var Cs = db.Courses.ToList();
            return View(Cs);
        }
        [HttpGet]
        public ActionResult AddCourse()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCourse(Cours st)
        {
            var db = new RegistrationEntities();
            db.Courses.Add(st);
            db.SaveChanges();
            return View();
        }
        [HttpGet]
        public ActionResult EditCourse(int id)
        {
            var db = new RegistrationEntities();
            var Course = (from b in db.Courses
                            where b.Id == id
                            select b).SingleOrDefault();
            return View(Course);
        }
        [HttpPost]
        public ActionResult EditCourse(Cours st)
        {


            var db = new RegistrationEntities();
            var ext = (from b in db.Courses
                       where b.Id == st.Id
                       select b).SingleOrDefault();

            db.Entry(ext).CurrentValues.SetValues(st);

            db.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var db = new RegistrationEntities();
            var product = db.Courses.Find(id);
            db.Courses.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}