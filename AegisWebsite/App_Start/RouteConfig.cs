using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;


namespace AegisWebsite
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //    name: "ProductType",
            //    url: "all-canon-products/{id}",
            //    defaults: new { controller = "ProductType", action = "Index", id = UrlParameter.Optional }
            //);
            
            routes.MapRoute(
                name: "Product",
                url: "Product/{id}",
                defaults: new { controller = "Product", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "ProductCategoryList",
                url: "Product/ProductCategoryList/{id}",
                defaults: new { controller = "Product", action = "ProductCategoryList", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "ProductList",
                url: "Product/ProductList/{id}",
                defaults: new { controller = "Product", action = "ProductList", id = UrlParameter.Optional }
            );

            routes.MapRoute(
               name: "ProductSuggestion",
               url: "Product/ProductSuggestion/{id}",
               defaults: new { controller = "Product", action = "ProductSuggestion", id = UrlParameter.Optional }
           );

            routes.MapRoute(
                name: "ProductDetails",
                url: "Product/Details/{id}",
                defaults: new { controller = "Product", action = "Details", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}