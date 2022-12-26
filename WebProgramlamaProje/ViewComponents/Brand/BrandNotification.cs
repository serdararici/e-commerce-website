using Microsoft.AspNetCore.Mvc;

namespace WebProgramlamaProje.ViewComponents.Brand
{
    public class BrandNotification : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
