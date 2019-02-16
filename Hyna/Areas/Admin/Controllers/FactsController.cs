using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Hyna.DAL;
using Hyna.Models;

namespace Hyna.Areas.Admin.Controllers
{
    public class FactsController : Controller
    {
        private HynaContext db = new HynaContext();

        // GET: Admin/Facts
        public ActionResult Index()
        {
            return View(db.Facts.OrderBy(f=>f.Orderby).ToList());
        }

        // GET: Admin/Facts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fact fact = db.Facts.Find(id);
            if (fact == null)
            {
                return HttpNotFound();
            }
            return View(fact);
        }

        // GET: Admin/Facts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Facts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Orderby,Key,Value")] Fact fact)
        {
            if (ModelState.IsValid)
            {
                db.Facts.Add(fact);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fact);
        }

        // GET: Admin/Facts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fact fact = db.Facts.Find(id);
            if (fact == null)
            {
                return HttpNotFound();
            }
            return View(fact);
        }

        // POST: Admin/Facts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Orderby,Key,Value")] Fact fact)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fact).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fact);
        }

        // GET: Admin/Facts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fact fact = db.Facts.Find(id);
            if (fact == null)
            {
                return HttpNotFound();
            }
            return View(fact);
        }

        // POST: Admin/Facts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Fact fact = db.Facts.Find(id);
            db.Facts.Remove(fact);
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
