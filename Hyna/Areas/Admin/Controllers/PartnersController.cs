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
using System.IO;

namespace Hyna.Areas.Admin.Controllers
{
    public class PartnersController : Controller
    {
        private HynaContext db = new HynaContext();

        // GET: Admin/Partners
        public ActionResult Index()
        {
            return View(db.Partners.ToList());
        }

        // GET: Admin/Partners/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Partner partner = db.Partners.Find(id);
            if (partner == null)
            {
                return HttpNotFound();
            }
            return View(partner);
        }

        // GET: Admin/Partners/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Partners/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,URL,Logo")] Partner partner,HttpPostedFileBase Logo)
        {
            if (ModelState.IsValid)
            {
                string filename = DateTime.Now.ToString("yyyyMMddHHmmssfff") + Logo.FileName;
                string path = Path.Combine(Server.MapPath("~/Areas/Admin/Pics"), filename);
                Logo.SaveAs(path);
                partner.Logo = filename;
                db.Partners.Add(partner);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(partner);
        }

        // GET: Admin/Partners/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Partner partner = db.Partners.Find(id);
            if (partner == null)
            {
                return HttpNotFound();
            }
            return View(partner);
        }

        // POST: Admin/Partners/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,URL,Logo")] Partner partner,HttpPostedFileBase Logo)
        {
            if (ModelState.IsValid)
            {
                string filename = DateTime.Now.ToString("yyyyMMddHHmmssfff") + Logo.FileName;
                string path = Path.Combine(Server.MapPath("~/Areas/Admin/Pics"), filename);
                Logo.SaveAs(path);
                partner.Logo = filename;
                db.Entry(partner).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(partner);
        }

        // GET: Admin/Partners/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Partner partner = db.Partners.Find(id);
            if (partner == null)
            {
                return HttpNotFound();
            }
            return View(partner);
        }

        // POST: Admin/Partners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Partner partner = db.Partners.Find(id);
            System.IO.File.Delete(Path.Combine(Server.MapPath("~/Areas/Admin/Pics"), partner.Logo));
            db.Partners.Remove(partner);
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
