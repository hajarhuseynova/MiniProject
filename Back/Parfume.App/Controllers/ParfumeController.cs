using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Parfume.App.Context;
using Parfume.App.Services.İnterfaces;
using Parfume.App.ViewModels;
using Parfume.Core.Entities;

namespace Parfume.App.Controllers
{
    public class ParfumeController : Controller
    {
        private readonly ParfumeDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signinManager;
        private readonly IMailService _mailService;
        public ParfumeController(ParfumeDbContext context, UserManager<AppUser> userManager = null, SignInManager<AppUser> signinManager = null, IMailService mailService = null)
        {
            _context = context;
            _userManager = userManager;
            _signinManager = signinManager;
            _mailService = mailService;
        }
        public async Task<IActionResult> Index()
        {
            ParfumeViewModel parfumeViewModel = new ParfumeViewModel
            {
                Slides = await _context.Slides.Where(x => !x.IsDeleted).ToListAsync(),
                Brands = await _context.Brands.Where(x => !x.IsDeleted).ToListAsync(),
                Parfumes = await _context.Parfums.Where(x => !x.IsDeleted).Include(x=>x.Brand)
                .Include(x=>x.ParfumVolume).ThenInclude(x=>x.Volume)
                .ToListAsync()

            };
            return View(parfumeViewModel);
        }
    }
}
