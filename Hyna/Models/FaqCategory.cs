using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Hyna.Models
{
    public class FaqCategory
    {
        [Required]
        public int ID { get; set; }
        [Required,StringLength(maximumLength:50)]
        public string Name { get; set; }

        public List<FAQ> FAQs { get; set; }
    }
}