using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AegisWebsite.Controllers
{
    
    public class ProductTypeController : Controller
    {
        //
        // GET: /ProductType/
        //[ActionName("ProductType")]
        //public ActionResult Index()
        //{
        //    Aegis.DataAccess.ProductType objProductType = new Aegis.DataAccess.ProductType();
        //    List<Aegis.Model.ProductType> productTypes = objProductType.ProductType_GetAll();
        //    productTypes = productTypes.Select(p => { p.ContentPath = string.Concat("/Contents/ProductType/", p.ContentPath); return p; }).ToList();
        //    string[] alltypes = productTypes.Where(x => x != null)
        //               .Select(x => x.SeoUrl.ToString())
        //               .ToArray();
        //    ViewBag.Title = string.Concat("Aegis Solutions | Canon | Product Types | ", string.Join(" | ", alltypes));
        //    return View(productTypes);
        //}

    }
}
