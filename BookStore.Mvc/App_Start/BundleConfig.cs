using System.Web;
using System.Web.Optimization;

namespace BookStore.Mvc
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-3.1.1.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.min.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.min.css",
                      "~/Content/Site.css",
                       "~/Content/AdminLTE.min.css",
                      "~/Content/skin-blue.min.css"));

            bundles.Add(new ScriptBundle("~/bundles/js").Include(
                       "~/Scripts/app.min.js",
                       "~/Scripts/CustomScripts.js",
                       "~/Scripts/demo.js"));
        }
    }
}
