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
                    Products = await _context.Products.Where(x => !x.IsDeleted).Include(x => x.Category).ToListAsync()
                };
                return View(smokeViewModel);
            }
            else
            {
                SmokeViewModel smokeViewModel = new SmokeViewModel
                {
                    SettingHomePage = await _context.SettingHomePage.Where(x => !x.IsDeleted).FirstOrDefaultAsync(),
                    Products = await _context.Products.Where(x => !x.IsDeleted).Include(x => x.Category).ToListAsync()


                };
                return View(smokeViewModel);

            }



        }
      

        public async Task<IActionResult> SearchSmoke(string search)
        {
            int TotalCount = _context.Products.Where(x => !x.IsDeleted && x.Category.Name=="Smoke" && x.Title.Trim().ToLower().Contains(search.Trim().ToLower())).Count();
            List<Product> products = await _context.Products
               .Where(x => !x.IsDeleted && x.Category.Name == "Smoke" && x.Title.Trim().ToLower().Contains(search.Trim().ToLower()))
               .ToListAsync();

            return Json(products);
        }
        public async Task<IActionResult> GetAllSmokes()
        {

            List<Product> products = await _context.Products.Where(x => !x.IsDeleted && x.Category.Name=="Smoke")
                .ToListAsync();

            return Json(products);
        }

    }
}
