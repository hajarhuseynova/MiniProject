using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Parfume.App.Context;
using Parfume.App.Services.İnterfaces;
using Parfume.App.ViewModels;
using Parfume.Core.Entities;

namespace Parfume.App.Controllers
{
    public class TesterController : Controller
    {
        private readonly ParfumeDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signinManager;
        private readonly IMailService _mailService;
        public TesterController(ParfumeDbContext context, UserManager<AppUser> userManager = null, SignInManager<AppUser> signinManager = null, IMailService mailService = null)
        {
            _context = context;
            _userManager = userManager;
            _signinManager = signinManager;
            _mailService = mailService;
        }
        public async Task<IActionResult> Index()
        {
            TesterViewModel testerViewModel = new TesterViewModel
            {
                Testers = await _context.Testers.Include(x=>x.Brand).Where(x => !x.IsDeleted).ToListAsync(),
                SettingHomePage = await _context.SettingHomePage.Where(x => !x.IsDeleted).FirstOrDefaultAsync(),

            };
            return View(testerViewModel);
        }
        public async Task<IActionResult> Search(string search)
        {
            int TotalCount = _context.Testers.Where(x => !x.IsDeleted && x.Title.Trim().ToLower().Contains(search.Trim().ToLower())).Count();
            List<Tester> testers = await _context.Testers.Where(x => !x.IsDeleted && x.Brand.Name.Trim().ToLower().Contains(search.Trim().ToLower()))
                .Include(x => x.Brand).ToListAsync();
       
            return Json(testers);
        }
        public async Task<IActionResult> GetAll()
        {
           
            List<Tester> testers = await _context.Testers.Where(x => !x.IsDeleted)
                .Include(x => x.Brand).ToListAsync();

            return Json(testers);
        }
    }
}
