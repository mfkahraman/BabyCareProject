using Microsoft.AspNetCore.Mvc;

namespace BabyCareProject.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Homepage()
        {
            return View();
        }
    }
}
