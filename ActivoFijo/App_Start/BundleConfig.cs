using System.Web;
using System.Web.Optimization;

namespace ActivoFijo
{
    public class BundleConfig
    {
        // Para obtener más información sobre las uniones, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new Bundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new Bundle("~/bundles/complementos").Include(
                        "~/Scripts/fontawesome/all.min.js",
                        "~/Scripts/DataTables/jquery.dataTables.js",
                        "~/Scripts/DataTables/dataTables.responsive.js",
                        "~/Scripts/loadingoverlay/loadingoverlay.min.js",
                        "~/Scripts/sweetalert.min.js",
                        "~/Script/Botones/jquery.dataTables.min.js",
                        "~/Script/Botones/jquery.min.js",
                        "~/Script/Botones/jquery.dataTables2.min.js",
                        "~/Script/Botones/dataTables.bootstrap5.min.js",
                        "~/Script/Botones/dataTables.buttons.min.js",
                        "~/Script/Botones/buttons.bootstrap5.min.js",
                        "~/Script/Botones/buttons.colVis.min.js",
                        "~/Content/DataTables/jszip.min.js",
                        "~/Content/DataTables/vfs_fonts.js",
                        "~/Content/DataTables/buttons.html5.min.js",
                        "~/Content/DataTables/buttons.print.min.js",
                        "~/Content/DataTables/buttons2.colVis.min",

                        "~/Scripts/scripts.js"));


            //bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            //            "~/Scripts/jquery.validate*"));

            //// Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información sobre los formularios.  De esta manera estará
            //// para la producción, use la herramienta de compilación disponible en https://modernizr.com para seleccionar solo las pruebas que necesite.
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Scripts/modernizr-*"));

            bundles.Add(new Bundle("~/bundles/bootstrap").Include(
                       "~/Scripts/bootstrap.bundle.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/Site.css",
                                                                 "~/Content/DataTables/css/jquery.dataTables.css",
                                                                 "~/Content/DataTable/css/responsive.dataTables.css",
                                                                 "~/Scripts/DataTables/CSS/dataTables.bootstrap5.min.css",
                                                                 "~/Scripts/DataTables/CSS/buttons.bootstrap5.min.css",
                                                                 "~/Scripts/DataTables/CSS/dataTables.bootstrap5.min.css",
                                                                 "~/Content/DataTables/dataTables.bootstrap5.min.css",
                                                                 "~/Content/DataTables/buttons.bootstrap5.min.css",
                                                                 "~/Content/DataTables/bootstrap.min.css",
                                                                 "~/Content/DataTables/bootstrap-icons.css",
                                                                 "~/Content/DataTables/dataTables2.bootstrap5.min.css",
                                                                 
                                                                 "~/Content/DataTables/es-ES.json",
                                                                 

                                                                 "~/Content/sweetalert.css"));
        }
    }
}
