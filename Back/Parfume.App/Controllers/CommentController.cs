using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Parfume.App.Context;
using Parfume.App.Services.İnterfaces;
using Parfume.App.ViewModels;
using Parfume.Core.Entities;

namespace Parfume.App.Controllers
{
    public class CommentController : Controller
    {
        private readonly ParfumeDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signinManager;
        private readonly IMailService _mailService;
        public CommentController(ParfumeDbContext context, UserManager<AppUser> userManager = null, SignInManager<AppUser> signinManager = null, IMailService mailService = null)
        {
            _context = context;
            _userManager = userManager;
            _signinManager = signinManager;
            _mailService = mailService;
        }
        public async Task<IActionResult> AddComment(ProductViewModel view)
        {
            AppUser appUser = await _userManager.FindByNameAsync(User.Identity.Name);
            view.Comment.AppUserId = appUser.Id;
            view.Comment.CreatedDate = DateTime.Now;
            _context.Add(view.Comment);
            _context.SaveChanges();
            return Redirect(Request.Headers["Referer"].ToString());
        }
       
    }
}
