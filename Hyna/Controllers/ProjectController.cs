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
    public class ProjectController : Controller
    {
        // GET: Project
        private readonly HynaContext db = new HynaContext();
        public ActionResult Index()
        {
            Viewmodel vm = new Viewmodel
            {
                Projects = db.Projects.ToList(),
                Categories = db.Categories.ToList(),
                ProjectCategory = db.ProjectCategories.ToList()
            };
            return View(vm);
        }
    }
}