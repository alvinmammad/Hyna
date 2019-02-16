using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hyna.Models;
using Hyna.DAL;

namespace Hyna.Controllers
{
    public class ContactController : Controller
    {
        private readonly HynaContext db = new HynaContext();
        // GET: Contact
        public ActionResult Index()
        {
            List<Setting> settings = db.Settings.ToList();
            
            return View(settings);
        }
    }
}