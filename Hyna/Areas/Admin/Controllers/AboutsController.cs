using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Hyna.DAL;
using System.IO;
using Hyna.Models;

namespace Hyna.Areas.Admin.Controllers
{
    public class AboutsController : Controller
    {
        private HynaContext db = new HynaContext();

        // GET: Admin/Abouts
        public ActionResult Index()
        {
            return View(db.Abouts.ToList());
        }

        // GET: Admin/Abouts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            About about = db.Abouts.Find(id);
            if (about == null)
            {
                return HttpNotFound();
            }
            return View(about);
        }

        // GET: Admin/Abouts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Abouts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Title,Text,Photo")] About about, HttpPostedFileBase Photo)
        {
            if (ModelState.IsValid)
            {
                string filename = DateTime.Now.ToString("yyyyMMddHHmmssfff") + Photo.FileName;
                string path = Path.Combine(Server.MapPath("~/Areas/Admin/Pics"), filename);
                Photo.SaveAs(path);
                about.Photo = filename;
                db.Abouts.Add(about);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(about);
        }

        // GET: Admin/Abouts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            About about = db.Abouts.Find(id);
            //if (about == null)
            //{
            //    return HttpNotFound();
            //}
            return View(about);
        }

        // POST: Admin/Abouts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,Text,Photo")] About about,HttpPostedFileBase Photo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(about).State = EntityState.Modified;
                if (about==null)
                {
                    db.Entry(about).Property(a => a.Photo).IsModified = false;
                }
                else
                {
                    string photoname = DateTime.Now.ToString("yyyyMMddHHmmssfff") + Photo.FileName;
                    string path = Path.Combine(Server.MapPath("~/Areas/Admin/Pics"), photoname);
                    Photo.SaveAs(path);
                    about.Photo = photoname;
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(about);
        }

        // GET: Admin/Abouts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            About about = db.Abouts.Find(id);
            if (about == null)
            {
                return HttpNotFound();
            }
            return View(about);
        }

        // POST: Admin/Abouts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            About about = db.Abouts.Find(id);
            System.IO.File.Delete(Path.Combine(Server.MapPath("~/Areas/Admin/Pics"), about.Photo));
            db.Abouts.Remove(about);
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
