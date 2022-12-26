using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebProgramlamaProje.Controllers
{
    public class BrandController : Controller
	{
		public IActionResult Index()
		{
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
    }
}
