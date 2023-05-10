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
    public class OController : Controller
    {
        private ShoppingEntities2 db = new ShoppingEntities2();

        // GET: O
        public ActionResult Index()
        {
            var oTables = db.OTables.Include(o => o.CustomerTable).Include(o => o.ProductTable1);
            return View(oTables.ToList());
        }

        // GET: O/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OTable oTable = db.OTables.Find(id);
            if (oTable == null)
            {
                return HttpNotFound();
            }
            return View(oTable);
        }

        // GET: O/Create
        public ActionResult Create()
        {
            ViewBag.CName = new SelectList(db.CustomerTables, "CID", "CName");
            ViewBag.PName = new SelectList(db.ProductTable1, "PID", "PName");
            return View();
        }

        // POST: O/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OID,PName,CName,Quantity,Total_Price")] OTable oTable)
        {
            if (ModelState.IsValid)
            {
                db.OTables.Add(oTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CName = new SelectList(db.CustomerTables, "CID", "CName", oTable.CName);
            ViewBag.PName = new SelectList(db.ProductTable1, "PID", "PName", oTable.PName);
            return View(oTable);
        }

        // GET: O/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OTable oTable = db.OTables.Find(id);
            if (oTable == null)
            {
                return HttpNotFound();
            }
            ViewBag.CName = new SelectList(db.CustomerTables, "CID", "CName", oTable.CName);
            ViewBag.PName = new SelectList(db.ProductTable1, "PID", "PName", oTable.PName);
            return View(oTable);
        }

        // POST: O/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OID,PName,CName,Quantity,Total_Price")] OTable oTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(oTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CName = new SelectList(db.CustomerTables, "CID", "CName", oTable.CName);
            ViewBag.PName = new SelectList(db.ProductTable1, "PID", "PName", oTable.PName);
            return View(oTable);
        }

        // GET: O/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OTable oTable = db.OTables.Find(id);
            if (oTable == null)
            {
                return HttpNotFound();
            }
            return View(oTable);
        }

        // POST: O/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OTable oTable = db.OTables.Find(id);
            db.OTables.Remove(oTable);
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
