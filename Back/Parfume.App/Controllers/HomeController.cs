using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Parfume.App.Context;
using Parfume.App.Services.İnterfaces;
using Parfume.App.ViewModels;
using Parfume.Core.Entities;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Parfume.App.Controllers
{
    public class HomeController : Controller
    {
        private readonly ParfumeDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signinManager;
        private readonly IMailService _mailService;
        public HomeController(ParfumeDbContext context, UserManager<AppUser> userManager = null, SignInManager<AppUser> signinManager = null, IMailService mailService = null)
        {
            _context = context;
            _userManager = userManager;
            _signinManager = signinManager;
            _mailService = mailService;
        }
        public async Task<IActionResult> Index()
        {
            
            HomeViewModel homeViewModel = new HomeViewModel();

            homeViewModel.FakeSlides = await _context.FakeSlides.Where(x => !x.IsDeleted).ToListAsync();
            homeViewModel.Slides = await _context.Slides.Where(x => !x.IsDeleted).ToListAsync();
            homeViewModel.Functions = await _context.Functions.Where(x => !x.IsDeleted).ToListAsync();


            return View(homeViewModel);
        }


        [HttpPost]
        public async Task<IActionResult> Subscribe(string email)
        {
            Regex regex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");

            if (email == null)
            {
                TempData["EmailNull"] = "Boş email göndərməyin!";
                return Redirect(Request.Headers["Referer"].ToString());

            }
            if (!regex.IsMatch(email))
            {
                TempData["EmailRegex"] = "Email düzgün strukturda olmalıdır!";
                return Redirect(Request.Headers["Referer"].ToString());
            }
            if (await _context.Subscribes.Where(x => !x.IsDeleted).AnyAsync(x => x.Email == email))
            {
                TempData["EmailRepeat"] = "Email təkrarlandı!";
                return Redirect(Request.Headers["Referer"].ToString());

            }
            Subscribe sub = new Subscribe
            {
                Email = email,
                CreatedDate = DateTime.Now
            };
            _context.Subscribes.AddAsync(sub);
            _context.SaveChanges();

            TempData["Subs"] = "Göndərildi!";
            return Redirect(Request.Headers["Referer"].ToString());
        }

    }
}