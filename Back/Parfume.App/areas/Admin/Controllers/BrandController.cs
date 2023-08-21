using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Parfume.App.Context;
using Parfume.App.Services.İnterfaces;
using Parfume.Core.Entities;
using Parfume.Service.Extentions;

namespace Parfume.App.areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,SuperAdmin")]
    public class BrandController : Controller
    {
        private readonly ParfumeDbContext _context;
        private readonly IWebHostEnvironment _environment;
        private readonly IMailService _mailService;
        public BrandController(ParfumeDbContext context, IWebHostEnvironment environment, IMailService mailService)
        {
            _context = context;
            _environment = environment;
            _mailService = mailService;
        }
        public async Task<IActionResult> Index(int page = 1)
        {
            int TotalCount = _context.Brands.Where(x => !x.IsDeleted).Count();
            ViewBag.TotalPage = (int)Math.Ceiling((decimal)TotalCount / 8);
            ViewBag.CurrentPage = page;

            IEnumerable<Brand> brands = await _context.Brands.
                Where(x => !x.IsDeleted).Skip((page - 1) * 8).Take(8).ToListAsync();

            return View(brands);
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Brand brand)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }

            brand.CreatedDate = DateTime.Now;
            await _context.AddAsync(brand);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Brand");
        }
        public async Task<IActionResult> Update(int id)
        {
            Brand? Brand = await _context.Brands.Where(x => !x.IsDeleted && x.Id == id).FirstOrDefaultAsync();
            if (Brand is null)
            {
                return NotFound();
            }
            return View(Brand);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, Brand Brand)
        {

            Brand? Update = await _context.Brands.Where(x => !x.IsDeleted && x.Id == id).FirstOrDefaultAsync();

            if (Brand is null)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return View();
            }

          
            Update.UpdatedDate = DateTime.Now;
            Update.Name = Brand.Name;
         


            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            Brand? Brand = await _context.Brands.Where(x => !x.IsDeleted && x.Id == id).FirstOrDefaultAsync();


            if (Brand is null)
            {
                return NotFound();
            }
            Brand.IsDeleted = true;
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
