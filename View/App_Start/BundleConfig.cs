using System.Web;
using System.Web.Optimization;

namespace View
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/js/jquery-3.4.1.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/js/bootstrap.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/mdb").Include(
                      "~/js/mdb.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/fa").Include(
                      "~/js/all.js", "~/js/fontawesome.js"));

            bundles.Add(new StyleBundle("~/css/css").Include(
                      "~/css/bootstrap.css", 
                      "~/css/mdb.css", 
                      "~/css/style.css",
                      "~/css/Site.css",
                      "~/css/all.css",
                      "~/css/fontawesome.css"
                      ));
        }
    }
}
