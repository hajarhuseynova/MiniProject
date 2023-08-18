using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Parfume.App.Context;
using Parfume.App.Services.İnterfaces;
using Parfume.App.ViewModels;
using Parfume.Core.Entities;
using System.Text.RegularExpressions;

namespace Parfume.App.Controllers
{
    public class ContactController : Controller
    {
        private readonly ParfumeDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signinManager;
        private readonly IMailService _mailService;
        public ContactController(ParfumeDbContext context, UserManager<AppUser> userManager = null, SignInManager<AppUser> signinManager = null, IMailService mailService = null)
        {
            _context = context;
            _userManager = userManager;
            _signinManager = signinManager;
            _mailService = mailService;
        }
        public async Task<IActionResult> Index()
        {
            ContactViewModel contactViewModel = new ContactViewModel
            {
                Places = await _context.Places.Where(x => !x.IsDeleted).ToListAsync(),
                Messages = await _context.Messages.Where(x => !x.IsDeleted).FirstOrDefaultAsync()

            };
            return View(contactViewModel);
        }

        public async Task<IActionResult> SendMessage(string name, string subject, string message, string email)
        {
            if (name == null || subject == null || message == null || email == null)
            {
                TempData["ContactFalse"] = "Zəhmət olmasa bütün boşluqları doldurun!";
                return RedirectToAction("index", "contact");

            }
            Regex regex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
            if (!regex.IsMatch(email))
            {
                TempData["EmailReg"] = "Email düzgün strukturda olmalıdır!";
                return RedirectToAction("index", "contact");
            }
            SendMessage mes = new SendMessage
            {
                Name = name,
                Email = email,
                Message = message,
                Subject = subject,
                CreatedDate = DateTime.Now
            };
            _context.Messages.Add(mes);
            _context.SaveChanges();
            TempData["ContactTrue"] = "Göndərildi!";
            return RedirectToAction("index", "contact");
        }
     }
    }
