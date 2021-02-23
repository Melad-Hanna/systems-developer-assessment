using NetC.JuniorDeveloperExam.Web.Models;
using NetC.JuniorDeveloperExam.Web.Repositories;
using NetC.JuniorDeveloperExam.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NetC.JuniorDeveloperExam.Web.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogPostService _blogPostService;

        // Injecting the dependency "BlogPostService"
        public BlogController(IBlogPostService blogPostService)
        {
            _blogPostService = blogPostService;
        }

        // Get Call
        // 1- Returns a View for blog post 
        [HttpGet]
        public ActionResult Index(int id)
        {
            Post post = _blogPostService.GetPostById(id);
            if (post == null)
                return RedirectToAction("NotFound", "HttpErrors");
            return View(post);
        }

        // Post Call
        // 1- Recieves a post comment
        // 2- Call Service to save comment
        [HttpPost]
        public ActionResult Index(int id, Comment comment)
        {
            Post post = _blogPostService.GetPostById(id);
            if (ModelState.IsValid)
            {
                try
                {
                    var email = new System.Net.Mail.MailAddress(comment.emailAddress);
                    _blogPostService.AddComment(id, comment);
                }
                catch
                {
                    ModelState.AddModelError("emailAddress", "The email address is not a valid one.");
                }
            }
            return View(post);
        }
    }
}