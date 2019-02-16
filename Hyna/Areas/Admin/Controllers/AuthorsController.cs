using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Hyna.DAL;
using Hyna.Models;

namespace Hyna.Areas.Admin.Controllers
{
    public class AuthorsController : Controller
    {
        private HynaContext db = new HynaContext();

        // GET: Admin/Authors
        public ActionResult Index()
        {
            return View(db.Authors.ToList());
        }

        // GET: Admin/Authors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Author author = db.Authors.Find(id);
            if (author == null)
            {
                return HttpNotFound();
            }
            return View(author);
        }

        // GET: Admin/Authors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Authors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Fullname,Position,Photo,Description")] Author author,HttpPostedFileBase Photo)
        {
            if (ModelState.IsValid)
            {
                string filename = DateTime.Now.ToString("yyyyMMddHHmmssfff") + Photo.FileName;
                string path = Path.Combine(Server.MapPath("~/Areas/Admin/Pics"), filename);
                Photo.SaveAs(path);
                author.Photo = filename;
                db.Authors.Add(author);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(author);
        }

        // GET: Admin/Authors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Author author = db.Authors.Find(id);
            if (author == null)
            {
                return HttpNotFound();
            }
            return View(author);
        }

        // POST: Admin/Authors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Fullname,Position,Photo,Description")] Author author,HttpPostedFileBase Photo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(author).State = EntityState.Modified;
                if (author == null)
                {
                    db.Entry(author).Property(a => a.Photo).IsModified = false;
                }
                else
                {
                    string photoname = DateTime.Now.ToString("yyyyMMddHHmmssfff") + Photo.FileName;
                    string path = Path.Combine(Server.MapPath("~/Areas/Admin/Pics"), photoname);
                    Photo.SaveAs(path);
                    author.Photo = photoname;
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(author);
        }

        // GET: Admin/Authors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Author author = db.Authors.Find(id);
            if (author == null)
            {
                return HttpNotFound();
            }
            return View(author);
        }

        // POST: Admin/Authors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Author author = db.Authors.Find(id);
            System.IO.File.Delete(Path.Combine(Server.MapPath("~/Areas/Admin/Pics"), author.Photo));
            db.Authors.Remove(author);
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
