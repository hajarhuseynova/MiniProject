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
    public class TesterController : Controller
    {
        private readonly ParfumeDbContext _context;
        private readonly IWebHostEnvironment _environment;
        private readonly IMailService _mailService;
        public TesterController(ParfumeDbContext context, IWebHostEnvironment environment, IMailService mailService)
        {
            _context = context;
            _environment = environment;
            _mailService = mailService;
        }
        public async Task<IActionResult> Index(int page=1)
        {
            int TotalCount = _context.Testers.Where(x => !x.IsDeleted).Count();
            ViewBag.TotalPage = (int)Math.Ceiling((decimal)TotalCount / 5);
            ViewBag.CurrentPage = page;

            IEnumerable<Tester> testers = await _context.Testers.Where(x => !x.IsDeleted).Include(x=>x.Brand).
                Where(x => !x.IsDeleted).Skip((page - 1) * 5).Take(5).ToListAsync();

            return View(testers);
        }
        public async Task<IActionResult> Create()
        {
            ViewBag.Brand = await _context.Brands.Where(x => !x.IsDeleted).ToListAsync();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Tester tester)
        {
            ViewBag.Brand = await _context.Brands.Where(x => !x.IsDeleted).ToListAsync();


            if (!ModelState.IsValid)
            {
                return View();
            }
            if (tester.FormFile is null)
            {
                ModelState.AddModelError("file", "Image is required");
                return View();
            }

            if (!FileExtention.isImage(tester.FormFile))
            {
                ModelState.AddModelError("file", "Image is required");
                return View();
            }
            if (!FileExtention.isSizeOk(tester.FormFile, 1))
            {
                ModelState.AddModelError("file", "Image size is wrong");
                return View();
            }

            tester.Brand = await _context.Brands.Where(x => x.Id == tester.BrandId).FirstOrDefaultAsync();
            tester.CreatedDate = DateTime.Now;
            tester.Image = tester.FormFile.CreateImage(_environment.WebRootPath, "assets/images");
            await _context.AddAsync(tester);

            await _context.SaveChangesAsync();

            var mails = await _context.Subscribes.Where(x => !x.IsDeleted).ToListAsync();

            string? link = Request.Scheme + "://" + Request.Host + $"/Tester/index/{tester.Id}";
            foreach (var mail in mails)
            {
                await _mailService.Send("hajarih@code.edu.az", mail.Email, link, "New Tester");
            }

            return RedirectToAction("Index", "tester");
        }
        public async Task<IActionResult> Update(int id)
        {
            ViewBag.Brand = await _context.Brands.Where(x => !x.IsDeleted).ToListAsync();

            Tester? testers = await _context.Testers.Include(x=>x.Brand).AsNoTrackingWithIdentityResolution()
                .Where(x => !x.IsDeleted && x.Id == id)
                .FirstOrDefaultAsync();


            if (testers is null)
            {
                return NotFound();
            }
            return View(testers);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, Tester Tester)
        {
            ViewBag.Brand = await _context.Brands.Where(x => !x.IsDeleted).ToListAsync();

            Tester? Update = await _context.Testers
                .Include(x => x.Brand).Where(x => !x.IsDeleted && x.Id == id).FirstOrDefaultAsync();

            if (Tester.BrandId == 0)
            {
                ModelState.AddModelError("", "Every column must be selected");
                return View(Update);
            }


            if (Tester is null)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return View();
            }

            if (Tester.FormFile is not null)
            {
                if (!FileExtention.isImage(Tester.FormFile))
                {
                    ModelState.AddModelError("file", "Image is required");
                    return View();
                }
                if (!FileExtention.isSizeOk(Tester.FormFile, 1))
                {
                    ModelState.AddModelError("file", "Image size is wrong");
                    return View();
                }
                Update.Image = Tester.FormFile.CreateImage(_environment.WebRootPath, "assets/images");
            }


            Update.UpdatedDate = DateTime.Now;
            Update.Title = Tester.Title;
            Update.BuyPrice = Tester.BuyPrice;
            Update.SellPrice = Tester.SellPrice;
            Update.BrandId = Tester.BrandId;

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            Tester? tester = await _context.Testers.Where(x => !x.IsDeleted && x.Id == id).FirstOrDefaultAsync();

            if (tester is null)
            {
                return NotFound();
            }
            tester.IsDeleted = true;
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
