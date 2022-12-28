using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace WebProgramlamaProje.ViewComponents.Brand
{
    
    public class BrandAboutOnDashboard : ViewComponent
    {
        BrandManager brandmanager = new BrandManager(new EfBrandRepository());
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            var usermail = User.Identity.Name;  
            var markaID = c.Brands.Where(x => x.MarkaMail == usermail).Select(y => y.MarkaID).FirstOrDefault();
            var values = brandmanager.GetBrandById(markaID);
            return View(values);
        }
    }
}
