using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Hyna.DAL;
using Hyna.Models;

namespace Hyna.ViewModel
{
    public class Viewmodel
    {
        public List<Project> Projects { get; set; }
        public List<Category> Categories { get; set; }
        public List<Blog> Blogs{ get; set; }
        public List<Partner> Partners { get; set; }
        public List<About> Abouts { get; set; }
        public List<Fact> Facts { get; set; }
        public List<ProjectCategory> ProjectCategory { get; set; }
        public List<FAQ> FAQs { get; set; }
        public List<FaqCategory> FAQcategories { get; set; }
        public List<Service> Services{ get; set; }
        public List<Setting> Settings{ get; set; }
        public List<Slider> Sliders { get; set; }
        public List<Author> Authors { get; set; }
        public List<Admin> Admins { get; set; }


    }
}