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
    public class ServicesController : Controller
    {
        private HynaContext db = new HynaContext();

        // GET: Admin/Services
        public ActionResult Index()
        {
            var services = db.Services.Include(s => s.Category);
            return View(services.ToList());
        }

        // GET: Admin/Services/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Service service = db.Services.Find(id);
            if (service == null)
            {
                return HttpNotFound();
            }
            return View(service);
        }

        // GET: Admin/Services/Create
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Name");
            return View();
        }

        // POST: Admin/Services/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Orderby,Name,Icon,Description,Text,PDF,Document,CategoryID")] Service service , HttpPostedFileBase Icon)
        {
            if (ModelState.IsValid)
            {
                string iconName = DateTime.Now.ToString("yyyyMMddHHmmssfff") + Icon.FileName;

                string path = Path.Combine(Server.MapPath("~/Areas/Admin/Pics"), iconName);
              

                
                Icon.SaveAs(path);

                //service.Photo = photoName;
                service.Icon= iconName;

                db.Services.Add(service);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Name", service.CategoryID);
            return View(service);
        }

        // GET: Admin/Services/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Service service = db.Services.Find(id);
            if (service == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Name", service.CategoryID);
            return View(service);
        }

        // POST: Admin/Services/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Orderby,Name,Icon,Description,Text,PDF,Document,CategoryID")] Service service, HttpPostedFileBase Icon )
        {
            if (ModelState.IsValid)
            {
               
                string iconName = DateTime.Now.ToString("yyyyMMddHHmmssfff") + Icon.FileName;

                string path = Path.Combine(Server.MapPath("~/Areas/Admin/Pics"), iconName);
                Icon.SaveAs(path);
               

                //service.Photo = photoName;
                service.Icon = iconName;
                db.Entry(service).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Name", service.CategoryID);
            return View(service);
        }

        // GET: Admin/Services/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Service service = db.Services.Find(id);
            if (service == null)
            {
                return HttpNotFound();
            }
            return View(service);
        }

        // POST: Admin/Services/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Service service = db.Services.Find(id);
            System.IO.File.Delete(Path.Combine(Server.MapPath("~/Areas/Admin/Pics"), service.Icon));
            db.Services.Remove(service);
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
