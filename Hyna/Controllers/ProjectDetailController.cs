using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hyna.DAL;
using Hyna.Models;


namespace Hyna.Controllers
{
    public class ProjectDetailController : Controller
    {
        // GET: ProjectDetail
        private readonly HynaContext db = new HynaContext();
        public ActionResult Index()
        {
            List<Project> projectDetail = db.Projects.ToList();
            return View(projectDetail);
        }
    }
}