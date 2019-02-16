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
    public class ServiceDetailController : Controller
    {
        // GET: ServiceDetail4
        private readonly HynaContext db = new HynaContext();
        public ActionResult Index()
        {
            List<Service> serviceDetails = db.Services.Include("Category").ToList();
           
            return View(serviceDetails);
        }
    }
}