using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Hyna.Models
{
    public class Blog
    {
        [Required]
        public int ID { get; set; }
        [Required,StringLength(maximumLength:1000)]
        public string Title { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required,StringLength(maximumLength:1000)]
        public string Description { get; set; }
        [Required,StringLength(maximumLength:250)]
        public string Photo { get; set; }
        [Required,DataType("ntext")]
        public string Text { get; set; }
        [Required]
        public int AuthorID { get; set; }
        [Required]
        public int CategoryID { get; set; }
        public Author Author { get; set; }
        public Category Category { get; set; }
    }
}