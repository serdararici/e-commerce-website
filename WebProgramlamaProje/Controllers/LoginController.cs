using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WebProgramlamaProje.Controllers
{
	public class LoginController : Controller
	{
		[AllowAnonymous]
		public IActionResult Index()
		{
			return View();
		}
		[HttpPost]
		[AllowAnonymous]
        public async Task<IActionResult> Index(Brand p)
        {
			Context c = new Context();
			var datavalue = c.Brands.FirstOrDefault(x=>x.MarkaMail==p.MarkaMail && x.MarkaPassword==p.MarkaPassword);
			if(datavalue!=null)
			{
				var claims = new List<Claim>
				{
					new Claim(ClaimTypes.Name,p.MarkaMail)
				};
				var useridentity = new ClaimsIdentity(claims,"a");
				ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
				await HttpContext.SignInAsync(principal);
				return RedirectToAction("Index", "Brand");
			}
			else
			{
				return View();
			}
        }
    }
}


//Context c = new Context();
//var datavalue = c.Brands.FirstOrDefault(x => x.MarkaMail == p.MarkaMail && x.MarkaPassword == p.MarkaPassword);
//if (datavalue != null)
//{
//    HttpContext.Session.SetString("username", p.MarkaMail);
//    return RedirectToAction("Index", "Brand");
//}
//else
//{
//    return View();
//}