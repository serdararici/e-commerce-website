using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace WebProgramlamaProje.Controllers
{
	public class RegisterController : Controller
	{
		BrandManager bm = new BrandManager(new EfBrandRepository());
		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Index(Brand p)
		{
            BrandValidator bv = new BrandValidator();
			ValidationResult results = bv.Validate(p);
			if(results.IsValid)
			{
                p.MarkaStatus = true;
                p.MarkaDescription = "Deneme test";
                bm.BrandAdd(p);
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
