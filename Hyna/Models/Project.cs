using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Hyna.Models
{
    public class Project
    {
        public Project()
        {
            ProjectCategories = new HashSet<ProjectCategory>();
        }

        [Required]
        public int ID { get; set; }
        [Required,StringLength(maximumLength:500)]
        public string Name { get; set; }
        [Required,StringLength(maximumLength:250)]
        public string Photo { get; set; }
        [Required,StringLength(maximumLength:250),DataType("ntext")]
        public string Text { get; set; }
        [Required,StringLength(maximumLength:250)]
        public string Keyword { get; set; }

        public string ProjectList { get; set; }

        public ICollection<ProjectCategory> ProjectCategories { get; set; }
    }
}