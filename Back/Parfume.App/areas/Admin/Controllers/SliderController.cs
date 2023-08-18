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
    public class SliderController : Controller
    {
        private readonly ParfumeDbContext _context;
        private readonly IWebHostEnvironment _environment;
        public SliderController(ParfumeDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }
        public async Task<IActionResult> Index(int page=1)
        {
            int TotalCount = _context.Slides.Where(x => !x.IsDeleted).Count();
            ViewBag.TotalPage = (int)Math.Ceiling((decimal)TotalCount / 5);
            ViewBag.CurrentPage = page;

            IEnumerable<Slider> slides = await _context.Slides.
                Where(x => !x.IsDeleted).Skip((page - 1) * 5).Take(5).ToListAsync();

            return View(slides);
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Slider slides)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }
            if (slides.FormFile is null)
            {
                ModelState.AddModelError("file", "Image is required");
                return View();
            }

            if (!FileExtention.isImage(slides.FormFile))
            {
                ModelState.AddModelError("file", "Image is required");
                return View();
            }
            if (!FileExtention.isSizeOk(slides.FormFile, 1))
            {
                ModelState.AddModelError("file", "Image size is wrong");
                return View();
            }

            slides.CreatedDate = DateTime.Now;
            slides.Image = slides.FormFile.CreateImage(_environment.WebRootPath, "assets/images/");
            await _context.AddAsync(slides);

            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "slider");
        }
        public async Task<IActionResult> Update(int id)
        {
            Slider? slides = await _context.Slides.Where(x => !x.IsDeleted && x.Id == id).FirstOrDefaultAsync();
            if (slides is null)
            {
                return NotFound();
            }
            return View(slides);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, Slider slides)
        {

            Slider? Update = await _context.Slides.Where(x => !x.IsDeleted && x.Id == id).FirstOrDefaultAsync();

            if (slides is null)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return View();
            }

            if (slides.FormFile is not null)
            {
                if (!FileExtention.isImage(slides.FormFile))
                {
                    ModelState.AddModelError("file", "Image is required");
                    return View();
                }
                if (!FileExtention.isSizeOk(slides.FormFile, 1))
                {
                    ModelState.AddModelError("file", "Image size is wrong");
                    return View();
                }
                Update.Image = slides.FormFile.CreateImage(_environment.WebRootPath, "assets/image/");
            }
            Update.UpdatedDate = DateTime.Now;
            Update.Title = slides.Title;
            Update.Desc= slides.Desc;
            Update.Chooice=slides.Chooice;   
        
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
           Slider? slides = await _context.Slides.Where(x => !x.IsDeleted && x.Id == id).FirstOrDefaultAsync();


            if (slides is null)
            {
                return NotFound();
            }
            slides.IsDeleted = true;
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
