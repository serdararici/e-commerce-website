using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace WebProgramlamaProje.ViewComponents.Product
{
    public class BrandLastProduct : ViewComponent
    {
        ProductManager pm = new ProductManager(new EfProductRepository());

        public IViewComponentResult Invoke()
        {
            var values = pm.GetProductListByBrand(1);
            return View(values);
        }
    }
}
