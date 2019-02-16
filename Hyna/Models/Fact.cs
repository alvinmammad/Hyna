using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Hyna.Models
{
    public class Fact
    {
        [Required]
        public int ID { get; set; }
        [Required]
        public int Orderby { get; set; }
        [Required,StringLength(maximumLength:250)]
        public string Key { get; set; }
        [Required, StringLength(maximumLength:50)]
        public string Value { get; set; }
    }
}