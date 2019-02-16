using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hyna.Models;
using Hyna.DAL;
using Hyna.ViewModel;


namespace Hyna.Controllers
{
    public class HomeController : Controller
    {
        private readonly HynaContext db = new HynaContext();
        // GET: Home
        public ActionResult Index()
        {
            Viewmodel vm = new Viewmodel
            {
                Sliders = db.Sliders.ToList(),
                Services = db.Services.ToList(),
                Projects = db.Projects.ToList(),
                Categories = db.Categories.ToList(),
                ProjectCategory = db.ProjectCategories.ToList(),
                FAQs = db.FAQs.Take(4).ToList(),
                FAQcategories = db.FaqCategories.ToList(),
                Facts = db.Facts.ToList(),
                Blogs = db.Blogs.ToList(),
                Partners = db.Partners.ToList(),
                Authors=db.Authors.ToList()
                
            };
            return View(vm);
        }
    }
}