using System.Web;
using System.Web.Optimization;

namespace Hyna
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Content/hyna/js/bootstrap.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                     "~/Content/hyna/js/jquery-3.1.1.min.js",
                     "~/Content/hyna/js/jquery.appear.js",
                     "~/Content/hyna/js/jquery.bxslider.min.js",
                     "~/Content/hyna/js/jquery.countTo.js",
                     "~/Content/hyna/js/jquery.easing.1.3.min.js",
                     "~/Content/hyna/js/jquery.knob.min.js"
                     ));

            bundles.Add(new ScriptBundle("~/bundles/js").Include(
                     "~/Content/hyna/js/main-slider-script.js",
                     "~/Content/hyna/js/main.js",
                      "~/Content/hyna/js/map.js",
                       "~/Content/hyna/js/owl.carousel.min.js",
                        "~/Content/hyna/js/plugins.js",
                         "~/Content/hyna/js/popper.min.js",
                          "~/Content/hyna/js/venobox.min.js",
                           "~/Content/hyna/js/wow.min.js"
                     ));

            bundles.Add(new ScriptBundle("~/bundles/vendor").Include(
                      "~/Content/hyna/js/vendor/modernizr-custom.js"));

            bundles.Add(new ScriptBundle("~/bundles/revolution").Include(
                      "~/Content/hyna/plugins/revolution/extensions/revolution.extensions.actions.min.js",
                      "~/Content/hyna/plugins/revolution/extensions/revolution.extensions.carousel.min.js",
                      "~/Content/hyna/plugins/revolution/extensions/revolution.extensions.kenburn.min.js",
                      "~/Content/hyna/plugins/revolution/extensions/revolution.extensions.layeranimation.min.js",
                      "~/Content/hyna/plugins/revolution/extensions/revolution.extensions.migration.min.js",
                      "~/Content/hyna/plugins/revolution/extensions/revolution.extensions.navigation.min.js",
                      "~/Content/hyna/plugins/revolution/extensions/revolution.extensions.parallax.min.js",
                      "~/Content/hyna/plugins/revolution/extensions/revolution.extensions.slideanims.min.js",
                      "~/Content/hyna/plugins/revolution/extensions/revolution.extensions.video.min.js",
                      "~/Content/hyna/plugins/revolution/extensions/jquery.themepunch.revolution.min.js",
                      "~/Content/hyna/plugins/revolution/extensions/jquery.themepunch.tools.min.js"));


            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/hyna/css/animate.min.css",
                       "~/Content/hyna/css/bootstrap.min.css",
                        "~/Content/hyna/css/flaticon.css",
                         "~/Content/hyna/css/fontawesome.min.css",
                          "~/Content/hyna/css/owl.carousel.min.css",
                           "~/Content/hyna/css/owl.theme.default.min.css",
                            "~/Content/hyna/css/selectize.css",
                             "~/Content/hyna/css/style.css",
                              "~/Content/hyna/css/swiper.min.css",
                               "~/Content/hyna/css/venobox.css"
                      ));

            bundles.Add(new StyleBundle("~/Content/revolution").Include(
                      "~/Content/hyna/plugins/revolution/css/layers.css",
                       "~/Content/hyna/plugins/revolution/css/navigation.css",
                        "~/Content/hyna/plugins/revolution/css/settings.css"
                      ));


        }
    }
}
