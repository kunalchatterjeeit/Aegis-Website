using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AegisWebsite.Controllers
{
    public class ProductController : Controller
    {
        //
        // GET: /Product/

        public ActionResult Index(string id)
        {
            ViewBag.Title = string.Concat("Aegis Solutions | Canon | ", id);
            return View("Index", new Aegis.Model.Product() { SeoUrl = id });
        }

        public ActionResult ProductCategoryList(Aegis.Model.Product id)
        {
            Aegis.DataAccess.ProductCategory objProductCategory = new Aegis.DataAccess.ProductCategory();
            List<Aegis.Model.ProductCategory> productCategories = new List<Aegis.Model.ProductCategory>();
            if (!string.IsNullOrEmpty(id.SeoUrl))
            {
                Aegis.Model.ProductType productType = new Aegis.DataAccess.ProductType().ProductType_GetAll().Where(p => p.SeoUrl.ToLower().Equals(id.SeoUrl.ToLower())).FirstOrDefault();
                if (productType != null)
                {
                    productCategories = objProductCategory.ProductCategory_GetAll().Where(p => p.ProductTypeId == productType.Id).ToList();
                    if (id != null && productCategories.Any())
                        id.SeoUrl = productCategories.FirstOrDefault().SeoUrl;
                    if (productCategories.Any())
                        productCategories.FirstOrDefault().Selected = true;
                }
                else
                {
                    productCategories = objProductCategory.ProductCategory_GetAll().Where(p => p.SeoUrl.ToLower().Equals(id.SeoUrl.ToLower())).ToList();
                    int selectedCategoryId = productCategories.FirstOrDefault().Id;
                    if (productCategories.Any())
                    {
                        productType = new Aegis.DataAccess.ProductType().ProductType_GetAll().Where(p => p.Id == productCategories.FirstOrDefault().ProductTypeId).FirstOrDefault();
                        productCategories = objProductCategory.ProductCategory_GetAll().Where(p => p.ProductTypeId == productType.Id).ToList();
                        productCategories.Where(item => item.Id == selectedCategoryId).FirstOrDefault().Selected = true;
                    }
                }
            }
            else
            {
                productCategories = objProductCategory.ProductCategory_GetAll().ToList();
                if (productCategories.Any())
                {
                    Aegis.Model.ProductType productType = new Aegis.DataAccess.ProductType().ProductType_GetAll().Where(p => p.Id == productCategories.FirstOrDefault().ProductTypeId).FirstOrDefault();
                    productCategories = objProductCategory.ProductCategory_GetAll().Where(p => p.ProductTypeId == productType.Id).ToList();
                    productCategories.FirstOrDefault().Selected = true;
                }
            }

            return PartialView("ProductCategoryList", productCategories);
        }

        public ActionResult ProductList(Aegis.Model.Product id)
        {
            Aegis.DataAccess.Product objProduct = new Aegis.DataAccess.Product();
            List<Aegis.Model.Product> products = new List<Aegis.Model.Product>();
            if (string.IsNullOrEmpty(id.SeoUrl))
            {
                Aegis.DataAccess.ProductCategory objProductCategory = new Aegis.DataAccess.ProductCategory();
                List<Aegis.Model.ProductCategory> productCategories = new List<Aegis.Model.ProductCategory>();
                productCategories = objProductCategory.ProductCategory_GetAll().ToList();
                if (productCategories.Any())
                {
                    Aegis.Model.ProductType productType = new Aegis.DataAccess.ProductType().ProductType_GetAll().Where(p => p.Id == productCategories.FirstOrDefault().ProductTypeId).FirstOrDefault();
                    productCategories = objProductCategory.ProductCategory_GetAll().Where(p => p.ProductTypeId == productType.Id).ToList();
                    id.SeoUrl = productCategories.FirstOrDefault().SeoUrl;
                }
            }

            products = objProduct.Product_GetAllByCategorySeoUrl(id.SeoUrl.ToLower());

            foreach (Aegis.Model.Product product in products)
            {
                //
                Aegis.DataAccess.ProductDisplay objProductDisplay = new Aegis.DataAccess.ProductDisplay();
                List<Aegis.Model.ProductDisplay> productDisplays = objProductDisplay.ProductDisplay_GetByProductId(product.Id);
                productDisplays = productDisplays.Select(p => { p.ContentPath = string.Concat("http://admin.aegissolutions.in/ProductImage/", p.ContentPath); return p; }).ToList();
                product.ProductDisplays = productDisplays;
                //
                Aegis.DataAccess.ProductFeature objProductFeature = new Aegis.DataAccess.ProductFeature();
                List<Aegis.Model.ProductFeature> productFeatures = objProductFeature.ProductFeature_GetByProductId(product.Id);
                product.ProductFeatures = productFeatures;
            }

            return PartialView("ProductList", products);
        }

        public ActionResult Details(string id)
        {
            //
            Aegis.DataAccess.Product objProduct = new Aegis.DataAccess.Product();
            Aegis.Model.Product product = objProduct.Product_GetBySeoUrl(id);
            //
            Aegis.DataAccess.ProductDisplay objProductDisplay = new Aegis.DataAccess.ProductDisplay();
            List<Aegis.Model.ProductDisplay> productDisplays = objProductDisplay.ProductDisplay_GetByProductId(product.Id);
            productDisplays = productDisplays.Select(p => { p.ContentPath = string.Concat("http://admin.aegissolutions.in/ProductImage/", p.ContentPath); return p; }).ToList();
            product.ProductDisplays = productDisplays;
            //
            Aegis.DataAccess.ProductFeature objProductFeature = new Aegis.DataAccess.ProductFeature();
            List<Aegis.Model.ProductFeature> productFeatures = objProductFeature.ProductFeature_GetByProductId(product.Id);
            product.ProductFeatures = productFeatures;

            ViewBag.Title = string.Concat("Aegis Solutions | Canon | ", product.Name);

            return View("Details", product);
        }

        public ActionResult ProductSuggestion(Aegis.Model.Product id)
        {
            if (id == null)
            {
                id = new Aegis.Model.Product();
            }
            Aegis.DataAccess.Product objProduct = new Aegis.DataAccess.Product();
            List<Aegis.Model.Product> products = new List<Aegis.Model.Product>();
            if (string.IsNullOrEmpty(id.SeoUrl))
            {
                Aegis.DataAccess.ProductCategory objProductCategory = new Aegis.DataAccess.ProductCategory();
                List<Aegis.Model.ProductCategory> productCategories = new List<Aegis.Model.ProductCategory>();
                productCategories = objProductCategory.ProductCategory_GetAll().ToList();
                if (productCategories.Any())
                {
                    Aegis.Model.ProductType productType = new Aegis.DataAccess.ProductType().ProductType_GetAll().Where(p => p.Id == productCategories.FirstOrDefault().ProductTypeId).FirstOrDefault();
                    productCategories = objProductCategory.ProductCategory_GetAll().Where(p => p.ProductTypeId == productType.Id).ToList();
                    id.SeoUrl = productCategories.FirstOrDefault().SeoUrl;
                }
            }

            products = objProduct.Product_GetAllByCategorySeoUrl(id.SeoUrl.ToLower());
            if (products == null || products.Count == 0)
            {
                products = objProduct.Product_GetAllByCategorySeoUrl("entry-level-series-scanner-canon");
            }

            foreach (Aegis.Model.Product product in products)
            {
                //
                Aegis.DataAccess.ProductDisplay objProductDisplay = new Aegis.DataAccess.ProductDisplay();
                List<Aegis.Model.ProductDisplay> productDisplays = objProductDisplay.ProductDisplay_GetByProductId(product.Id);
                productDisplays = productDisplays.Select(p => { p.ContentPath = string.Concat("http://admin.aegissolutions.in/ProductImage/", p.ContentPath); return p; }).ToList();
                product.ProductDisplays = productDisplays;
                //
                Aegis.DataAccess.ProductFeature objProductFeature = new Aegis.DataAccess.ProductFeature();
                List<Aegis.Model.ProductFeature> productFeatures = objProductFeature.ProductFeature_GetByProductId(product.Id);
                product.ProductFeatures = productFeatures;
            }

            return PartialView("ProductSuggestion", products);
        }
    }
}
