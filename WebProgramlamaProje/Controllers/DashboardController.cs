using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebProgramlamaProje.Controllers
{
    public class DashboardController : Controller
    {
        [AllowAnonymous]
        public IActionResult Index()
        {
            Context c = new Context();
            ViewBag.v1 = c.Products.Count().ToString();
            ViewBag.v2 = c.Products.Where(x => x.BrandID == 1).Count();
            ViewBag.v3 = c.Categories.Count();
            return View();
        }
    }
}
