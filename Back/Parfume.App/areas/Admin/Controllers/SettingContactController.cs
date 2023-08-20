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
    public class SettingContactController : Controller
    {

        private readonly ParfumeDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public SettingContactController(ParfumeDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;

        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<SettingContact> Settings = await _context.SettingContact.Where(x => !x.IsDeleted).ToListAsync();
            return View(Settings);
        }
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            SettingContact? setting = await _context.SettingContact.Where(c => !c.IsDeleted && c.Id == id).FirstOrDefaultAsync();
            if (setting == null)
            {
                return NotFound();
            }
            return View(setting);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, SettingContact setting)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            SettingContact? set = await _context.SettingContact.Where(c => !c.IsDeleted && c.Id == id).FirstOrDefaultAsync();

            if (set == null)
            {
                return NotFound();
            }

            if (setting.Ema != null)
            {
                if (!FileExtention.isImage(setting.Ema))
                {
                    ModelState.AddModelError("file", "Image is required");
                    return View();
                }
                if (!FileExtention.isSizeOk(setting.Ema, 1))
                {
                    ModelState.AddModelError("file", "Image size is wrong");
                    return View();
                }
                set.ImageEmail = setting.Ema.CreateImage(_environment.WebRootPath, "assets/images");
            }
            if (setting.Loc != null)
            {
                if (!FileExtention.isImage(setting.Loc))
                {
                    ModelState.AddModelError("file", "Image is required");
                    return View();
                }
                if (!FileExtention.isSizeOk(setting.Loc, 1))
                {
                    ModelState.AddModelError("file", "Image size is wrong");
                    return View();
                }
                set.ImageLoc = setting.Loc.CreateImage(_environment.WebRootPath, "assets/images");
            }
            if (setting.Phone != null)
            {
                if (!FileExtention.isImage(setting.Phone))
                {
                    ModelState.AddModelError("file", "Image is required");
                    return View();
                }
                if (!FileExtention.isSizeOk(setting.Phone, 1))
                {
                    ModelState.AddModelError("file", "Image size is wrong");
                    return View();
                }
                set.ImageTel = setting.Phone.CreateImage(_environment.WebRootPath, "assets/images");
            }

            set.UpdatedDate = DateTime.Now;
            set.Title = setting.Title;
            set.Description = setting.Description;

            set.Phone1 = setting.Phone1;
            set.Phone2 = setting.Phone2;

            set.Email = setting.Email;
            set.Loc1 = setting.Loc1;
            set.Loc2 = setting.Loc2;


            await _context.SaveChangesAsync();
            return RedirectToAction("index", "settingContact");
        }
        }
    }
