using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Parfume.App.Context;
using Parfume.App.Services.İnterfaces;
using Parfume.App.ViewModels;
using Parfume.Core.Entities;

namespace Parfume.App.Services.İmplementations
{
    public class BasketService : IBasketService
    {
        private readonly ParfumeDbContext _context;
        private readonly IHttpContextAccessor _httpContext;
        private readonly UserManager<AppUser> _userManager;
        public BasketService(ParfumeDbContext context, IHttpContextAccessor httpContext, UserManager<AppUser> userManager)
        {
            _context = context;
            _httpContext = httpContext;
            _userManager = userManager;
        }
        public async Task AddBasket(int id, int? count)
        {
            if (!await _context.Parfums.AnyAsync(x => x.Id == id))
            {
                throw new Exception("Item is not found!");
            }
            if (_httpContext.HttpContext.User.Identity.IsAuthenticated && _httpContext.HttpContext.User.IsInRole("User"))
            {
                AppUser appUser = await _userManager.FindByNameAsync(_httpContext.HttpContext.User.Identity.Name);
                Basket? basket = await _context.Baskets.
                  Include(x => x.basketItems.Where(y => !y.IsDeleted)).ThenInclude(x => x.Parfum)
                  .Where(x => !x.IsDeleted && x.AppUser.Id == appUser.Id).FirstOrDefaultAsync();
                if (basket == null)
                {
                    basket = new Basket
                    {
                        AppUserId = appUser.Id,
                        CreatedDate = DateTime.Now
                    };
                    await _context.AddAsync(basket);
                    BasketItem basketItem = new BasketItem
                    {
                        Basket = basket,
                        ParfumId = id,
                        ParfumCount = count ?? 1

                    };
                    await _context.AddAsync(basketItem);
                }
                else
                {
                    BasketItem basketItem = basket.basketItems.FirstOrDefault(x => x.ParfumId == id);
                    if (basketItem != null)
                    {
                        basketItem.ParfumCount += count ?? +1;
                    }
                    else
                    {
                        basketItem = new BasketItem
                        {
                            Basket = basket,
                            ParfumId = id,
                            ParfumCount = count ?? 1

                        };
                        await _context.AddAsync(basketItem);

                    }

                }
                await _context.SaveChangesAsync();
            }
            else
            {
                var CookieJson = _httpContext?.HttpContext?.Request.Cookies["basket"];
                if (CookieJson == null)
                {
                    List<BasketViewModel> basketViewModels = new List<BasketViewModel>();
                    BasketViewModel basketViewModel = new BasketViewModel
                    {
                        ParfumId = id,
                        CountParfum = count ?? 1
                    };
                    basketViewModels.Add(basketViewModel);
                    CookieJson = JsonConvert.SerializeObject(basketViewModels);
                    _httpContext?.HttpContext?.Response.Cookies.Append("basket", CookieJson);

                }
                else
                {
                    List<BasketViewModel> basketViewModels = JsonConvert.DeserializeObject<List<BasketViewModel>>(CookieJson);
                    BasketViewModel model = basketViewModels.FirstOrDefault(x => x.ParfumId == id);
                    if (model != null)
                    {
                        model.CountParfum += count ?? 1;
                    }
                    else
                    {
                        BasketViewModel basketViewModel = new BasketViewModel
                        {
                            ParfumId = id,
                            CountParfum = count ?? 1
                        };
                        basketViewModels.Add(basketViewModel);
                    }
                    CookieJson = JsonConvert.SerializeObject(basketViewModels);
                    _httpContext?.HttpContext?.Response.Cookies.Append("basket", CookieJson);
                }
            }
        }
        public async Task<List<BasketItemViewModel>> GetAllBaskets()
        {
            if (_httpContext.HttpContext.User.Identity.IsAuthenticated && _httpContext.HttpContext.User.IsInRole("User"))
            {
                AppUser appUser = await _userManager.FindByNameAsync(_httpContext.HttpContext.User.Identity.Name);

                Basket? basket = await _context.Baskets.Include(x => x.basketItems.Where(y => !y.IsDeleted))
                          .ThenInclude(x => x.Parfum)
                           .Include(x => x.basketItems)
                             .Where(x => !x.IsDeleted && x.AppUserId == appUser.Id).FirstOrDefaultAsync();


                if (basket != null)
                {
                    List<BasketItemViewModel> basketItemViewModels = new();
                    foreach (var item in basket.basketItems)
                    {
                        basketItemViewModels.Add(new BasketItemViewModel
                        {
                            ParfumId = item.ParfumId,
                            Image = item.Parfum.Image,
                            Count = item.ParfumCount,
                            Name = item.Parfum.Brand.Name,
                            DiscountPer=(int)(item.Parfum.DiscountPercentage),
                                Price = int.Parse(item.Parfum.SellPrice)-(int.Parse(item.Parfum.SellPrice)* (int)(item.Parfum.DiscountPercentage)/100)

                        });

                    }
                    return basketItemViewModels;
                }
            }
            else
            {
                var jsonBasket = _httpContext?.HttpContext?.Request.Cookies["basket"];
                if (jsonBasket != null)
                {
                    List<BasketViewModel>? basketViewModels = JsonConvert
                             .DeserializeObject<List<BasketViewModel>>(jsonBasket);
                    List<BasketItemViewModel> basketItemViewModels = new();
                    foreach (var item in basketViewModels)
                    {
                        Parfum? parfum = await _context.Parfums
                                          .Where(x => !x.IsDeleted && x.Id == item.ParfumId)
                                           .Include(x => x.Brand)
                                           .Include(x => x.ParfumVolume).ThenInclude(x => x.Volume)
                                           .FirstOrDefaultAsync();

                        if (parfum != null)
                        {
                            basketItemViewModels.Add(new BasketItemViewModel
                            {
                                ParfumId = item.ParfumId,
                                Count = item.CountParfum,
                                Image = parfum.Image,
                                Name = parfum.Brand.Name,
                                DiscountPer = (int)(parfum.DiscountPercentage),
                                Price = int.Parse(parfum.SellPrice)-(int.Parse(parfum.SellPrice)* (int)(parfum.DiscountPercentage)/100)
                            });

                        }
                    }
                    return basketItemViewModels;
                }
            }
            return new List<BasketItemViewModel>();
        }
        public async Task Remove(int id)
        {
            if (_httpContext.HttpContext.User.Identity.IsAuthenticated && _httpContext.HttpContext.User.IsInRole("User"))
            {
                AppUser user = await _userManager.FindByNameAsync(_httpContext.HttpContext.User.Identity.Name);
                Basket? basket = await _context.Baskets.Include(x => x.basketItems.Where(y => !y.IsDeleted))
                  .Where(x => !x.IsDeleted && x.AppUser.Id == user.Id).
                  FirstOrDefaultAsync();

                if (basket != null)
                {
                    BasketItem basketItem = basket.basketItems.FirstOrDefault(x => x.ParfumId == id);
                    //basketitem null gelir
                    if (basketItem != null)
                    {
                        basketItem.IsDeleted = true;
                        await _context.SaveChangesAsync();
                    }
                }
            }

            else
            {
                var basketJson = _httpContext?.HttpContext?
                          .Request.Cookies["basket"];
                if (basketJson != null)
                {
                    List<BasketViewModel>? basketViewModels = JsonConvert
                             .DeserializeObject<List<BasketViewModel>>(basketJson);

                    BasketViewModel basketViewModel = basketViewModels.FirstOrDefault(x => x.ParfumId == id);
                    if (basketViewModel != null)
                    {
                        basketViewModels.Remove(basketViewModel);
                        basketJson = JsonConvert.SerializeObject(basketViewModels);
                        _httpContext?.HttpContext?.Response.Cookies.Append("basket", basketJson);
                    }
                }
            }
        }
    }
}




