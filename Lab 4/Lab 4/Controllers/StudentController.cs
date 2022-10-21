using Lab_4.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab_4.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            var db = new RegistrationEntities();
            var student = db.Students.ToList();
            return View(student);
        }
        [HttpGet]
        public ActionResult AddStudent()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddStudent(Student st)
        {
            var db = new RegistrationEntities();
            db.Students.Add(st);
            db.SaveChanges();
            return View();
        }
        [HttpGet]
        public ActionResult EditStudent(int id)
        {
            var db = new RegistrationEntities();
            var Students = (from b in db.Students
                            where b.Id == id
                            select b).SingleOrDefault();
            return View(Students);
        }
        [HttpPost]
        public ActionResult EditStudent(Student st)
        {
 

            var db = new RegistrationEntities();
            var ext = (from b in db.Students
                       where b.Id == st.Id
                       select b).SingleOrDefault();

            db.Entry(ext).CurrentValues.SetValues(st);

            db.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult Delete (int id)
        {
            var db = new RegistrationEntities();
            var product = db.Students.Find(id);
            db.Students.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}