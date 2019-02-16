using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hyna.DAL;
using Hyna.Models;

namespace Hyna.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        private readonly HynaContext db = new HynaContext();
        public ActionResult Index()
        {
            List<Blog> blogs = db.Blogs.Include("Category").Include("Author").ToList();
            return View(blogs);
        }
    }
}