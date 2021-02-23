using System.Web;
using System.Web.Optimization;

namespace NetC.JuniorDeveloperExam.Web
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Assets/Scripts/jquery-3.3.1.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Assets/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Assets/Scripts/bootstrap.bundle.min.js"));

            bundles.Add(new StyleBundle("~/Assets/Styles").Include(
                      "~/Assets/Styles/bootstrap.min.css",
                      "~/Assets/Styles/custom.css"));
        }
    }
}
