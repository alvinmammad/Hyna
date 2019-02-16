using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hyna.DAL;
using Hyna.Models;
using Hyna.ViewModel;


namespace Hyna.Controllers
{
    public class AboutController : Controller
    {
        private readonly HynaContext db = new HynaContext();
        // GET: About
        public ActionResult Index()
        {
            Viewmodel vm = new Viewmodel
            {
                Abouts = db.Abouts.ToList(),
                Partners = db.Partners.ToList(),
                Facts = db.Facts.ToList()
                
            };
            return View(vm);
        }
    }
}