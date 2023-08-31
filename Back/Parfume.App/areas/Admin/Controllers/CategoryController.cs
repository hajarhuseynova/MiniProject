using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Parfume.App.Context;
using Parfume.Core.Entities;

namespace areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,SuperAdmin")]
    public class CategoryController : Controller
    {
        private readonly ParfumeDbContext _context;
        private readonly IWebHostEnvironment _environment;
        public CategoryController(ParfumeDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }
        public async Task<IActionResult> Index(int ?page=1)
        {
            int TotalCount = _context.Category.Where(x => !x.IsDeleted).Count();
            ViewBag.TotalPage = (int)Math.Ceiling((decimal)TotalCount / 5);
            ViewBag.CurrentPage = page;

            IEnumerable<ProductCategory> cat = await _context.Category.
                   Where(x => !x.IsDeleted).Skip(((int)page - 1) * 5).Take(5).ToListAsync();
            return View(cat);
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductCategory category)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            await _context.AddAsync(category);
            await _context.SaveChangesAsync();
            return RedirectToAction("index", "category");
        }
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            ProductCategory? category = await _context.Category.Where(x => !x.IsDeleted && x.Id == id).FirstOrDefaultAsync();
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, ProductCategory postCategory)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            ProductCategory? category = await _context.Category.Where(x => !x.IsDeleted && x.Id == id).FirstOrDefaultAsync();
            if (category == null)
            {
                return NotFound();
            }
            category.Name = postCategory.Name;
            await _context.SaveChangesAsync();
            return RedirectToAction("index", "category");
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            ProductCategory? category = await _context.Category.Where(x => !x.IsDeleted && x.Id == id).FirstOrDefaultAsync();
            if (category == null)
            {
                return NotFound();
            }

            category.IsDeleted = true;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
