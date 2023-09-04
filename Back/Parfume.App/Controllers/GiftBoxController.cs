using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Parfume.App.Context;
using Parfume.App.Services.İnterfaces;
using Parfume.App.ViewModels;
using Parfume.Core.Entities;

namespace Parfume.App.Controllers
{
    public class GiftBoxController : Controller
    {
        private readonly ParfumeDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signinManager;
        private readonly IMailService _mailService;
        public GiftBoxController(ParfumeDbContext context, UserManager<AppUser> userManager = null, SignInManager<AppUser> signinManager = null, IMailService mailService = null)
        {
            _context = context;
            _userManager = userManager;
            _signinManager = signinManager;
            _mailService = mailService;
        }
        public async Task<IActionResult> Index()
        {
            GiftBoxViewModel giftBoxViewModel = new GiftBoxViewModel
            {
                Products = await _context.Products.Include(x=>x.Category).Where(x => !x.IsDeleted &&x.Category.Name=="GiftBox").ToListAsync(),
                SettingHomePage = await _context.SettingHomePage.Where(x => !x.IsDeleted).FirstOrDefaultAsync()

            };
            return View(giftBoxViewModel);
        }
    }
}
