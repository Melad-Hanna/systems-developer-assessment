using NetC.JuniorDeveloperExam.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NetC.JuniorDeveloperExam.Web.Services
{
    public interface IBlogPostService
    {
        Post GetPostById(int id);
        Post AddComment(int postId, Comment comment);
        Post AddReplyToComment(int postId, int commentIndex, Comment comment);
        bool ValidateEmail(string emailAddress);
    }
}