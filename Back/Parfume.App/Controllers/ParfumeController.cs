using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.UI.Xaml.Controls;
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
        private readonly IBasketService _basketService;

        public ParfumeController(ParfumeDbContext context, UserManager<AppUser> userManager = null, SignInManager<AppUser> signinManager = null, IMailService mailService = null, IBasketService basketService = null)
        {
            _context = context;
            _userManager = userManager;
            _signinManager = signinManager;
            _mailService = mailService;
            _basketService = basketService;
        }
        public async Task<IActionResult> Index(int? id = null)
        {

            if (id == null)
            {
                ParfumeViewModel parfumeViewModel = new ParfumeViewModel
                {
                    Slides = await _context.Slides.Where(x => !x.IsDeleted).ToListAsync(),
                    Brands = await _context.Brands.Where(x => !x.IsDeleted).ToListAsync(),
                    Parfumes = await _context.Parfums.Where(x => !x.IsDeleted).Include(x => x.Brand)
                 .Include(x => x.ParfumVolume).ThenInclude(x => x.Volume)
                 .ToListAsync()

                };
                return View(parfumeViewModel);
            }
            else
            {
                ParfumeViewModel parfumeViewModel = new ParfumeViewModel
                {
                    Slides = await _context.Slides.Where(x => !x.IsDeleted).ToListAsync(),
                    Brands = await _context.Brands.Where(x => !x.IsDeleted).ToListAsync(),
                    Parfumes = await _context.Parfums.Where(x => !x.IsDeleted).Include(x => x.Brand)
                    .Include(x => x.ParfumVolume).ThenInclude(x => x.Volume)
                    .ToListAsync()

                };
                return View(parfumeViewModel);

            }



        }
        public async Task<IActionResult> Detail(int id)
        {

            ParfumeViewModel parfumViewModel = new ParfumeViewModel
            {
                Parfumes = await _context.Parfums
                       .Include(x => x.ParfumVolume)
                        .ThenInclude(x => x.Volume)
                       .Include(x => x.Brand)
                        .Where(x => !x.IsDeleted).ToListAsync(),

                Parfum = await _context.Parfums
              .Include(x => x.Brand)
                .Include(x => x.ParfumVolume).ThenInclude(x => x.Volume)
                .Where(x => !x.IsDeleted && x.Id == id).FirstOrDefaultAsync(),

                Brands = await _context.Brands.Where(b => !b.IsDeleted).ToListAsync(),
                Functions = await _context.Functions.Where(b => !b.IsDeleted).ToListAsync(),

                Volumes = await _context.Volumes.Where(b => !b.IsDeleted).ToListAsync(),

            };
            if (parfumViewModel.Parfum == null)
            {
                return View(nameof(Index));
            }


            return View(parfumViewModel);
        }
        public async Task<IActionResult> AddBasket(int id, int? count)
        {
            await _basketService.AddBasket(id, count);
            return Json(new { status = 200 });
        }
        public async Task<IActionResult> GetAllBaskets()
        {
            return Json(await _basketService.GetAllBaskets());
        }
        public async Task<IActionResult> RemoveBasket(int id)
        {
            await _basketService.Remove(id);
            return Redirect(Request.Headers["Referer"].ToString());
        }

    }
}
