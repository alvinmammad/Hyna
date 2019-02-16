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
    public class ProjectCategoriesController : Controller
    {
        private HynaContext db = new HynaContext();

        // GET: Admin/ProjectCategories
        public ActionResult Index()
        {
            var projectCategories = db.ProjectCategories.Include(p => p.Category).Include(p => p.Project);
            return View(projectCategories.ToList());
        }

        // GET: Admin/ProjectCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectCategory projectCategory = db.ProjectCategories.Find(id);
            if (projectCategory == null)
            {
                return HttpNotFound();
            }
            return View(projectCategory);
        }

        // GET: Admin/ProjectCategories/Create
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Name");
            ViewBag.ProjectID = new SelectList(db.Projects, "ID", "Name");
            return View();
        }

        // POST: Admin/ProjectCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CategoryID,ProjectID")] ProjectCategory projectCategory)
        {
            if (ModelState.IsValid)
            {
                db.ProjectCategories.Add(projectCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Name", projectCategory.CategoryID);
            ViewBag.ProjectID = new SelectList(db.Projects, "ID", "Name", projectCategory.ProjectID);
            return View(projectCategory);
        }

        // GET: Admin/ProjectCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectCategory projectCategory = db.ProjectCategories.Find(id);
            if (projectCategory == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Name", projectCategory.CategoryID);
            ViewBag.ProjectID = new SelectList(db.Projects, "ID", "Name", projectCategory.ProjectID);
            return View(projectCategory);
        }

        // POST: Admin/ProjectCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CategoryID,ProjectID")] ProjectCategory projectCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(projectCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Name", projectCategory.CategoryID);
            ViewBag.ProjectID = new SelectList(db.Projects, "ID", "Name", projectCategory.ProjectID);
            return View(projectCategory);
        }

        // GET: Admin/ProjectCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectCategory projectCategory = db.ProjectCategories.Find(id);
            if (projectCategory == null)
            {
                return HttpNotFound();
            }
            return View(projectCategory);
        }

        // POST: Admin/ProjectCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProjectCategory projectCategory = db.ProjectCategories.Find(id);
            db.ProjectCategories.Remove(projectCategory);
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
