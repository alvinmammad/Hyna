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
    public class FAQController : Controller
    {
        // GET: FAQ
        private readonly HynaContext db = new HynaContext();
        public ActionResult Index()
        {
            Viewmodel vm = new Viewmodel
            {
                FAQs = db.FAQs.ToList(),
                FAQcategories = db.FaqCategories.ToList()
            };
            return View(vm);
        }
    }
}