using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using Hyna.DAL;
using Hyna.Models;
using Hyna.ViewModel;
namespace Hyna.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        private readonly HynaContext db = new HynaContext();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Setting setting)
        {
            if (ModelState.IsValid)
            {
                Setting set = db.Settings.FirstOrDefault(a => a.Username == setting.Username);

                if (set != null)
                {
                    if (Crypto.VerifyHashedPassword(set.Password, set.Password))
                    {
                        Session["AdminLogin"] = true;
                        Session["AdminId"] = set.ID;
                        return RedirectToAction("index", "login");
                    }
                }

                ModelState.AddModelError("summary", "Email or password incorret");
            }

            return View(setting);
        }

    }
}