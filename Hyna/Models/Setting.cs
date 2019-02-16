using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hyna.Models
{
    public class Setting
    {
        [Required]

        public int ID { get; set; }

        [StringLength(maximumLength:250)]

        public string Logo { get; set; }

        [StringLength(maximumLength: 11)]

        public string Phone { get; set; }

        [ StringLength(maximumLength: 50)]

        public string Email { get; set; }

         [StringLength(maximumLength: 250)]

        public string Address { get; set; }

        [ StringLength(maximumLength: 250)]

        public string Facebook { get; set; }

        [ StringLength(maximumLength: 250)]

        public string Instagram { get; set; }

        [ StringLength(maximumLength: 250)]

        public string Youtube { get; set; }

        [ StringLength(maximumLength: 20)]

        public string Lattitude { get; set; } 

        [ StringLength(maximumLength: 20)]

        public string Longitude { get; set; }

        public string Photo { get; set; }
        [Required , StringLength(maximumLength:30)]
        public string Username { get; set; }
        [Required, StringLength(maximumLength: 30)]

        public string Password { get; set; }
        [Required, StringLength(maximumLength: 250)]

        public string AdminPhoto { get; set; }


    }
}