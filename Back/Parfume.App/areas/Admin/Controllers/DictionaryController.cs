using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Parfume.App.Context;
using Parfume.App.Services.İnterfaces;
using Parfume.Core.Entities;

namespace areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,SuperAdmin")]
    public class DictionaryController : Controller
    {
        private readonly ParfumeDbContext _context;
        private readonly IWebHostEnvironment _environment;
        private readonly IMailService _mailService;
        public DictionaryController(ParfumeDbContext context, IWebHostEnvironment environment, IMailService mailService)
        {
            _context = context;
            _environment = environment;
            _mailService = mailService;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Product> prod = await _context.Products.Include(x => x.Category).
               Where(x => !x.IsDeleted).ToListAsync();

            return View(prod);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Product = await _context.Products.Where(x => !x.IsDeleted).ToListAsync();
            return View();
        }
        [HttpPost]
     
        public async Task<IActionResult> Create(string key, string value)
        {
            ViewBag.Product = await _context.Products.Where(x => !x.IsDeleted).Include(x=>x.Properties).Include(x=>x.Category).ToListAsync();

            Product testpro = await _context.Products.Include(x=>x.Category).Include(x=>x.Properties).FirstOrDefaultAsync(x => x.Id == 3);
            if (testpro == null) return NotFound();

            if (testpro.Properties == null)
            {
                testpro.Properties = new Dictionary<string, string>();
            }



            testpro.Properties.Add(key, value);

            int diff= await _context.SaveChangesAsync(); // Use await here for asynchronous saving
            if (diff == 0)
            {
                Console.WriteLine("jksdnfkjsd");
            }


            return RedirectToAction("Index", "Dictionary");
        }

    }
}
