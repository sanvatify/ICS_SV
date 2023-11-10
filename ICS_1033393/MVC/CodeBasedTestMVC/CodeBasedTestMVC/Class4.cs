using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CodeBasedTestMVC
{
    public class Movie
    {
        [Key]
        public int Mid { get; set; }
        [Required]
        public string MovieName { get; set; }
        [Required]
        public DateTime DateOfRelease { get; set; }
    }
}