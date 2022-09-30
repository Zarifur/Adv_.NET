using Lab2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab2.Controllers
{
    public class VaccineController : Controller
    {
        // GET: Vaccine
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Regiestation()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Regiestation(User user)
        {
            return View(user);
        }
    }
}