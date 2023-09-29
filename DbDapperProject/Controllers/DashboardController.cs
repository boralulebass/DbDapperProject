using Microsoft.AspNetCore.Mvc;

namespace DbDapperProject.Controllers
{
    public class DashboardController : Controller
    {
        //[Route("/")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
