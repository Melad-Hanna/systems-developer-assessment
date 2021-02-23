using NetC.JuniorDeveloperExam.Web.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace NetC.JuniorDeveloperExam.Web.Repositories
{
    /// <summary>
    /// This Repo Represents the data access layer
    /// It handles file read or write operation
    /// </summary>
    public class BlogPostRepository : IBlogPostRepository
    {
        // Connection to the json file
        public string JsonFilePath
        {
            get
            {
                return HttpContext.Current.Server.MapPath("~/App_Data/Blog-Posts.json");
            }
        }

        /// <summary>
        /// 1- Reads the json file
        /// 2- convert json object to a list of post and returns it
        /// </summary>
        /// <returns>List of All Posts</returns>
        public List<Post> GetAllPosts()
        {
            List<JToken> blogPostsJToken;
            List<Post> blogPosts = new List<Post>();
            using (StreamReader r = new StreamReader(this.JsonFilePath))
            {
                string blogPostsJSON = r.ReadToEnd();
                blogPostsJToken = JsonConvert.DeserializeObject<JObject>(blogPostsJSON)["blogPosts"].Children().ToList();
            }
            foreach (JToken blogPostJToken in blogPostsJToken)
                blogPosts.Add(blogPostJToken.ToObject<Post>());
            return blogPosts;
        }

        /// <summary>
        /// 1- This Method Recieves Post id and returns Post
        /// </summary>
        /// <returns>Post Object</returns>
        public Post GetBostById(int id)
        {
            return GetAllPosts().FirstOrDefault(p => p.id == id);
        }

        /// <summary>
        /// 1- receives a list of post object and serialize it to json string 
        /// 2- saves the serialized string to json file
        /// </summary>
        public void SavePosts(List<Post> posts)
        {
            var blogPosts = new
            {
                blogPosts = posts
            };
            var postsJson = JsonConvert.SerializeObject(blogPosts, Formatting.Indented);
            using (var writer = new StreamWriter(JsonFilePath))
            {
                writer.Write(postsJson);
            }
        }
    }
}