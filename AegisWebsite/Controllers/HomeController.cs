using AegisWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AegisWebsite.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        [ActionName("about-us")]
        public ActionResult About()
        {
            return View("About");
        }

        [ActionName("document-managment-solutions-with-workflow")]
        public ActionResult DMS()
        {
            return View("DMS");
        }

        [ActionName("scanning-and-digitization-services")]
        public ActionResult ScanningDigitization()
        {
            return View("ScanningDigitization");
        }

        [ActionName("manage-print-solutions")]
        public ActionResult MPS()
        {
            return View("MPS");
        }

        [ActionName("contact-us")]
        public ActionResult Contact()
        {
            ContactModel model = new ContactModel();
            return View("Contact", model);
        }

        [ActionName("contact-us")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Contact(ContactModel model)
        {
            bool retValue = false;
            if (ModelState.IsValid)
            {
                retValue = Utility.MailFunctionality(model.Name, model.Email, model.Phone, model.Comment);
            }

            if (retValue)
            {
                model = new ContactModel();
                TempData["Message"] = "Email sent.";
            }
            else
            {
                TempData["Message"] = "Email can't sent. Please contact through phone.";
            }

            return View("Contact", model);
        }

        [ActionName("privacy-policy")]
        public ActionResult PrivacyPolicy()
        {
            return View("PrivacyPolicy");
        }

        public ActionResult Certificates()
        {
            return View("Certificates");
        }

        [ActionName("support-or-service")]
        public ActionResult Service()
        {
            ContactModel model = new ContactModel();
            return View("Service", model);
        }

        [ActionName("support-or-service")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Service(ContactModel model)
        {
            bool retValue = false;
            if (ModelState.IsValid)
            {
                retValue = Utility.MailFunctionality(model.Name, model.Email, model.Phone, model.Comment);
            }

            if (retValue)
            {
                model = new ContactModel();
                TempData["Message"] = "Email sent.";
            }
            else
            {
                TempData["Message"] = "Email can't sent. Please contact through phone.";
            }

            return View("Service", model);
        }

        [ActionName("all-canon-products")]
        public ActionResult ProductType()
        {
            Aegis.DataAccess.ProductType objProductType = new Aegis.DataAccess.ProductType();
            List<Aegis.Model.ProductType> productTypes = objProductType.ProductType_GetAll();
            productTypes = productTypes.Select(p => { p.ContentPath = string.Concat("/Contents/ProductType/", p.ContentPath); return p; }).ToList();
            string[] alltypes = productTypes.Where(x => x != null)
                       .Select(x => x.SeoUrl.ToString())
                       .ToArray();
            ViewBag.Title = string.Concat("Aegis Solutions | Canon | Product Types | ", string.Join(" | ", alltypes));
            return View("ProductType", productTypes);
        }
    }
}
