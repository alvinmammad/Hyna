using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Hyna.Models
{
    public class FAQ
    {
        [Required]
        public int ID { get; set; }
        [Required,StringLength(maximumLength:200)]
        public string Question { get; set; }
        [Required, StringLength(maximumLength: 200)]
        public string Answer { get; set; }
        [Required]
        public int CategoryID { get; set; }

        public Category Category { get; set; }

    }
}