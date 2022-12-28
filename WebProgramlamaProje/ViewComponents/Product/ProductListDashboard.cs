using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace WebProgramlamaProje.ViewComponents.Product
{
    public class ProductListDashboard : ViewComponent
    {
        ProductManager pm = new ProductManager(new EfProductRepository());

        public IViewComponentResult Invoke()
        {
            var values = pm.GetProductListWithCategory();
            return View(values);
        }
    }
}
