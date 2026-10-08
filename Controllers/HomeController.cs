using Microsoft.AspNetCore.Mvc;

namespace ClinicAppointmentMVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
