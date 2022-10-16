using Lab3.DB;
using Lab3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebGrease.Css.Ast.Selectors;

namespace Lab3.Controllers
{
    public class ProductsController : Controller
    {
        public object Products { get; private set; }

        // GET: Products
        public ActionResult Index()
        {
            var db = new bookEntities();
            var product = db.Products.ToList();
            return View(product);
        }
        [HttpGet]
        public ActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddProduct(Product pro)
        {
            var db = new bookEntities();
            db.Products.Add(pro);
            db.SaveChanges();
            return View();
        }
        public ActionResult Edit(int id)
        {
            var db = new bookEntities();
            var product = (from b in db.Products
                        where b.Id == id
                        select b).SingleOrDefault();
            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(Product pro)
        {
            var db = new bookEntities();
            //
            //db.Books.Find(book.Id);
            var ext = (from b in db.Products
                       where b.Id == pro.Id
                       select b).SingleOrDefault();
            //ext.Author = book.Author;
            //ext.Name = book.Name;
            //ext.Price = book.Price;
            //ext.Edition = book.Edition;

            db.Entry(ext).CurrentValues.SetValues(pro);

            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var db = new bookEntities();
            var product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

    }
}