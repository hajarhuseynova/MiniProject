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
    public class SettingNavbarController : Controller
    {

        private readonly ParfumeDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public SettingNavbarController(ParfumeDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;

        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<SettingNavbar> Settings = await _context.SettingNavbar.Where(x => !x.IsDeleted).ToListAsync();
            return View(Settings);
        }
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            SettingNavbar? setting = await _context.SettingNavbar.Where(c => !c.IsDeleted && c.Id == id).FirstOrDefaultAsync();
            if (setting == null)
            {
                return NotFound();
            }
            return View(setting);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, SettingNavbar setting)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            SettingNavbar? set = await _context.SettingNavbar.Where(c => !c.IsDeleted && c.Id == id).FirstOrDefaultAsync();

            if (set == null)
            {
                return NotFound();
            }

           

            if (setting.LogoFormFile != null)
            {
                if (!FileExtention.isImage(setting.LogoFormFile))
                {
                    ModelState.AddModelError("file", "Image is required");
                    return View();
                }
                if (!FileExtention.isSizeOk(setting.LogoFormFile, 1))
                {
                    ModelState.AddModelError("file", "Image size is wrong");
                    return View();
                }
                set.Logo = setting.LogoFormFile.CreateImage(_environment.WebRootPath, "assets/images");
            }


            if (setting.DeleteFormFile != null)
            {
                if (!FileExtention.isImage(setting.DeleteFormFile))
                {
                    ModelState.AddModelError("file", "Image is required");
                    return View();
                }
                if (!FileExtention.isSizeOk(setting.DeleteFormFile, 1))
                {
                    ModelState.AddModelError("file", "Image size is wrong");
                    return View();
                }
                set.Delete = setting.DeleteFormFile.CreateImage(_environment.WebRootPath, "assets/images");
            }


            if (setting.HamburgerFormFile != null)
            {
                if (!FileExtention.isImage(setting.HamburgerFormFile))
                {
                    ModelState.AddModelError("file", "Image is required");
                    return View();
                }
                if (!FileExtention.isSizeOk(setting.HamburgerFormFile, 1))
                {
                    ModelState.AddModelError("file", "Image size is wrong");
                    return View();
                }
                set.Hamburger = setting.HamburgerFormFile.CreateImage(_environment.WebRootPath, "assets/images");
            }

            set.UpdatedDate = DateTime.Now;
            set.SiderbarP5 = setting.SiderbarP5;
            set.SiderbarP4 = setting.SiderbarP4;
            set.SiderbarP3 = setting.SiderbarP3;
            set.SiderbarP2 = setting.SiderbarP2;
            set.SiderbarP1 = setting.SiderbarP1;
            set.SiderbarP6 = setting.SiderbarP6;

            set.Icon1 = setting.Icon1;
            set.Icon2 = setting.Icon2;
            set.Icon3 = setting.Icon3;


            await _context.SaveChangesAsync();
            return RedirectToAction("index", "SettingNavbar");
        }
        }
    }
