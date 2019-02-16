using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Hyna.Models
{
    public class About
    {
        [Required]
        public int ID { get; set; }
        [Required,StringLength(maximumLength:250)]
        public string Title { get; set; }
        [Required,DataType("ntext")]
        public string Text { get; set; }
        [Required,StringLength(maximumLength:250)]
        public string Photo { get; set; }
    }
}