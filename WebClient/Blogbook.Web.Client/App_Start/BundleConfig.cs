using System.Web.Optimization;

namespace Blogbook.Web.Client
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-1.12.3.min.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.min.js",
                      "~/Scripts/respond.js"
                      ));
            
            bundles.Add(new ScriptBundle("~/bundles/angularApp").Include(
                    "~/Scripts/Angular/angular.js",
                    "~/Scripts/Angular/angular-animate.min.js",
                    "~/Scripts/Angular/angular-aria.min.js",
                    "~/Scripts/Angular/angular-cookies.min.js",
                    "~/Scripts/Angular/angular-loader.min.js",
                    "~/Scripts/Angular/angular-message-format.min.js",
                    "~/Scripts/Angular/angular-messages.min.js",
                    "~/Scripts/Angular/angular-mocks.js",
                    "~/Scripts/Angular/angular-resource.min.js",
                    "~/Scripts/Angular/angular-route.min.js",
                    "~/Scripts/Angular/angular-sanitize.min.js",
                    "~/Scripts/Angular/angular-scenario.js",
                    "~/Scripts/Angular/angular-touch.min.js",
                    "~/Scripts/angular-ui-router.min.js",
                    "~/Scripts/angular-toastr.min.js",
                    "~/Scripts/jquery-ui.min.js",
                    "~/Scripts/modernizr-2.6.2.js",
                    "~/Scripts/ui-bootstrap-tpls-1.3.2.min.js",
                    "~/Scripts/satellizer.min.js",


                      "~/App/application.js",
                      "~/App/Routes/*.js",
                      "~/App/Service/*.js",
                      "~/App/Factory/*.js",
                      "~/App/Articles/article.controller.js",
                      "~/App/Home/home.controller.js",
                       "~/App/Blogs/blog.controller.js",
                       "~/App/User/*.js"

                      ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.min.css",
                      "~/Content/site.css",
                      "~/Content/navbar.css"
                      ));
        }
    }
}
