using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Parfume.App.Services.İnterfaces;
using Parfume.Core.Entities;

namespace Parfume.App.Controllers { 
    public class ChatController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMailService _mailService;
        private readonly SignInManager<AppUser> _signinManager;
        public ChatController(RoleManager<IdentityRole> roleManager, UserManager<AppUser> userManager, SignInManager<AppUser> signinManager, IMailService mailService)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _signinManager = signinManager;
            _mailService = mailService;
        }
        public async Task<IActionResult> Index()
        {
            List<AppUser> users = await _userManager.Users.ToListAsync();
            return View(users);
        }
    }
}
