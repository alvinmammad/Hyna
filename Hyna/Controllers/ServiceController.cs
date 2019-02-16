using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hyna.DAL;
using Hyna.Models;

namespace Hyna.Controllers
{
    public class ServiceController : Controller
    {
        // GET: Service
        private readonly HynaContext db = new HynaContext();
        public ActionResult Index()
        {
            List<Service> services = db.Services.ToList();
            ViewBag.Categories = db.Categories.ToList();
            return View(services);
        }
    }
}