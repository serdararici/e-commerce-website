using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.Intrinsics.X86;

namespace WebProgramlamaProje.Controllers
{
    public class ProductController : Controller
    {
        ProductManager pm = new ProductManager(new EfProductRepository());
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
    }
}
