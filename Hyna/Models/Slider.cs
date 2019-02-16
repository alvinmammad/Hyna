using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Hyna.Models
{
    public class Slider
    {
        [Required]
        public int ID { get; set; }
        [Required,StringLength(maximumLength:250)]
        public string Title { get; set; }
        [Required, StringLength(maximumLength: 250)]
        public string Slogan { get; set; }
        [Required, StringLength(maximumLength:50)]
        public string ButtonText { get; set; }
        [Required, StringLength(maximumLength: 250)]
        public string ButtonURL { get; set; }
    }
}