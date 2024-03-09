using System.Web;
using System.Web.Optimization;

namespace SportNutr.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/bundles/css2").Include(
                "~/Content/css/bootstrap.min.css",
                "~/Content/css/owl.carousel.min.css",
                "~/Content/css/slicknav.css",
                "~/Content/css/flaticon.css",
                "~/Content/css/gijgo.css",
                "~/Content/css/animate.min.css",
                "~/Content/css/animated-headline.css",
                "~/Content/css/magnific-popup.css",
                "~/Content/css/fontawesome-all.min.css",
                "~/Content/css/themify-icons.css",
                "~/Content/css/slick.css",
                "~/Content/css/nice-select.css",
                "~/Content/css/style.css"));
            
            bundles.Add(new ScriptBundle("~/bundles/mainjs").Include(
                "~/Scripts/vendor/modernizr-3.5.0.min.js",
                "~/Scripts/vendor/jquery-1.12.4.min.js",
                "~/Scripts/popper.min.js",
                "~/Scripts/bootstrap.min.js",
                "~/Scripts/jquery.slicknav.min.js",
                "~/Scripts/owl.carousel.min.js",
                "~/Scripts/slick.min.js",
                "~/Scripts/wow.min.js",
                "~/Scripts/animated.headline.js",
                "~/Scripts/jquery.magnific-popup.js",
                "~/Scripts/gijgo.min.js",
                "~/Scripts/jquery.nice-select.min.js",
                "~/Scripts/jquery.sticky.js",
                "~/Scripts/jquery.counterup.min.js",
                "~/Scripts/waypoints.min.js",
                "~/Scripts/jquery.countdown.min.js",
                "~/Scripts/hover-direction-snake.min.js",
                "~/Scripts/contact.js",
                "~/Scripts/jquery.form.js",
                "~/Scripts/jquery.validate.min.js",
                "~/Scripts/mail-script.js",
                "~/Scripts/jquery.ajaxchimp.min.js",
                "~/Scripts/plugins.js",
                "~/Scripts/main.js"));
            // Добавьте другие бандлы по мере необходимости
        }
    }
}