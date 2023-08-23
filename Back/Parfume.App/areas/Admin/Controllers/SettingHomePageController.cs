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
    public class SettingHomePageController : Controller
    {

        private readonly ParfumeDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public SettingHomePageController(ParfumeDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;

        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<SettingHomePage> Settings = await _context.SettingHomePage.Where(x => !x.IsDeleted).ToListAsync();
            return View(Settings);
        }
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            SettingHomePage? setting = await _context.SettingHomePage.Where(c => !c.IsDeleted && c.Id == id).FirstOrDefaultAsync();
            if (setting == null)
            {
                return NotFound();
            }
            return View(setting);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, SettingHomePage setting)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            SettingHomePage? set = await _context.SettingHomePage.Where(c => !c.IsDeleted && c.Id == id).FirstOrDefaultAsync();

            if (set == null)
            {
                return NotFound();
            }

            if (setting.Gift1FormFile != null)
            {
                if (!FileExtention.isImage(setting.Gift1FormFile))
                {
                    ModelState.AddModelError("file", "Image is required");
                    return View();
                }
                if (!FileExtention.isSizeOk(setting.Gift1FormFile, 1))
                {
                    ModelState.AddModelError("file", "Image size is wrong");
                    return View();
                }
                set.ImageGift1 = setting.Gift1FormFile.CreateImage(_environment.WebRootPath, "assets/images");
            }
            if (setting.SmokeFormFile != null)
            {
                if (!FileExtention.isImage(setting.SmokeFormFile))
                {
                    ModelState.AddModelError("file", "Image is required");
                    return View();
                }
                if (!FileExtention.isSizeOk(setting.SmokeFormFile, 1))
                {
                    ModelState.AddModelError("file", "Image size is wrong");
                    return View();
                }
                set.ImageSmoke = setting.SmokeFormFile.CreateImage(_environment.WebRootPath, "assets/images");
            }
            if (setting.Gift2FormFile != null)
            {
                if (!FileExtention.isImage(setting.Gift2FormFile))
                {
                    ModelState.AddModelError("file", "Image is required");
                    return View();
                }
                if (!FileExtention.isSizeOk(setting.Gift2FormFile, 1))
                {
                    ModelState.AddModelError("file", "Image size is wrong");
                    return View();
                }
                set.ImageGift2 = setting.Gift2FormFile.CreateImage(_environment.WebRootPath, "assets/images");
            }
            if (setting.TesterFormFile != null)
            {
                if (!FileExtention.isImage(setting.TesterFormFile))
                {
                    ModelState.AddModelError("file", "Image is required");
                    return View();
                }
                if (!FileExtention.isSizeOk(setting.TesterFormFile, 1))
                {
                    ModelState.AddModelError("file", "Image size is wrong");
                    return View();
                }
                set.ImageTester = setting.TesterFormFile.CreateImage(_environment.WebRootPath, "assets/images");
            }

            set.UpdatedDate = DateTime.Now;
            set.TitleGift = setting.TitleGift;
            set.DescriptionGift = setting.DescriptionGift;
            set.DescSmoke = setting.DescSmoke;
            set.DescTester = setting.DescTester;
            


            await _context.SaveChangesAsync();
            return RedirectToAction("index", "settingHomePage");
        }
        }
    }
