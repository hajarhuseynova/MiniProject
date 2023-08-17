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
    public class FakeSliderController : Controller
    {
        private readonly ParfumeDbContext _context;
        private readonly IWebHostEnvironment _environment;
        public FakeSliderController(ParfumeDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<FakeSlider> fakes = await _context.FakeSlides.
                Where(x => !x.IsDeleted).ToListAsync();
            return View(fakes);
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FakeSlider fakes)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }
            if (fakes.FormFile is null)
            {
                ModelState.AddModelError("file", "Image is required");
                return View();
            }

            if (!FileExtention.isImage(fakes.FormFile))
            {
                ModelState.AddModelError("file", "Image is required");
                return View();
            }
            if (!FileExtention.isSizeOk(fakes.FormFile, 1))
            {
                ModelState.AddModelError("file", "Image size is wrong");
                return View();
            }

            fakes.CreatedDate = DateTime.Now;
            fakes.Image = fakes.FormFile.CreateImage(_environment.WebRootPath, "assets/images/");
            await _context.AddAsync(fakes);

            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "fakeslider");
        }
        public async Task<IActionResult> Update(int id)
        {
            FakeSlider? fakes = await _context.FakeSlides.Where(x => !x.IsDeleted && x.Id == id).FirstOrDefaultAsync();
            if (fakes is null)
            {
                return NotFound();
            }
            return View(fakes);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, FakeSlider fakes)
        {

            FakeSlider? Update = await _context.FakeSlides.Where(x => !x.IsDeleted && x.Id == id).FirstOrDefaultAsync();

            if (fakes is null)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return View();
            }

            if (fakes.FormFile is not null)
            {
                if (!FileExtention.isImage(fakes.FormFile))
                {
                    ModelState.AddModelError("file", "Image is required");
                    return View();
                }
                if (!FileExtention.isSizeOk(fakes.FormFile, 1))
                {
                    ModelState.AddModelError("file", "Image size is wrong");
                    return View();
                }
                Update.Image = fakes.FormFile.CreateImage(_environment.WebRootPath, "assets/image/");
            }
            Update.UpdatedDate = DateTime.Now;
            Update.Thoughts = fakes.Thoughts;
            Update.Name=fakes.Name;
            Update.Surname=fakes.Surname;   
            Update.Country=fakes.Country;
            Update.City=fakes.City;
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            FakeSlider? fakes = await _context.FakeSlides.Where(x => !x.IsDeleted && x.Id == id).FirstOrDefaultAsync();


            if (fakes is null)
            {
                return NotFound();
            }
            fakes.IsDeleted = true;
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
