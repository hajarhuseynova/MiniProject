using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Parfume.App.Context;
using Parfume.App.Services.İnterfaces;
using Parfume.App.ViewModels;
using Parfume.Core.Entities;

namespace Parfume.App.Controllers
{
    public class ProductController : Controller
    {
        private readonly ParfumeDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signinManager;
        private readonly IMailService _mailService;


        public ProductController(ParfumeDbContext context, UserManager<AppUser> userManager = null, SignInManager<AppUser> signinManager = null, IMailService mailService = null)
        {
            _context = context;
            _userManager = userManager;
            _signinManager = signinManager;
            _mailService = mailService;

        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Detail(int id)
        {

            ProductViewModel productViewModel = new ProductViewModel
            {
                Products = await _context.Products.Include(x => x.Comments)
                       .Include(x => x.Brand).Include(x => x.Category)
                        .Where(x => !x.IsDeleted).ToListAsync(),

                Product = await _context.Products
              .Include(x => x.Brand).Include(x => x.Category).Include(x=>x.Comments)
                .Where(x => !x.IsDeleted && x.Id == id).FirstOrDefaultAsync(),

                Comments = await _context.Comments.Include(x=>x.AppUser).Where(b => !b.IsDeleted).ToListAsync(),
                Comment = await _context.Comments.Where(x => !x.IsDeleted && x.Id == id).FirstOrDefaultAsync(),

                Brands = await _context.Brands.Where(b => !b.IsDeleted).ToListAsync(),
                Functions = await _context.Functions.Where(b => !b.IsDeleted).ToListAsync(),

            };
            if (productViewModel.Product == null)
            {
                return View(nameof(Index));
            }
            return View(productViewModel);
        }

    }
}
