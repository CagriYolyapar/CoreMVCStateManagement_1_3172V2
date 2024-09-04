using Microsoft.AspNetCore.Mvc;

namespace CoreMVCStateManagement_1.Controllers
{
    public class CookieUsageController : Controller
    {

        void SetCookie()
        {
            HttpContext.Response.Cookies.Append("Cagri", "CyberPunk Fan", new CookieOptions
            {
                Expires = DateTime.Now.AddDays(1),
                HttpOnly = true, //document.cookie ile cookielere ulasılamaz...
                SameSite = SameSiteMode.Strict

            });
        }


        string GetCookie()
        {
            HttpContext.Request.Cookies.TryGetValue("Cagri", out string cookie);
            return cookie;

        }


        public IActionResult CookieIndex()
        {
            SetCookie();

            ViewBag.Message = GetCookie();
            
            return View();
        }
    }
}
