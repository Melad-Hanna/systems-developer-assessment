using NetC.JuniorDeveloperExam.Web.Repositories;
using NetC.JuniorDeveloperExam.Web.Services;
using System.Web.Mvc;
using Unity;
using Unity.Injection;
using Unity.Mvc5;

namespace NetC.JuniorDeveloperExam.Web
{
    public static class UnityConfig
    {
        /// <summary>
        /// This class is used to Register the dependencies for DI
        /// </summary>
        public static void RegisterComponents()
        {
            var container = new UnityContainer();
            container.RegisterType<IBlogPostRepository, BlogPostRepository>();
            container.RegisterType<IBlogPostService, BlogPostService>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}