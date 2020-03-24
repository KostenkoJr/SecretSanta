using System.Web;
using System.Web.Optimization;

namespace WishList
{
    public class BundleConfig
    {
        // Дополнительные сведения об объединении см. на странице https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Используйте версию Modernizr для разработчиков, чтобы учиться работать. Когда вы будете готовы перейти к работе,
            // готово к выпуску, используйте средство сборки по адресу https://modernizr.com, чтобы выбрать только необходимые тесты.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/SecretSanta/css").Include(
                "~/Content/assets/css",
                "~/Content/assets/css/bootstrap.min.css",
                "~/Content/assets/css/animate.css",
                "~/Content/assets/css/owl.carousel.min.css",
                "~/Content/assets/css/chosen.min.css",
                "~/Content/assets/css/easyzoom.css",
                "~/Content/assets/css/meanmenu.min.css",
                "~/Content/assets/css/themify-icons.css",
                "~/Content/assets/css/ionicons.min.css",
                "~/Content/assets/css/style.css",
                "~/Content/assets/css/bundle.css",
                "~/Content/assets/css/responsive.css"));


            bundles.Add(new ScriptBundle("~/bundles/SecretSanta/scripts").Include(
                "~/Content/assets/js/vendor/jquery-1.12.0.min.js",
                "~/Content/assets/js/popper.js",
                "~/Content/assets/js/bootstrap.min.js",
                "~/Content/assets/js/isotope.pkgd.min.js",
                "~/Content/assets/js/imagesloaded.pkgd.min.js",
                "~/Content/assets/js/jquery.counterup.min.js",
                "~/Content/assets/js/waypoints.min.js",
                "~/Content/assets/js/ajax-mail.js",
                "~/Content/assets/js/owl.carousel.min.js",
                "~/Content/assets/js/plugins.js",
                "~/Content/assets/js/main.js",
                "~/Scripts/jquery.unobtrusive-ajax.min.js"));

        }
    }
}
