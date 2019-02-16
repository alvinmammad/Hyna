using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hyna.DAL;
using Hyna.Models;

namespace Hyna.Controllers
{
    public class BlogDetailController : Controller
    {
        private readonly HynaContext db = new HynaContext();
        // GET: BlogDetail
        public ActionResult Index()
        {
            List<Blog> blogdetail = db.Blogs.Include("Category").Include("Author").ToList();
            return View(blogdetail);
        }
    }
}