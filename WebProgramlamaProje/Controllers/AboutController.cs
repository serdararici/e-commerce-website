using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace WebProgramlamaProje.Controllers
{
    [AllowAnonymous]
    public class AboutController : Controller
	{
		AboutManager abm = new AboutManager(new EfAboutRepository());
		public IActionResult Index()
		{
            var values = abm.GetList();
            return View(values);
		}
		public PartialViewResult SocialMediaAbout()
		{
			return PartialView();
		}
	}
}
