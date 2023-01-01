using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebProgramlamaProje.Controllers
{
	public class RegisterController : Controller
	{
		BrandManager bm = new BrandManager(new EfBrandRepository());
		[HttpGet]
        [AllowAnonymous]
        public IActionResult Index()
		{
			return View();
		}
		[HttpPost]
        [AllowAnonymous]
        public IActionResult Index(Brand p)
		{
            BrandValidator bv = new BrandValidator();
			ValidationResult results = bv.Validate(p);
			if(results.IsValid)
			{
                p.MarkaStatus = true;
                p.MarkaDescription = "Deneme test";
                bm.TAdd(p);
                return RedirectToAction("Index", "Product");
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
