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
                "~/Content/Css/lib/vector-map/jqvmap.min.css",
                "~/Content/Css/lib/datatable/dataTables.bootstrap.min.css",
                "~/Content/Css/lib/datatable/select.bootstrap4.min.css"));

            bundles.Add(new ScriptBundle("~/bundles/js")
                .Include(
                "~/Content/js/vendor/jquery-2.1.4.min.js",
                "~/Content/js/vendor/jquery.form.min.js",
                "~/Content/js/plugins.js",
                "~/Content/js/main.js",
                "~/Content/js/lib/chart-js/Chart.bundle.js",
                "~/Content/js/dashboard.js",
                "~/Content/js/widgets.js",
                "~/Content/js/lib/vector-map/jquery.vmap.js",
                "~/Content/js/lib/vector-map/jquery.vmap.min.js",
                "~/Content/js/lib/vector-map/jquery.vmap.sampledata.js",
                "~/Content/js/lib/vector-map/country/jquery.vmap.world.js"));

            bundles.Add(new ScriptBundle("~/bundles/tables/js")
                .Include(
                "~/Content/js/lib/data-table/datatables.min.js",
                "~/Content/js/lib/data-table/dataTables.bootstrap.min.js",
                "~/Content/js/lib/data-table/dataTables.buttons.min.js",
                "~/Content/js/lib/data-table/buttons.bootstrap.min.js",
                "~/Content/js/lib/data-table/jszip.min.js",
                "~/Content/js/lib/data-table/pdfmake.min.js",
                "~/Content/js/lib/data-table/vfs_fonts.js",
                "~/Content/js/lib/data-table/buttons.html5.min.js",
                "~/Content/js/lib/data-table/buttons.print.min.js",
                "~/Content/js/lib/data-table/buttons.colVis.min.js",
                "~/Content/js/lib/data-table/dataTables.select.min.js",
                "~/Content/js/lib/data-table/datatables-init.js"));
        }
    }
}