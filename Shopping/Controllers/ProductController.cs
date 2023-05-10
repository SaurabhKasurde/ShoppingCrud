using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Shopping.Models;

namespace Shopping.Controllers
{
    public class ProductController : Controller
    {
        private ShoppingEntities2 db = new ShoppingEntities2();

        // GET: Product
        public ActionResult Index()
        {
            return View(db.ProductTable1.ToList());
        }

        // GET: Product/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductTable1 productTable1 = db.ProductTable1.Find(id);
            if (productTable1 == null)
            {
                return HttpNotFound();
            }
            return View(productTable1);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PID,PName,Category,Price,Brand")] ProductTable1 productTable1)
        {
            if (ModelState.IsValid)
            {
                db.ProductTable1.Add(productTable1);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(productTable1);
        }

        // GET: Product/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductTable1 productTable1 = db.ProductTable1.Find(id);
            if (productTable1 == null)
            {
                return HttpNotFound();
            }
            return View(productTable1);
        }

        // POST: Product/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PID,PName,Category,Price,Brand")] ProductTable1 productTable1)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productTable1).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(productTable1);
        }

        // GET: Product/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductTable1 productTable1 = db.ProductTable1.Find(id);
            if (productTable1 == null)
            {
                return HttpNotFound();
            }
            return View(productTable1);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ProductTable1 productTable1 = db.ProductTable1.Find(id);
            db.ProductTable1.Remove(productTable1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
