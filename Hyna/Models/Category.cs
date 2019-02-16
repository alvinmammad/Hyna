using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Hyna.Models
{
    public class Category
    {
        [Required]
        public int ID { get; set; }
        [Required,StringLength(maximumLength:25)]
        public string Name { get; set; }

        public List<Blog> Blogs { get; set; }
        public List<Service> Services { get; set; }
        public List<ProjectCategory> ProjectCategories { get; set; }
    }
}