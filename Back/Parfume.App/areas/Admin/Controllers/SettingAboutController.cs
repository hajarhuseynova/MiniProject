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
    public class SettingAboutController : Controller
    {

        private readonly ParfumeDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public SettingAboutController(ParfumeDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;

        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<SettingAbout> Settings = await _context.SettingAbout.Where(x => !x.IsDeleted).ToListAsync();
            return View(Settings);
        }
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            SettingAbout? setting = await _context.SettingAbout.Where(c => !c.IsDeleted && c.Id == id).FirstOrDefaultAsync();
            if (setting == null)
            {
                return NotFound();
            }
            return View(setting);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, SettingAbout setting)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            SettingAbout? set = await _context.SettingAbout.Where(c => !c.IsDeleted && c.Id == id).FirstOrDefaultAsync();

            if (set == null)
            {
                return NotFound();
            }

            if (setting.Who1FormFile != null)
            {
                if (!FileExtention.isImage(setting.Who1FormFile))
                {
                    ModelState.AddModelError("file", "Image is required");
                    return View();
                }
                if (!FileExtention.isSizeOk(setting.Who1FormFile, 1))
                {
                    ModelState.AddModelError("file", "Image size is wrong");
                    return View();
                }
                set.ImageWho1 = setting.Who1FormFile.CreateImage(_environment.WebRootPath, "assets/images");
            }
            if (setting.Who2FormFile != null)
            {
                if (!FileExtention.isImage(setting.Who2FormFile))
                {
                    ModelState.AddModelError("file", "Image is required");
                    return View();
                }
                if (!FileExtention.isSizeOk(setting.Who2FormFile, 1))
                {
                    ModelState.AddModelError("file", "Image size is wrong");
                    return View();
                }
                set.ImageWho2 = setting.Who2FormFile.CreateImage(_environment.WebRootPath, "assets/images");
            }
            if (setting.Why1FormFile != null)
            {
                if (!FileExtention.isImage(setting.Why1FormFile))
                {
                    ModelState.AddModelError("file", "Image is required");
                    return View();
                }
                if (!FileExtention.isSizeOk(setting.Why1FormFile, 1))
                {
                    ModelState.AddModelError("file", "Image size is wrong");
                    return View();
                }
                set.ImageWhy1 = setting.Why1FormFile.CreateImage(_environment.WebRootPath, "assets/images");
            }
            if (setting.Why2FormFile != null)
            {
                if (!FileExtention.isImage(setting.Why2FormFile))
                {
                    ModelState.AddModelError("file", "Image is required");
                    return View();
                }
                if (!FileExtention.isSizeOk(setting.Why2FormFile, 1))
                {
                    ModelState.AddModelError("file", "Image size is wrong");
                    return View();
                }
                set.ImageWhy2 = setting.Why2FormFile.CreateImage(_environment.WebRootPath, "assets/images");
            }

            set.UpdatedDate = DateTime.Now;
            set.WhoTitle = setting.WhoTitle;
            set.WhyTitle = setting.WhyTitle;

            set.WhoP1 = setting.WhoP1;
            set.WhoP2 = setting.WhoP2;
            set.WhoP3 = setting.WhoP3;


            set.WhyP1 = setting.WhyP1;
            set.WhyP2 = setting.WhyP2;



            set.Icon1 = setting.Icon1;
            set.Icon2 = setting.Icon2;
            set.Icon3 = setting.Icon3;
            set.Icon4 = setting.Icon4;

            set.IconP1 = setting.IconP1;
            set.IconP2 = setting.IconP2;
            set.IconP3 = setting.IconP3;
            set.IconP4 = setting.IconP4;

            await _context.SaveChangesAsync();
            return RedirectToAction("index", "settingAbout");
        }
        }
    }
