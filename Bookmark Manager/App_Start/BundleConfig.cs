using System.Web;
using System.Web.Optimization;

namespace Bookmark_Manager
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/bower_components/bootstrap-material-design/dist/js/ripples.js",
                      "~/bower_components/bootstrap-material-design/dist/js/material.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/bower_components/bootstrap-material-design/dist/css/roboto.css",
                      "~/bower_components/bootstrap-material-design/dist/css/material.css",
                      "~/bower_components/bootstrap-material-design/dist/css/ripples.css",
                      "~/Content/font-awesome.css",
                      "~/Content/site.css"));
        }
    }
}
