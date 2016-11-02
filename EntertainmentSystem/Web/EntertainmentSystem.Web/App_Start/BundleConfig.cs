namespace EntertainmentSystem.Web
{
    using System.Web.Optimization;

    public static class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
#if DEBUG
            BundleTable.EnableOptimizations = false;
#else
            BundleTable.EnableOptimizations = true;
#endif

            bundles.IgnoreList.Clear();

            RegisterScripts(bundles);
            RegisterStyles(bundles);
        }

        private static void RegisterScripts(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundlesJs/jquery")
                .Include(
                    "~/Scripts/KendoUI/jquery.min.js"));

            bundles.Add(new ScriptBundle("~/bundlesJs/jqueryval")
                .Include("~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundlesJs/kendo")
                .Include(
                    "~/Scripts/KendoUI/kendo.all.min.js",
                    "~/Scripts/KendoUI/kendo.aspnetmvc.min.js"));

            bundles.Add(new ScriptBundle("~/bundlesJs/tools")
                .Include(
                "~/Scripts/bootstrap.js",
                "~/Scripts/jquery.fancybox.js",
                "~/Scripts/toastr.js"));

            bundles.Add(new ScriptBundle("~/bundlesJs/appJs")
                .Include(
                "~/Scripts/App/EntertainmentSystemApp.js",
                "~/Scripts/App/EntertainmentSystem-media.js"));
        }

        private static void RegisterStyles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/bundlesContent/siteCss")
                .Include("~/Content/Site/site.css"));

            bundles.Add(new StyleBundle("~/bundlesContent/tools")
                .Include(
                "~/Content/bootstrap.css",
                "~/Content/toastr.css",
                "~/Content/jquery.fancybox*",
                "~/Content/font-awesome.css"));

            bundles.Add(new StyleBundle("~/bundlesContent/kendo")
                .Include(
                "~/Content/KendoUI/kendo.common.min.css",
                "~/Content/KendoUI/kendo.metro.min.css"));
        }
    }
}
