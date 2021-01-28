using System.Web;
using System.Web.Optimization;

namespace UniversityBuildings
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery-ui-1.12.1.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*",
                        "~/Scripts/jquery.validate.unobtrusive.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/ajax").Include(
                        "~/Scripts/jquery.unobtrusive-ajax.min.js"
                        ));
            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"
                      ));

            bundles.Add(new ScriptBundle("~/bundles/uijs").Include(
                      "~/Scripts/jquery-ui-1.12.1.min.js"
                      ));

            bundles.Add(new ScriptBundle("~/bundles/tneen").Include(
                      "~/Content/ComponentMaster/js/tneen.js"
                      ));

            bundles.Add(new ScriptBundle("~/bundles/scripts").Include(
                      "~/Content/ComponentMaster/lib/jquery/jquery.min.js",
                      "~/Content/ComponentMaster/lib/jquery/jquerymigrate.min.js",
                      "~/Content/ComponentMaster/lib/bootstrap/js/bootstrap.bundle.min.js",
                      "~/Content/ComponentMaster/lib/bootstrap/js/bootstrap.min.js",
                      "~/Content/ComponentMaster/lib/easing/easing.js",
                      "~/Content/ComponentMaster/lib/superfish/hoverIntent.js",
                      "~/Content/ComponentMaster/lib/superfish/superfish.js",
                      "~/Content/ComponentMaster/lib/wow/wow.js",
                      "~/Content/ComponentMaster/lib/owlcarousel/owl.carousel.js",
                      "~/Content/ComponentMaster/lib/magnific-popup/magnificpopup.min.js",
                      "~/Content/ComponentMaster/lib/sticky/sticky.js",
                      "~/Content/ComponentMaster/js/main.js"
                      ));

            bundles.Add(new StyleBundle("~/bundles/styles").Include(
                      "~/Content/ComponentMaster/lib/bootstrap/css/bootstrap.min.css",
                      "~/Content/ComponentMaster/lib/font-awesome/css/fontawesome.css",
                      "~/Content/ComponentMaster/lib/animate/animate.min.css",
                      "~/Content/ComponentMaster/lib/ionicons/css/ionicons.min.css",
                      "~/Content/ComponentMaster/lib/owlcarousel/assets/owl.carousel.min.css",
                      "~/Content/ComponentMaster/lib/magnific-popup/magnificpopup.css",
                      "~/Content/ComponentMaster/lib/ionicons/css/ionicons.css",
                      "~/Content/ComponentMaster/css/style.css",
                      "~/Content/ComponentMaster/css/Mine.css"
                      ));

            bundles.Add(new StyleBundle("~/bundles/menu").Include(
                      "~/Content/themes/base/menu.css"
                      ));

            bundles.Add(new StyleBundle("~/bundles/uimin").Include(
                      "~/Content/themes/base/jquery-ui.min.css"
                      ));
        }
    }
}
