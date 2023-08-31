using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Parfume.App.Context;
using Parfume.App.Services.İnterfaces;
using Parfume.Core.Entities;
using Parfume.Core.Entities.BaseEntities;
using Parfume.Service.Extentions;

namespace Parfume.App.areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,SuperAdmin")]
    public class ParfumController : Controller
    {
        private readonly ParfumeDbContext _context;
        private readonly IWebHostEnvironment _environment;
        private readonly IMailService _mailService;
        public ParfumController(ParfumeDbContext context, IWebHostEnvironment environment, IMailService mailService)
        {
            _context = context;
            _environment = environment;
            _mailService = mailService;
        }
        public async Task<IActionResult> Index(int page = 1)
        {
            int TotalCount = _context.Parfums.Where(x => !x.IsDeleted).Count();
            ViewBag.TotalPage = (int)Math.Ceiling((decimal)TotalCount / 5);
            ViewBag.CurrentPage = page;

            IEnumerable<Parfum> parfums = await _context.Parfums.Where(x => !x.IsDeleted).Include(x=>x.Brand).
                Where(x => !x.IsDeleted).Skip((page - 1) * 5).Take(5).ToListAsync();

            return View(parfums);
        }
        public async Task<IActionResult> Create()
        {
            ViewBag.Brand = await _context.Brands.Where(x => !x.IsDeleted).ToListAsync();
            ViewBag.Volume = await _context.Volumes.Where(x => !x.IsDeleted).ToListAsync();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Parfum parfum)
        {
            ViewBag.Brand = await _context.Brands.Where(x => !x.IsDeleted).ToListAsync();
            ViewBag.Volume = await _context.Volumes.Where(x => !x.IsDeleted).ToListAsync();



            if (!ModelState.IsValid)
            {
                return View();
            }
            if (parfum.FormFile is null)
            {
                ModelState.AddModelError("file", "Image is required");
                return View();
            }

            if (!FileExtention.isImage(parfum.FormFile))
            {
                ModelState.AddModelError("file", "Image is required");
                return View();
            }
            if (!FileExtention.isSizeOk(parfum.FormFile, 1))
            {
                ModelState.AddModelError("file", "Image size is wrong");
                return View();
            }

          
            parfum.Brand = await _context.Brands.Where(x => x.Id == parfum.BrandId).FirstOrDefaultAsync();
            parfum.Volume = await _context.Volumes.Where(x => x.Id == parfum.VolumeId).FirstOrDefaultAsync();

            parfum.CreatedDate = DateTime.Now;
            parfum.IsStock = true;
            parfum.Image = parfum.FormFile.CreateImage(_environment.WebRootPath, "assets/images");
            await _context.AddAsync(parfum);

            await _context.SaveChangesAsync();

            var mails = await _context.Subscribes.Where(x => !x.IsDeleted).ToListAsync();

            string? link = Request.Scheme + "://" + Request.Host + $"/Parfum/index/{parfum.Id}";
            foreach (var mail in mails)
            {
                await _mailService.Send("hajarih@code.edu.az", mail.Email, link, "New Parfum");
            }

            return RedirectToAction("Index", "parfum");
        }
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            ViewBag.Brand = await _context.Brands.Where(x => !x.IsDeleted).ToListAsync();
            ViewBag.Volume = await _context.Volumes.Where(x => !x.IsDeleted).ToListAsync();

            Parfum? parfums = await _context.Parfums.Where(c => !c.IsDeleted && c.Id == id).
                Include(x => x.Brand).
               Include(x => x.Volume).
             Where(x => !x.IsDeleted).FirstOrDefaultAsync();

            if (parfums == null)
            {
                return NotFound();
            }
            return View(parfums);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, Parfum parfum)
        {
            ViewBag.Brand = await _context.Brands.Where(x => !x.IsDeleted).ToListAsync();
            ViewBag.Volume = await _context.Volumes.Where(x => !x.IsDeleted).ToListAsync();

            Parfum? Update = await _context.Parfums.
                  Where(c => !c.IsDeleted && c.Id == id).Include(x => x.Brand).
                Include(x=>x.Volume).FirstOrDefaultAsync();

            if (parfum == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(Update);
            }

            if (parfum.FormFile != null)
            {
                if (!FileExtention.isImage(parfum.FormFile))
                {
                    ModelState.AddModelError("FormFile", "Wronggg!");
                    return View();
                }
                if (!FileExtention.isSizeOk(parfum.FormFile, 1))
                {
                    ModelState.AddModelError("FormFile", "Wronggg!");
                    return View();
                }

                Update.Image = parfum.FormFile.CreateImage(_environment.WebRootPath, "assets/images");
            }






            Update.UpdatedDate = DateTime.Now;
            Update.Title = parfum.Title;
            Update.Desc = parfum.Desc;
            Update.BuyPrice = parfum.BuyPrice;
            Update.Info1 = parfum.Info1;
            Update.Info2 = parfum.Info2;
            Update.ProductCode = parfum.ProductCode;
            Update.SellPrice = parfum.SellPrice;
            Update.BrandId = parfum.BrandId;
            Update.VolumeId = parfum.VolumeId;

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int id)
        {
            Parfum? parfum = await _context.Parfums.
                  Where(c => !c.IsDeleted && c.Id == id).FirstOrDefaultAsync();
            if (parfum == null)
            {
                return NotFound();
            }
            parfum.IsDeleted = true;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> IsNew(int id)
        {
            Parfum? parfum = await _context.Parfums.
                  Where(c => !c.IsDeleted && c.Id == id).FirstOrDefaultAsync();
            if (parfum == null)
            {
                return NotFound();
            }
            parfum.IsNew = true;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> IsOld(int id)
        {
            Parfum? parfum = await _context.Parfums.
                  Where(c => !c.IsDeleted && c.Id == id).FirstOrDefaultAsync();
            if (parfum == null)
            {
                return NotFound();
            }
            parfum.IsNew = false;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> InStock(int id)
        {
            Parfum? parfum = await _context.Parfums.
                  Where(c => !c.IsDeleted && c.Id == id).FirstOrDefaultAsync();
            if (parfum == null)
            {
                return NotFound();
            }
            parfum.IsStock = true;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> OutOfStock(int id)
        {
            Parfum? parfum = await _context.Parfums.
                  Where(c => !c.IsDeleted && c.Id == id).FirstOrDefaultAsync();
            if (parfum == null)
            {
                return NotFound();
            }
            parfum.IsStock = false;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> IsTrend(int id)
        {
            Parfum? parfum = await _context.Parfums.
                  Where(c => !c.IsDeleted && c.Id == id).FirstOrDefaultAsync();
            if (parfum == null)
            {
                return NotFound();
            }
            parfum.IsTrend = true;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> OutTrend(int id)
        {
            Parfum? parfum = await _context.Parfums.
                  Where(c => !c.IsDeleted && c.Id == id).FirstOrDefaultAsync();
            if (parfum == null)
            {
                return NotFound();
            }
            parfum.IsTrend = false;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> OutDiscount(int id)
        {
            Parfum? parfum = await _context.Parfums.
                  Where(c => !c.IsDeleted && c.Id == id).FirstOrDefaultAsync();
            if (parfum == null)
            {
                return NotFound();
            }
            parfum.IsDiscount = false;
            parfum.DiscountPercentage = 0;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Discount(int id)
        {
            Parfum? parfums = await _context.Parfums.Where(x => !x.IsDeleted && x.Id == id).
             Where(x => !x.IsDeleted).FirstOrDefaultAsync();

            if (parfums == null)
            {
                return NotFound();
            }
            return View(parfums);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Discount(int id,Parfum parfum)
        {
            Parfum? parfume = await _context.Parfums.
               Where(c => !c.IsDeleted && c.Id == id).FirstOrDefaultAsync();

            if (parfum is null)
            {
                return NotFound();
            }

          
            parfume.DiscountPercentage=parfum.DiscountPercentage;
            if(parfum.DiscountPercentage==0 || parfum.DiscountPercentage == null)
            {
                parfume.IsDiscount = false;
            }
            else
            {
                parfume.IsDiscount = true;
            }
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "parfum");
        }

    }
}
