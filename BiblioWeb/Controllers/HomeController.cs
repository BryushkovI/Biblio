using Microsoft.AspNetCore.Mvc;

namespace BiblioWeb.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
