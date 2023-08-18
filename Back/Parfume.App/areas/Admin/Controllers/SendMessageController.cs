using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Parfume.App.Context;
using Parfume.Core.Entities;

namespace Parfume.App.areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,SuperAdmin")]
    public class SendMessageController : Controller
    {
        private readonly ParfumeDbContext _context;
        public SendMessageController(ParfumeDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<SendMessage> mes = await _context.Messages.Where(x => !x.IsDeleted).ToListAsync();
            return View(mes);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            SendMessage? mes = await _context.Messages.Where(x => !x.IsDeleted && x.Id == id).FirstOrDefaultAsync();
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (mes == null)
            {
                return NotFound();
            }
            mes.IsDeleted = true;
            await _context.SaveChangesAsync();
            return RedirectToAction("index", "SendMessage");
        }
    }
}