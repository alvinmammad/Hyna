using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Hyna.Models
{
    public class ProjectCategory
    {
        [Required]
        public int ID { get; set; }
        [Required]
        public int CategoryID { get; set; }
        [Required]
        public int ProjectID { get; set; }

        public Category Category { get; set;}

        public Project Project { get; set; }


    }
}