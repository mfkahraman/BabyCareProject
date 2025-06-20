using Microsoft.AspNetCore.Mvc;

namespace BabyCareProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LayoutController : Controller
    {
        public IActionResult AdminLayout()
        {
            return View();
        }
    }
}
