using Microsoft.AspNetCore.Mvc;

namespace DbDapperProject.Controllers
{
    public class LayoutController : Controller
    {
        public IActionResult Layout()
        {
            return View();
        }
    }
}
