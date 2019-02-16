using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Hyna.DAL;
using System.ComponentModel.DataAnnotations;

namespace Hyna.Models
{
    public class Admin
    {
        [Required]

        public int ID { get; set; }

        [Required,StringLength(maximumLength:30)]

        public string Username { get; set; }

        [Required, StringLength(maximumLength: 30)]

        public string Password { get; set; }

        [StringLength(maximumLength: 300)]

        public string Photo { get; set; }
    }
}