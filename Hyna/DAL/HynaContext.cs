using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Hyna.Models;

namespace Hyna.DAL
{
    public class HynaContext:DbContext
    {
        public HynaContext():base("HynaContext")
        {

        }

        public DbSet<About> Abouts { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Fact> Facts { get; set; }
        public DbSet<FAQ> FAQs { get; set; }
        public DbSet<FaqCategory> FaqCategories { get; set; }
        public DbSet<Partner> Partners { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectCategory> ProjectCategories { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Admin> Admins { get; set; }
    }
}