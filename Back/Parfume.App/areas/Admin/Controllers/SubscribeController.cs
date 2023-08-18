
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Parfume.App.Context;
using Parfume.Core.Entities;

namespace EduHome.App.areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,SuperAdmin")]
    public class SubscribeController : Controller
    {
       
        private readonly ParfumeDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public SubscribeController(ParfumeDbContext context, IWebHostEnvironment environment)
            {
                _context = context;
                _environment = environment;

            }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Subscribe> sub = await _context.Subscribes.Where(x =>!x.IsDeleted).ToListAsync();
            return View(sub);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            Subscribe? sub = await _context.Subscribes.Where(x =>!x.IsDeleted&&x.Id == id).FirstOrDefaultAsync();
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (sub == null)
            {
                return NotFound();
            }
            sub.IsDeleted = true;
            await _context.SaveChangesAsync();
            return RedirectToAction("index", "subscribe");
        }
    }

}
