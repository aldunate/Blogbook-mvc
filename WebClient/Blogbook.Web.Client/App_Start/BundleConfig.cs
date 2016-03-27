using System.Web.Optimization;

namespace Blogbook.Web.Client
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.min.js",
                      "~/Scripts/respond.js"
                      ));
            
            bundles.Add(new ScriptBundle("~/bundles/angularApp").Include(
                      "~/Scripts/Angular1.4.9/angular.min.js",
                      "~/Scripts/Angular1.4.9/angular-route.min.js",
                      "~/Scripts/Angular1.4.9/angular-resource.min.js",
                      "~/Scripts/Angular1.4.9/angular-animate.min.js",
                      "~/Scripts/Angular1.4.9/ui-bootstrap-tpls-1.1.2.min.js",
                      "~/Scripts/angular-ui-router2.18.min.js",

                      "~/App/application.js",
                      "~/App/Articles/*.js",
                      "~/App/Articles/article.controller.js",
                      "~/App/Home/*.js",
                      "~/App/Blogs/blog.routes.js",
                      "~/App/Blogs/blog.service.js",
                      "~/App/Blogs/blog.controller.js",
                      "~/App/User/*.js"

                      ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
        }
    }
}
