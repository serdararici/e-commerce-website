using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Runtime.Intrinsics.X86;

namespace WebProgramlamaProje.Controllers
{
    [AllowAnonymous]
    public class ProductController : Controller
    {
        ProductManager pm = new ProductManager(new EfProductRepository());
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());
        Context c = new Context();
        public IActionResult Index()
        {
            var values = pm.GetProductListWithCategory();
            return View(values);
        }
        public IActionResult ProductReadAll(int id)
        {
            ViewBag.i = id;
            var values = pm.GetProductByID(id);
            return View(values);
        }
        public IActionResult ProductListByBrand()
        {
            var usermail = User.Identity.Name;
            var markaID = c.Brands.Where(x => x.MarkaMail == usermail).Select(y => y.MarkaID).FirstOrDefault();
            var values = pm.GetListWithCategoryByBrandPm(markaID);
            return View(values);
        }
        [HttpGet]
        public IActionResult ProductAdd()
        {
            
            List<SelectListItem> categoryvalues = (from x in cm.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString()
                                                   }).ToList();
            ViewBag.cv = categoryvalues;
            return View();
        }
        [HttpPost]
        public IActionResult ProductAdd(Product p)
        {
           
            var usermail = User.Identity.Name;
            var markaID = c.Brands.Where(x => x.MarkaMail == usermail).Select(y => y.MarkaID).FirstOrDefault();

            ProductValidator pv = new ProductValidator();
            ValidationResult results = pv.Validate(p);
            if (results.IsValid)
            {
                p.ProductStatus = true;
                p.ProductCreateDate = DateTime.Parse(DateTime.Now.ToLongDateString());
                p.ProductThumbnailImage = "..";
                p.BrandID = markaID;
                pm.TAdd(p);
                return RedirectToAction("ProductListByBrand", "Product");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        public IActionResult DeleteProduct(int id)
        {
            var productvalue = pm.TGetById(id);
            pm.TDelete(productvalue);
            return RedirectToAction("ProductListByBrand");
        }
        [HttpGet]
        public IActionResult EditProduct(int id)
        {
            var productvalue = pm.TGetById(id);
            List<SelectListItem> categoryvalues = (from x in cm.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString()
                                                   }).ToList();
            ViewBag.cv = categoryvalues;
            return View(productvalue);
        }
        [HttpPost]
        public IActionResult EditProduct(Product p)
        {
            var usermail = User.Identity.Name;
            var markaID = c.Brands.Where(x => x.MarkaMail == usermail).Select(y => y.MarkaID).FirstOrDefault();

            p.BrandID = markaID;
            p.ProductCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.ProductStatus = true;
            p.ProductThumbnailImage = "..";
            pm.TUpdate(p);
            return RedirectToAction("ProductListByBrand");
        }
    }
}
