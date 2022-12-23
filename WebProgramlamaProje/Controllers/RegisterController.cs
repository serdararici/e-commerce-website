using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
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
			p.MarkaStatus = true;
			p.MarkaDescription = "Deneme test";
			bm.BrandAdd(p);
			return RedirectToAction("Index", "Product");
		}
	}
}
