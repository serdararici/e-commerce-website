using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace WebProgramlamaProje.ViewComponents.Product
{
    public class ProductLast3Post : ViewComponent
    {
        ProductManager pm = new ProductManager(new EfProductRepository());

        public IViewComponentResult Invoke()
        {
            var values = pm.GetLast3Product();
            return View(values);
        }
    }
}
