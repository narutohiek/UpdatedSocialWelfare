using Microsoft.AspNetCore.Mvc;

namespace SocialWelfarre.Controllers
{
    public class FormsController : Controller
    {
        public IActionResult FoodPacksForms()
        {
            return View();
        }
        
        public IActionResult ConsultationForms()
        {
            return View();
        }
        public IActionResult CertificateOfIndigencyForm()
        {
            return View();
        }
    }
}
