using System.Web;
using System.Web.Optimization;

namespace Employees
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/lib").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/bootstrap.js",
                        "~/scripts/bootbox.js",
                        "~/Scripts/respond.js",
                        "~/scripts/datatables/jquery.datatables.js",
                        "~/scripts/datatables/datatables.bootstrap.js",
                        "~/scripts/kendo/kendo.all.min.js",
                        "~/scripts/kendo/jszip.min.js"
                      ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/content/datatables/css/datatables.bootstrap.css",
                      "~/Content/kendo.default.min.css",
                      "~/Content/kendo.common.min.css", 
                      "~/Content/kendo.rtl.min.css", 
                      "~/Content/kendo.default.mobile.min.css"
                      ));
        }
    }
}
