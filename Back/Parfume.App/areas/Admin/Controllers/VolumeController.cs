using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Parfume.App.Context;
using Parfume.App.Services.İnterfaces;
using Parfume.Core.Entities;
using Parfume.Service.Extentions;

namespace Parfume.App.areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,SuperAdmin")]
    public class VolumeController : Controller
    {
        private readonly ParfumeDbContext _context;
        private readonly IWebHostEnvironment _environment;
        private readonly IMailService _mailService;
        public VolumeController(ParfumeDbContext context, IWebHostEnvironment environment, IMailService mailService)
        {
            _context = context;
            _environment = environment;
            _mailService = mailService;
        }
        public async Task<IActionResult> Index(int page = 1)
        {
            int TotalCount = _context.Volumes.Where(x => !x.IsDeleted).Count();
            ViewBag.TotalPage = (int)Math.Ceiling((decimal)TotalCount / 8);
            ViewBag.CurrentPage = page;

            IEnumerable<Volume> volumes = await _context.Volumes.
                Where(x => !x.IsDeleted).Skip((page - 1) * 8).Take(8).ToListAsync();

            return View(volumes);
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Volume volumes)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }

            volumes.CreatedDate = DateTime.Now;
            await _context.AddAsync(volumes);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Volume");
        }
        public async Task<IActionResult> Update(int id)
        {
            Volume? volumes = await _context.Volumes.Where(x => !x.IsDeleted && x.Id == id).FirstOrDefaultAsync();
            if (volumes is null)
            {
                return NotFound();
            }
            return View(volumes);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, Volume Volume)
        {

                Volume? Update = await _context.Volumes.Where(x => !x.IsDeleted && x.Id == id).FirstOrDefaultAsync();

            if (Volume is null)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return View();
            }

          
            Update.UpdatedDate = DateTime.Now;
            Update.MilliLiters = Volume.MilliLiters;
         


            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            Volume? Volume = await _context.Volumes.Where(x => !x.IsDeleted && x.Id == id).FirstOrDefaultAsync();


            if (Volume is null)
            {
                return NotFound();
            }
            Volume.IsDeleted = true;
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
