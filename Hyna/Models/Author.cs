using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Hyna.Models
{
    public class Author
    {
        [Required]
        public int ID { get; set; }
        [Required,StringLength(maximumLength:50)]
        public string Fullname { get; set; }
        [Required, StringLength(maximumLength: 50)]
        public string Position { get; set; }
        [Required, StringLength(maximumLength: 250)]
        public string Photo { get; set; }
        [Required, StringLength(maximumLength: 250)]
        public string Description { get; set; }

        public List<Blog> Blogs { get; set; }

    }
}