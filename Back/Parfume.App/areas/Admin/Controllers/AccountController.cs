using Microsoft.AspNetCore.Mvc;
using Parfume.App.Context;

namespace Parfume.App.areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {
        private readonly ParfumeDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public AccountController(ParfumeDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        public async Task<IActionResult> Login()
        {
            return View();
        }
    }
}
