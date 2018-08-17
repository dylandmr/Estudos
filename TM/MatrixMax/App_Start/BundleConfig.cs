using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace MatrixMax.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/bundles/css")
                .Include(
                "~/Content/Css/normalize.css",
                "~/Content/Css/bootstrap.min.css",
                "~/Content/Css/font-awesome.min.css",
                "~/Content/Css/themify-icons.css",
                "~/Content/Css/flag-icon.min.css",
                "~/Content/Css/cs-skin-elastic.css",
                "~/Content/scss/style.css",
                "~/Content/Css/lib/vector-map/jqvmap.min.css"));

            bundles.Add(new ScriptBundle("~/bundles/js")
                .Include(
                "~/Content/js/vendor/jquery-2.1.4.min.js",
                "~/Content/js/plugins.js",
                "~/Content/js/main.js",
                "~/Content/js/lib/chart-js/Chart.bundle.js",
                "~/Content/js/dashboard.js",
                "~/Content/js/widgets.js",
                "~/Content/js/lib/vector-map/jquery.vmap.js",
                "~/Content/js/lib/vector-map/jquery.vmap.min.js",
                "~/Content/js/lib/vector-map/jquery.vmap.sampledata.js",
                "~/Content/js/lib/vector-map/country/jquery.vmap.world.js"));
        }
    }
}