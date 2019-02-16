using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Hyna.Models
{
    public class Service
    {
        [Required]
        public int ID { get; set; }
        [Required]
        public int Orderby { get; set; }
        [Required,StringLength(maximumLength:50)]
        public string Name { get; set; }
        [Required, StringLength(maximumLength: 250)]
        public string Icon { get; set; }
        [Required, StringLength(maximumLength: 100)]
        public string Description { get; set; }
        [Required, DataType("ntext")]
        public string Text { get; set; }
        [Required, StringLength(maximumLength: 250)]
        public string PDF { get; set; }
        [Required, StringLength(maximumLength: 250)]
        public string Document { get; set; }

        public int CategoryID { get; set; }

        public Category Category { get; set; }
    }
}