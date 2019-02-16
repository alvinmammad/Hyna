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
    public class BlogsController : Controller
    {
        private HynaContext db = new HynaContext();

        // GET: Admin/Blogs
        public ActionResult Index()
        {
            var blogs = db.Blogs.Include(b => b.Author).Include(b => b.Category);
            return View(blogs.ToList());
        }

        // GET: Admin/Blogs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // GET: Admin/Blogs/Create
        public ActionResult Create()
        {
            ViewBag.AuthorID = new SelectList(db.Authors, "ID", "Fullname");
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Name");
            return View();
        }

        // POST: Admin/Blogs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Title,Date,Description,Photo,Text,AuthorID,CategoryID")] Blog blog,HttpPostedFileBase Photo)
        {
            if (ModelState.IsValid)
            {
                string filename = DateTime.Now.ToString("yyyyMMddHHmmssfff") + Photo.FileName;
                string path = Path.Combine(Server.MapPath("~/Areas/Admin/Pics"), filename);
                Photo.SaveAs(path);
                blog.Photo = filename;
                db.Blogs.Add(blog);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AuthorID = new SelectList(db.Authors, "ID", "Fullname", blog.AuthorID);
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Name", blog.CategoryID);
            return View(blog);
        }

        // GET: Admin/Blogs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            ViewBag.AuthorID = new SelectList(db.Authors, "ID", "Fullname", blog.AuthorID);
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Name", blog.CategoryID);
            return View(blog);
        }

        // POST: Admin/Blogs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,Date,Description,Photo,Text,AuthorID,CategoryID")] Blog blog,HttpPostedFileBase Photo)
        {
            if (ModelState.IsValid)
            {
                string filename = DateTime.Now.ToString("yyyyMMddHHmmssfff") + Photo.FileName;
                string path = Path.Combine(Server.MapPath("~/Areas/Admin/Pics"), filename);
                Photo.SaveAs(path);
                blog.Photo = filename;
                db.Entry(blog).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AuthorID = new SelectList(db.Authors, "ID", "Fullname", blog.AuthorID);
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Name", blog.CategoryID);
            return View(blog);
        }

        // GET: Admin/Blogs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // POST: Admin/Blogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Blog blog = db.Blogs.Find(id);
            System.IO.File.Delete(Path.Combine(Server.MapPath("~/Areas/Admin/Pics"), blog.Photo));
            db.Blogs.Remove(blog);
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
