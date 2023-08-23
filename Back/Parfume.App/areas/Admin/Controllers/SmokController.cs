
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Parfume.App.Context;
using Parfume.Core.Entities;
using Parfume.Service.Extentions;

namespace Parfume.App.areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,SuperAdmin")]
    public class SmokController : Controller
    {

        private readonly ParfumeDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public SmokController(ParfumeDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;

        }
        public async Task<IActionResult> Index(int page = 1)
        {
            int TotalCount = _context.Smokes.Where(x => !x.IsDeleted).Count();
            ViewBag.TotalPage = (int)Math.Ceiling((decimal)TotalCount / 5);
            ViewBag.CurrentPage = page;

            IEnumerable<Smoke> smoke = await _context.Smokes.
                Where(x => !x.IsDeleted).Skip((page - 1) * 5).Take(5).ToListAsync();

            return View(smoke);
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Smoke smoke)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }
            if (smoke.FormFile == null)
            {
                ModelState.AddModelError("FormFile", "Wrong!");
                return View();
            }


            if (!FileExtention.isImage(smoke.FormFile))
            {
                ModelState.AddModelError("FormFile", "Wronggg!");
                return View();
            }
            if (!FileExtention.isSizeOk(smoke.FormFile, 1))
            {
                ModelState.AddModelError("FormFile", "Wronggg!");
                return View();
            }

            smoke.Image = smoke.FormFile.CreateImage(_environment.WebRootPath, "assets/images/");

            smoke.CreatedDate = DateTime.Now;
            await _context.AddAsync(smoke);

            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Smok");
        }
        public async Task<IActionResult> Update(int id)
        {
            Smoke? smoke = await _context.Smokes.Where(x => !x.IsDeleted && x.Id == id).FirstOrDefaultAsync();
            if (smoke is null)
            {
                return NotFound();
            }
            return View(smoke);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, Smoke smoke)
        {

            Smoke? Update = await _context.Smokes.Where(x => !x.IsDeleted && x.Id == id).FirstOrDefaultAsync();

            if (smoke is null)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return View();
            }

            if (smoke.FormFile is not null)
            {
                if (!FileExtention.isImage(smoke.FormFile))
                {
                    ModelState.AddModelError("file", "Image is required");
                    return View();
                }
                if (!FileExtention.isSizeOk(smoke.FormFile, 1))
                {
                    ModelState.AddModelError("file", "Image size is wrong");
                    return View();
                }
                Update.Image = smoke.FormFile.CreateImage(_environment.WebRootPath, "assets/image/");
            }

            Update.UpdatedDate = DateTime.Now;
            Update.Title = smoke.Title;
            Update.Info1 = smoke.Info1;
            Update.Info2 = smoke.Info2;
            Update.ProductCode = smoke.ProductCode;
            Update.Desc = smoke.Desc;
          


            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            Smoke? smoke = await _context.Smokes.Where(x => !x.IsDeleted && x.Id == id).FirstOrDefaultAsync();

            if (smoke is null)
            {
                return NotFound();
            }
            smoke.IsDeleted = true;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> OutDiscount(int id)
        {
            Smoke? smoke = await _context.Smokes.
                  Where(c => !c.IsDeleted && c.Id == id).FirstOrDefaultAsync();
            if (smoke == null)
            {
                return NotFound();
            }
            smoke.IsDiscount = false;
            smoke.DiscountPercentage = 0;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Discount(int id)
        {
            Smoke? smoke = await _context.Smokes.Where(x => !x.IsDeleted && x.Id == id).
             Where(x => !x.IsDeleted).FirstOrDefaultAsync();

            if (smoke == null)
            {
                return NotFound();
            }
            return View(smoke);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Discount(int id, Smoke smok)
        {
            Smoke? smoke = await _context.Smokes.
               Where(c => !c.IsDeleted && c.Id == id).FirstOrDefaultAsync();

            if (smok is null)
            {
                return NotFound();
            }

            smoke.DiscountPercentage = smok.DiscountPercentage;
            if (smok.DiscountPercentage == 0 || smok.DiscountPercentage == null)
            {
                smoke.IsDiscount = false;
            }
            else
            {
                smoke.IsDiscount = true;
            }
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "smok");
        }

        public async Task<IActionResult> InStock(int id)
        {
            Smoke? smoke = await _context.Smokes.
                  Where(c => !c.IsDeleted && c.Id == id).FirstOrDefaultAsync();
            if (smoke == null)
            {
                return NotFound();
            }
            smoke.IsStock = true;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> OutOfStock(int id)
        {
            Smoke? smoke = await _context.Smokes.
                  Where(c => !c.IsDeleted && c.Id == id).FirstOrDefaultAsync();
            if (smoke == null)
            {
                return NotFound();
            }
            smoke.IsStock = false;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


    }
}