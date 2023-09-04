using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
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
        private readonly IBasketService _basketService;
        public HomeController(ParfumeDbContext context, UserManager<AppUser> userManager = null, SignInManager<AppUser> signinManager = null, IMailService mailService = null, IBasketService basketService = null)
        {
            _context = context;
            _userManager = userManager;
            _signinManager = signinManager;
            _mailService = mailService;
            _basketService = basketService;
        }
        public async Task<IActionResult> Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                var jsonBasket = Request.Cookies["basket"];
                if (jsonBasket != null)
                {
                    AppUser appUser = await _userManager.FindByNameAsync(User.Identity.Name);
                    Basket? basket = await _context.Baskets.
                     Where(x => !x.IsDeleted && x.AppUserId == appUser.Id)
                    .FirstOrDefaultAsync();


                    if (basket == null)
                    {
                        basket = new Basket
                        {
                            CreatedDate = DateTime.Now,
                            AppUser = appUser
                        };
                        await _context.Baskets.AddAsync(basket);
                    }
                    List<BasketViewModel> viewModels = JsonConvert.DeserializeObject<List<BasketViewModel>>(jsonBasket);
                    foreach (var model in viewModels)
                    {
                        BasketItem basketItem = default;
                        if (basket.basketItems != null)
                        {
                            basketItem = basket.basketItems.FirstOrDefault(x => x.ProductId == model.ProductId);
                        }
                        if (basketItem == null)
                        {

                            basketItem = new BasketItem
                            {
                                Basket = basket,
                                CreatedDate = DateTime.Now,
                                ProductCount = model.CountProduct,
                                ProductId = model.ProductId
                            };
                            await _context.BasketItems.AddAsync(basketItem);

                        }
                        else
                        {
                            basketItem.ProductCount++;
                        }
                    }

                    await _context.SaveChangesAsync();
                    Response.Cookies.Delete("basket");

                }
            }


            HomeViewModel homeViewModel = new HomeViewModel();
            homeViewModel.FakeSlides = await _context.FakeSlides.Where(x => !x.IsDeleted).ToListAsync();
            homeViewModel.Slides = await _context.Slides.Where(x => !x.IsDeleted).ToListAsync();
            homeViewModel.Functions = await _context.Functions.Where(x => !x.IsDeleted).ToListAsync();
            homeViewModel.Products = await _context.Products.Include(x=>x.Category).Include(x=>x.Brand).Where(x => !x.IsDeleted).ToListAsync();
            homeViewModel.SettingFooter= await _context.SettingFooter.Where(x => !x.IsDeleted).FirstOrDefaultAsync();

            homeViewModel.SettingNavbar = await _context.SettingNavbar.Where(x => !x.IsDeleted).FirstOrDefaultAsync();
            homeViewModel.SettingHomePage = await _context.SettingHomePage.Where(x => !x.IsDeleted).FirstOrDefaultAsync();
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