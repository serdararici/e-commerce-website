using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebProgramlamaProje.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            Context c = new Context();
            var usermail = User.Identity.Name;
            var markaID = c.Brands.Where(x => x.MarkaMail == usermail).Select(y => y.MarkaID).FirstOrDefault();
            ViewBag.v1 = c.Products.Count().ToString();
            ViewBag.v2 = c.Products.Where(x => x.BrandID == markaID).Count();
            ViewBag.v3 = c.Categories.Count();
            return View();
        }
    }
}
