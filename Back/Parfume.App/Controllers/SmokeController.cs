using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Parfume.App.Context;
using Parfume.App.Services.İnterfaces;
using Parfume.App.ViewModels;
using Parfume.Core.Entities;


namespace Controllers
{
    public class SmokeController : Controller
    {
        private readonly ParfumeDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signinManager;
        private readonly IMailService _mailService;
        public SmokeController(ParfumeDbContext context, UserManager<AppUser> userManager = null, SignInManager<AppUser> signinManager = null, IMailService mailService = null)
        {
            _context = context;
            _userManager = userManager;
            _signinManager = signinManager;
            _mailService = mailService;
        }

        public async Task<IActionResult> Index(int? id = null)
        {

            if (id == null)
            {
                SmokeViewModel smokeViewModel = new SmokeViewModel
                {
                    SettingHomePage = await _context.SettingHomePage.Where(x => !x.IsDeleted).FirstOrDefaultAsync(),
                    Smokes = await _context.Smokes.Where(x => !x.IsDeleted).ToListAsync()
                };
                return View(smokeViewModel);
            }
            else
            {
                SmokeViewModel smokeViewModel = new SmokeViewModel
                {
                    SettingHomePage = await _context.SettingHomePage.Where(x => !x.IsDeleted).FirstOrDefaultAsync(),
                    Smokes = await _context.Smokes.Where(x => !x.IsDeleted).ToListAsync()

                };
                return View(smokeViewModel);

            }



        }
        public async Task<IActionResult> Detail(int id)
        {

            SmokeViewModel smokeViewModel = new SmokeViewModel
            {
                Smokes = await _context.Smokes.Where(x => !x.IsDeleted ).ToListAsync(),
                Smoke = await _context.Smokes.Where(x => !x.IsDeleted && x.Id == id).FirstOrDefaultAsync(),
                Functions = await _context.Functions.Where(b => !b.IsDeleted).ToListAsync(),

            };
            if (smokeViewModel.Smoke == null)
            {
                return View(nameof(Index));
            }


            return View(smokeViewModel);
        }

        public async Task<IActionResult> SearchSmoke(string search)
        {
            int TotalCount = _context.Testers.Where(x => !x.IsDeleted && x.Title.Trim().ToLower().Contains(search.Trim().ToLower())).Count();
            List<Smoke> smokes = await _context.Smokes
               .Where(x => !x.IsDeleted && x.Title.Trim().ToLower().Contains(search.Trim().ToLower()))
               .ToListAsync();

            return Json(smokes);
        }
        public async Task<IActionResult> GetAllSmokes()
        {

            List<Smoke> smokes = await _context.Smokes.Where(x => !x.IsDeleted)
                .ToListAsync();

            return Json(smokes);
        }
    }
}
