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
           

            return View(homeViewModel);
        }


    }
}