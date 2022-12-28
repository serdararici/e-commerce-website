using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebProgramlamaProje.Controllers
{
    public class BrandController : Controller
	{
        BrandManager bm = new BrandManager(new EfBrandRepository());
        [Authorize]
        public IActionResult Index()
		{
            var usermail = User.Identity.Name;
            ViewBag.v = usermail;
            Context c = new Context();
            var brandName = c.Brands.Where(x => x.MarkaMail == usermail).Select(y => y.MarkaName).FirstOrDefault();
            ViewBag.v2 = brandName;
			return View();
		}
        public IActionResult BrandProfile()
        {
            return View();
        }

        public IActionResult BrandMail()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult Test()
        {
            return View();
        }
        [AllowAnonymous]
        public PartialViewResult BrandNavbarPartial()
        {
            return PartialView();
        }
        [AllowAnonymous]
        public PartialViewResult BrandFooterPartial()
        {
            return PartialView();
        }
        [HttpGet]
        public IActionResult BrandEditProfile()
        {
            Context c = new Context();
            var usermail = User.Identity.Name;
            var markaID = c.Brands.Where(x => x.MarkaMail == usermail).Select(y => y.MarkaID).FirstOrDefault();

            var brandvalues = bm.TGetById(markaID);
            return View(brandvalues);
        }
        [HttpPost]
        public IActionResult BrandEditProfile(Brand p)
        {
            BrandValidator bl = new BrandValidator();
            ValidationResult results = bl.Validate(p);
            if(results.IsValid)
            {
                bm.TUpdate(p);
                return RedirectToAction("Index", "Dashboard");
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
    }
}
