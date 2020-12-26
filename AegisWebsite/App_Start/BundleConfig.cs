using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace AegisWebsite.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            // create an object of ScriptBundle and 
            // specify bundle name (as virtual path) as constructor parameter 
            ScriptBundle scriptBndl = new ScriptBundle("~/bundles/jquery");


            //use Include() method to add all the script files with their paths 
            scriptBndl.Include(
                                "~/Contents/javascript/bootstrap.min.js",
                                "~/Contents/javascript/jquery.easing.js",
                                "~/Contents/javascript/owl.carousel.js",
                                "~/Contents/javascript/jquery-waypoints.js",
                                "~/Contents/javascript/jquery-countTo.js",
                                "~/Contents/javascript/jquery.cookie.js",
                                "~/Contents/javascript/gmap3.min.js",
                                "~/Contents/javascript/jquery-validate.js",
                                "~/Contents/javascript/parallax.js",
                                "~/Contents/javascript/switcher.js",
                                "~/Contents/javascript/main.js",
                                "~/Contents/javascript/jquery.themepunch.tools.min.js",
                                "~/Contents/javascript/jquery.themepunch.revolution.min.js",
                                "~/Contents/javascript/slider.js",
                                "~/Contents/javascript/modal-box.min.js"
                              );


            //Add the bundle into BundleCollection
            bundles.Add(scriptBndl);

            StyleBundle styleBundle = new StyleBundle("~/bundles/css");

            styleBundle.Include(
                "~/Contents/stylesheets/bootstrap.css",
                "~/Contents/stylesheets/style.css",
                "~/Contents/stylesheets/responsive.css",
                "~/Contents/stylesheets/animate.css",
                "~/Contents/stylesheets/modal-box.min.css",
                "~/Contents/stylesheets/themes.min.css",
                "~/Contents/stylesheets/mobile-menu.css"
                );

            bundles.Add(styleBundle);

            BundleTable.EnableOptimizations = true;
        }
    }
}