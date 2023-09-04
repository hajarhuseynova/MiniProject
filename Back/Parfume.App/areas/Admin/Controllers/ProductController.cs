using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Parfume.App.Context;
using Parfume.App.Services.İnterfaces;
using Parfume.Core.Entities;
using Parfume.Service.Extentions;
using System.Linq;

namespace areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,SuperAdmin")]
    public class ProductController : Controller
    {
        private readonly ParfumeDbContext _context;
        private readonly IWebHostEnvironment _environment;
        private readonly IMailService _mailService;
        public ProductController(ParfumeDbContext context, IWebHostEnvironment environment, IMailService mailService)
        {
            _context = context;
            _environment = environment;
            _mailService = mailService;
        }
        public async Task<IActionResult> Index(int? page=1)
        {
            IEnumerable<Product> prod = await _context.Products.Include(x=>x.Category).Include(x=>x.Brand).
               Where(x => !x.IsDeleted).ToListAsync();

            return View(prod);
        }
        public async Task<IActionResult> Create()
        {
            ViewBag.Category = await _context.Category.Where(x => !x.IsDeleted).ToListAsync();
            ViewBag.Brand = await _context.Brands.Where(x => !x.IsDeleted).ToListAsync();
        

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product)
        {
            ViewBag.Category = await _context.Category.Where(x => !x.IsDeleted).ToListAsync();
            ViewBag.Brand = await _context.Brands.Where(x => !x.IsDeleted).ToListAsync();
           

            if (!ModelState.IsValid)
            {
                return View();
            }
            if (product.FormFile is null)
            {
                ModelState.AddModelError("file", "Image is required");
                return View();
            }

            if (!FileExtention.isImage(product.FormFile))
            {
                ModelState.AddModelError("file", "Image is required");
                return View();
            }
            if (!FileExtention.isSizeOk(product.FormFile, 1))
            {
                ModelState.AddModelError("file", "Image size is wrong");
                return View();
            }

            product.Category = await _context.Category.Where(x => x.Id == product.ProductCategoryId).FirstOrDefaultAsync();
      
            product.Brand = await _context.Brands.Where(x => x.Id == product.BrandId).FirstOrDefaultAsync();

            product.CreatedDate = DateTime.Now;
           
            product.Image = product.FormFile.CreateImage(_environment.WebRootPath, "assets/images");
            await _context.AddAsync(product);
            await _context.SaveChangesAsync();
            var mails = await _context.Subscribes.Where(x => !x.IsDeleted).ToListAsync();

            string? link = Request.Scheme + "://" + Request.Host + $"/Tester/index/{product.Id}";
            foreach (var mail in mails)
            {
                await _mailService.Send("hajarih@code.edu.az", mail.Email, link, "New product");
            }

            return RedirectToAction("Index", "product");
        }
        public async Task<IActionResult> Update(int id)
        {
            ViewBag.Category = await _context.Category.Where(x => !x.IsDeleted).ToListAsync();
            ViewBag.Brand = await _context.Brands.Where(x => !x.IsDeleted).ToListAsync();
      

            Product? prod = await _context.Products.Where(c => !c.IsDeleted && c.Id == id).
                Include(x => x.Category).Include(x=>x.Brand).Where(x => !x.IsDeleted).FirstOrDefaultAsync();

            if (prod == null)
            {
                return NotFound();
            }
            return View(prod);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, Product product)
        {
            ViewBag.Category = await _context.Category.Where(x => !x.IsDeleted).ToListAsync();
            ViewBag.Brand = await _context.Brands.Where(x => !x.IsDeleted).ToListAsync();
          

            Product? Update = await _context.Products.
                  Where(c => !c.IsDeleted && c.Id == id).Include(x => x.Category).Include(x=>x.Brand)
                .FirstOrDefaultAsync();

            if (product == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(Update);
            }

            if (product.FormFile != null)
            {
                if (!FileExtention.isImage(product.FormFile))
                {
                    ModelState.AddModelError("FormFile", "Wronggg!");
                    return View();
                }
                if (!FileExtention.isSizeOk(product.FormFile, 1))
                {
                    ModelState.AddModelError("FormFile", "Wronggg!");
                    return View();
                }

                Update.Image = product.FormFile.CreateImage(_environment.WebRootPath, "assets/images");
            }

            Update.UpdatedDate = DateTime.Now;
            Update.Title = product.Title;
      
            Update.Desc = product.Desc;
            Update.BuyPrice = product.BuyPrice;
            Update.Info1 = product.Info1;
            Update.Info2 = product.Info2;
            Update.ProductCode = product.ProductCode;
            Update.SellPrice = product.SellPrice;
            Update.Volume = product.Volume;
            Update.ProductCategoryId = product.ProductCategoryId;
            Update.BrandId = product.BrandId;

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int id)
        {
            Product? prod = await _context.Products.
                  Where(c => !c.IsDeleted && c.Id == id).FirstOrDefaultAsync();
            if (prod == null)
            {
                return NotFound();
            }
            prod.IsDeleted = true;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> IsNew(int id)
        {
            Product? Product = await _context.Products.
                  Where(c => !c.IsDeleted && c.Id == id).FirstOrDefaultAsync();
            if (Product == null)
            {
                return NotFound();
            }
            Product.IsNew = true;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> IsOld(int id)
        {
            Product? Product = await _context.Products.
                  Where(c => !c.IsDeleted && c.Id == id).FirstOrDefaultAsync();
            if (Product == null)
            {
                return NotFound();
            }
            Product.IsNew = false;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> InStock(int id)
        {
            Product? Product = await _context.Products.
                  Where(c => !c.IsDeleted && c.Id == id).FirstOrDefaultAsync();
            if (Product == null)
            {
                return NotFound();
            }
            Product.IsStock = true;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> OutOfStock(int id)
        {
            Product? Product = await _context.Products.
                  Where(c => !c.IsDeleted && c.Id == id).FirstOrDefaultAsync();
            if (Product == null)
            {
                return NotFound();
            }
            Product.IsStock = false;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> IsTrend(int id)
        {
            Product? Product = await _context.Products.
                  Where(c => !c.IsDeleted && c.Id == id).FirstOrDefaultAsync();
            if (Product == null)
            {
                return NotFound();
            }
            Product.IsTrend = true;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> OutTrend(int id)
        {
            Product? Product = await _context.Products.
                  Where(c => !c.IsDeleted && c.Id == id).FirstOrDefaultAsync();
            if (Product == null)
            {
                return NotFound();
            }
            Product.IsTrend = false;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> OutDiscount(int id)
        {
            Product? Product = await _context.Products.
                  Where(c => !c.IsDeleted && c.Id == id).FirstOrDefaultAsync();
            if (Product == null)
            {
                return NotFound();
            }
            Product.IsDiscount = false;
            Product.DiscountPercentage = 0;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Discount(int id)
        {
            Product? Products = await _context.Products.Where(x => !x.IsDeleted && x.Id == id).
             Where(x => !x.IsDeleted).FirstOrDefaultAsync();

            if (Products == null)
            {
                return NotFound();
            }
            return View(Products);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Discount(int id, Product Product)
        {
            Product? Producte = await _context.Products.
               Where(c => !c.IsDeleted && c.Id == id).FirstOrDefaultAsync();

            if (Product is null)
            {
                return NotFound();
            }


            Producte.DiscountPercentage = Product.DiscountPercentage;
            if (Product.DiscountPercentage == 0 || Product.DiscountPercentage == null)
            {
                Producte.IsDiscount = false;
            }
            else
            {
                Producte.IsDiscount = true;
            }
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Product");
        }
    }
}
