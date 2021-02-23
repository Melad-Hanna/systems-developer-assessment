using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NetC.JuniorDeveloperExam.Web.Models
{
    public class Post
    {
        public int id { get; set; }
        public DateTime date { get; set; }
        public string title { get; set; }
        public string image { get; set; }
        public string htmlContent { get; set; }
        public ICollection<Comment> comments { get; set; }
    }
}