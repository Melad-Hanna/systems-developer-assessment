using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NetC.JuniorDeveloperExam.Web.Models
{
    public class Comment
    {
        [Required]
        public string name { get; set; }
        public DateTime date { get; set; }
        [Required]
        public string emailAddress { get; set; }
        [Required]
        public string message { get; set; }
        public ICollection<Comment> replies { get; set; }
    }
}