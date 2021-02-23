using NetC.JuniorDeveloperExam.Web.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NetC.JuniorDeveloperExam.Web.Repositories
{
    public interface IBlogPostRepository
    {
        string JsonFilePath { get; }
        List<Post> GetAllPosts();
        Post GetBostById(int id);
        void SavePosts(List<Post> posts);
    }
}