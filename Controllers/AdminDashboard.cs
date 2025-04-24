using Microsoft.AspNetCore.Mvc;

namespace SocialWelfarre.Controllers
{
    public class AdminDashboard : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
