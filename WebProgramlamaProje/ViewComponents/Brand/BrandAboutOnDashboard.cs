using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace WebProgramlamaProje.ViewComponents.Brand
{
    
    public class BrandAboutOnDashboard : ViewComponent
    {
        BrandManager brandmanager = new BrandManager(new EfBrandRepository());
        
        public IViewComponentResult Invoke()
        {
            var values = brandmanager.GetBrandById(1);
            return View(values);
        }
    }
}
