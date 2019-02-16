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
    public class SettingsController : Controller
    {
        private HynaContext db = new HynaContext();

        // GET: Admin/Settings
        public ActionResult Index()
        {
            return View(db.Settings.ToList());
        }

        // GET: Admin/Settings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Setting setting = db.Settings.Find(id);
            if (setting == null)
            {
                return HttpNotFound();
            }
            return View(setting);
        }

        // GET: Admin/Settings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Settings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Logo,Phone,Email,Address,Facebook,Instagram,Youtube,Lattitude,Photo,Longitude")] Setting setting , HttpPostedFileBase Logo , HttpPostedFileBase Photo)
        {
            if (ModelState.IsValid)
            {
                if (Logo != null)
                {
                    string filename = DateTime.Now.ToString("yyyyMMddHHmmssfff") + Logo.FileName;
                    string path = Path.Combine(Server.MapPath("~/Areas/Admin/Pics"), filename);
                    Logo.SaveAs(path);
                    setting.Logo= filename;
                }

                if (Photo != null)
                {
                    string filename = DateTime.Now.ToString("yyyyMMddHHmmssfff") + Photo.FileName;
                    string path = Path.Combine(Server.MapPath("~/Areas/Admin/Pics"), filename);
                    Photo.SaveAs(path);
                    setting.Photo= filename;
                }
                db.Settings.Add(setting);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(setting);
        }

        // GET: Admin/Settings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Setting setting = db.Settings.Find(id);
            if (setting == null)
            {
                return HttpNotFound();
            }
            return View(setting);
        }

        // POST: Admin/Settings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Logo,Phone,Email,Address,Facebook,Instagram,Youtube,Photo,Lattitude,Longitude")] Setting setting, HttpPostedFileBase Logo , HttpPostedFileBase Photo)
        {
            if (ModelState.IsValid)
            {
                if (Logo != null)
                {
                    string filename = DateTime.Now.ToString("yyyyMMddHHmmssfff") + Logo.FileName;
                    string path = Path.Combine(Server.MapPath("~/Areas/Admin/Pics"), filename);
                    Logo.SaveAs(path);
                    setting.Logo = filename;
                }

                if (Photo != null)
                {
                    string filename = DateTime.Now.ToString("yyyyMMddHHmmssfff") + Photo.FileName;
                    string path = Path.Combine(Server.MapPath("~/Areas/Admin/Pics"), filename);
                    Photo.SaveAs(path);
                    setting.Photo = filename;
                }
                db.Entry(setting).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(setting);
        }

        // GET: Admin/Settings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Setting setting = db.Settings.Find(id);
            if (setting == null)
            {
                return HttpNotFound();
            }
            return View(setting);
        }

        // POST: Admin/Settings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Setting setting = db.Settings.Find(id);
            System.IO.File.Delete(Path.Combine(Server.MapPath("~/Areas/Admin/Pics"), setting.Photo));
            System.IO.File.Delete(Path.Combine(Server.MapPath("~/Areas/Admin/Pics"), setting.Logo));
            db.Settings.Remove(setting);
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
