using System.Web;
using System.Web.Optimization;

namespace Bookstore.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/Vendors/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/vendors").Include(
               "~/Scripts/Vendors/jquery-{version}.js",
               "~/Scripts/Vendors/jquery.js",
               "~/Scripts/Vendors/bootstrap.js",
               "~/Scripts/Vendors/toastr.js",
               "~/Scripts/Vendors/jquery.raty.js",
               "~/Scripts/Vendors/respond.src.js",
               "~/Scripts/Vendors/angular.js",
               "~/Scripts/Vendors/angular-route.min.js",
               "~/Scripts/Vendors/angular-cookies.js",
               "~/Scripts/Vendors/angular-validator.js",
               "~/Scripts/Vendors/angular-base64.js",
               "~/Scripts/Vendors/angular-file-upload.js",
               "~/Scripts/Vendors/angucomplete-alt.min.js",
               "~/Scripts/Vendors/ui-bootstrap-tpls-0.13.1.js",
               "~/Scripts/Vendors/underscore.js",
               "~/Scripts/Vendors/raphael.js",
               "~/Scripts/Vendors/morris.js",
               "~/Scripts/Vendors/jquery.fancybox.js",
               "~/Scripts/Vendors/jquery.fancybox-media.js",
               "~/Scripts/Vendors/loading-bar.js",
               "~/Scripts/Vendors/js/app.min.js"
               ));

            bundles.Add(new ScriptBundle("~/bundles/spa").Include(
                "~/Scripts/Spa/Modules/core.js",
                "~/Scripts/Spa/Modules/ui.js",
                "~/Scripts/Spa/app.js",
                "~/Scripts/Spa/Services/apiService.js",
                "~/Scripts/Spa/Services/notificationService.js",
                "~/Scripts/Spa/Services/membershipService.js",
                "~/Scripts/Spa/Services/fileUploadService.js",
                "~/Scripts/Spa/Services/fileUploadService.js",
                "~/Scripts/Spa/Books/addBookController.js",
                "~/Scripts/Spa/Books/getBookController.js",
                "~/Scripts/Spa/Books/editBookController.js",
                "~/Scripts/Spa/Home/rootCtrl.js",
                "~/Scripts/Spa/Layout/mainSideBar.directive.js",
                "~/Scripts/Spa/Layout/mainHeader.directive.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/_all-skins.min.css",
                      "~/Content/AdminLTE.min.css"));
        }
    }
}
