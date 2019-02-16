using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Hyna.Models
{
    public class Partner
    {
        [Required]
        public int ID { get; set; }
        [Required,StringLength(maximumLength:250)]
        public string URL { get; set; }
        [Required, StringLength(maximumLength:250)]
        public string Logo { get; set; }
    }
}