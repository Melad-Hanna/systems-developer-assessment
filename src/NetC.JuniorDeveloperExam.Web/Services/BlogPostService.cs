using NetC.JuniorDeveloperExam.Web.Models;
using NetC.JuniorDeveloperExam.Web.Repositories;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NetC.JuniorDeveloperExam.Web.Services
{
    public class BlogPostService : IBlogPostService
    {
        /// <summary>
        /// This service represents Business Logic Layer 
        /// All Bussiness Logic should be included into this page
        /// </summary>

        // Injecting the repository into the service
        private readonly IBlogPostRepository _postRepository;
        public BlogPostService(IBlogPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        // This Method:
        // 1- Recieves a post id
        // 2- Call the repo method GetPostById to return required post
        public Post GetPostById(int id)
        {
            return _postRepository.GetBostById(id);
        }

        // This Method:
        // 1- Recieves a post comment with post Id
        // 2- Add comment to post's list of comments
        // 3- calls the repository to save the changes
        public Post AddComment(int postId, Comment comment)
        {
            List<Post> posts = _postRepository.GetAllPosts();
            comment.date = DateTime.Now;
            Post post = posts.FirstOrDefault(p => p.id == postId);
            if (post.comments == null)
                post.comments = new List<Comment>();
            post.comments.Add(comment);
            _postRepository.SavePosts(posts);
            return post;
        }

        // This Method:
        // 1- Recieves a reply on post's comment
        // 2- Add reply to comment's list of replies
        // 3- calls the repository to save the changes
        public Post AddReplyToComment(int postId, int commentIndex, Comment comment)
        {
            List<Post> posts = _postRepository.GetAllPosts();
            comment.date = DateTime.Now;
            Post post = posts.FirstOrDefault(p => p.id == postId);
            if (post.comments.ElementAt(commentIndex).replies == null)
                post.comments.ElementAt(commentIndex).replies = new List<Comment>();
            post.comments.ElementAt(commentIndex).replies.Add(comment);
            _postRepository.SavePosts(posts);
            return post;
        }


        // This method is used to validate the entered email
        public bool ValidateEmail(string emailAddress)
        {
            try
            {
                var email = new System.Net.Mail.MailAddress(emailAddress);
                return email.Address == emailAddress;
            }
            catch
            {
                return false;
            }
        }
    }
}