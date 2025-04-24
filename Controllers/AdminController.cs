using Microsoft.AspNetCore.Mvc;

namespace SocialWelfarre.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Dashboard()
        {
            return View();
        }

    }
}