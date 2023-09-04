using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Parfume.App.Context;
using Parfume.Core.Entities;

namespace Parfume.App.Controllers
{
    [Authorize(Roles = "User")]
    public class OrderController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signinManager;
        private readonly ParfumeDbContext _context;


        public OrderController(RoleManager<IdentityRole> roleManager, UserManager<AppUser> userManager, SignInManager<AppUser> signinManager, ParfumeDbContext context)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _signinManager = signinManager;
            _context = context;
        }
        public async Task<IActionResult> CheckOut()
        {
            AppUser appUser = await _userManager.FindByNameAsync(User.Identity.Name);
            var baskets = await _context.Baskets.Where(x => !x.IsDeleted && x.AppUserId == appUser.Id).
                Include(x => x.basketItems.Where(y => !y.IsDeleted)).
                ThenInclude(x => x.Product).
                ThenInclude(x => x.Category).
                  Include(x => x.basketItems.Where(y => !y.IsDeleted)).
                     ThenInclude(x => x.Product).
                ThenInclude(x => x.Brand).FirstOrDefaultAsync();
            if (baskets == null || baskets.basketItems.Count() == 0)
            {
                TempData["empty basket"] = "Səbət boşdur!";
                return RedirectToAction("index", "home");
            }
            return View(baskets);
        }
        public async Task<IActionResult> CreateOrder()
        {
            AppUser appUser = await _userManager.FindByNameAsync(User.Identity.Name);
            var baskets = await _context.Baskets.Where(x => !x.IsDeleted && x.AppUserId == appUser.Id).
                Include(x => x.basketItems.Where(y => !y.IsDeleted)).
                ThenInclude(x => x.Product).
                ThenInclude(x => x.Category).
                  Include(x => x.basketItems.Where(y => !y.IsDeleted)).
                     ThenInclude(x => x.Product).
                ThenInclude(x => x.Brand).FirstOrDefaultAsync();
            if (baskets == null || baskets.basketItems.Count() == 0)
            {
                TempData["empty basket"] = "Səbət boşdur!";
                return RedirectToAction("index", "home");
            }
            Order order = new Order
            {
                CreatedDate = DateTime.Now,
                AppUserId = appUser.Id,
             
            };
            
            int TotalPrice = 0;
            foreach (var item in baskets.basketItems)
            {
                TotalPrice += int.Parse(item.Product.SellPrice) - (int.Parse(item.Product.SellPrice) * (int)(item.Product.DiscountPercentage ?? 0) / 100);


                OrderItem orderItem = new OrderItem
                {
                    CreatedDate = DateTime.Now,
                    Order = order,
                    ProductId = item.ProductId,
                    ProductCount = item.ProductCount,
                   
                };
                await _context.AddAsync(orderItem);

            }
            order.TotalPrice = TotalPrice;
            await _context.AddAsync(order);
            baskets.IsDeleted = true;
            await _context.SaveChangesAsync();

            TempData["Order created!"] = "Sifariş yaradıldı!";
            return RedirectToAction("index", "home");
        }
    }
}
