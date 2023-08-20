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
    public class SettingFooterController : Controller
    {

        private readonly ParfumeDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public SettingFooterController(ParfumeDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;

        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<SettingFooter> Settings = await _context.SettingFooter.Where(x => !x.IsDeleted).ToListAsync();
            return View(Settings);
        }
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            SettingFooter? setting = await _context.SettingFooter.Where(c => !c.IsDeleted && c.Id == id).FirstOrDefaultAsync();
            if (setting == null)
            {
                return NotFound();
            }
            return View(setting);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, SettingFooter setting)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            SettingFooter? set = await _context.SettingFooter.Where(c => !c.IsDeleted && c.Id == id).FirstOrDefaultAsync();

            if (set == null)
            {
                return NotFound();
            }
            set.UpdatedDate = DateTime.Now;

            set.Title1 = setting.Title1;
            set.Title2 = setting.Title2;
            set.Title3 = setting.Title3;
            set.Title4 = setting.Title4;

            set.Link1 = setting.Link1;
            set.Link2 = setting.Link2;
            set.Link3 = setting.Link3;
            set.Link4 = setting.Link4;

            set.FootIcon1 = setting.FootIcon1;
            set.FootIcon2 = setting.FootIcon2;
            set.FootIcon3 = setting.FootIcon3;
            set.FootIcon4 = setting.FootIcon4;

            set.Title1Par1 = setting.Title1Par1;
            set.Title1Par2 = setting.Title1Par2;

            set.Title2Par1 = setting.Title2Par1;
            set.Title2Par2 = setting.Title2Par2;

            set.Title3Par1 = setting.Title3Par1;
            set.Title3Par2 = setting.Title3Par2;

            set.Title4Par1 = setting.Title4Par1;
            set.Title4Par2 = setting.Title4Par2;

            await _context.SaveChangesAsync();
            return RedirectToAction("index", "settingFooter");
        }
        }
    }
