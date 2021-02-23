using NetC.JuniorDeveloperExam.Web.Models;
using NetC.JuniorDeveloperExam.Web.Repositories;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text.RegularExpressions;
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

        /// <summary>
        /// 1- Recieves a post comment with post Id
        /// 2- Add comment to post's list of comments
        /// 3- calls the repository to save the changes
        /// </summary>
        /// <param name="postId">Post Id</param>
        /// <param name="comment">Comment to be added</param>
        /// <returns>Updated Post Object</returns>
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

        /// <summary>
        /// 1- Recieves a reply on post's comment
        /// 2- Add reply to comment's list of replies
        /// 3- calls the repository to save the changes
        /// </summary>
        /// <param name="postId">Post Id</param>
        /// <param name="commentIndex">Comment Index in Lis of post's comments</param>
        /// <param name="comment">Reply to be added</param>
        /// <returns>Updated Post Object</returns>
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
                Regex regex = new Regex(@"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*"
                                    + "@"
                                    + @"((([\w]+([-\w]*[\w]+)*\.)+[a-zA-Z]+)|"
                                    + @"((([01]?[0-9]{1,2}|2[0-4][0-9]|25[0-5]).){3}[01]?[0-9]{1,2}|2[0-4][0-9]|25[0-5]))\z",
                         RegexOptions.CultureInvariant | RegexOptions.Singleline);
                return regex.IsMatch(emailAddress);
            }
            catch
            {
                return false;
            }
        }
    }
}