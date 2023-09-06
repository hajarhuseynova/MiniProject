using Microsoft.AspNetCore.Mvc;

namespace Controllers
{
    public class NotFoundController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
