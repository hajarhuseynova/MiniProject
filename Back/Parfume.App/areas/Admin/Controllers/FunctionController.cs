using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Parfume.App.Context;
using Parfume.Core.Entities;
using Parfume.Service.Extentions;

namespace Parfume.App.areas.Admin.Controllers
{

    [Area("Admin")]
    [Authorize(Roles = "Admin,SuperAdmin")]
    public class FunctionController : Controller
    {

        private readonly ParfumeDbContext _context;
        private readonly IWebHostEnvironment _environment;
        public FunctionController(ParfumeDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }
        public async Task<IActionResult> Index(int page = 1)
        {
            int TotalCount = _context.Functions.Where(x => !x.IsDeleted).Count();
            ViewBag.TotalPage = (int)Math.Ceiling((decimal)TotalCount / 5);
            ViewBag.CurrentPage = page;

            IEnumerable<Functions> func = await _context.Functions.
                Where(x => !x.IsDeleted).Skip((page - 1) * 5).Take(5).ToListAsync();

            return View(func);
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Functions func)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }
            if (func.FormFile == null)
            {
                ModelState.AddModelError("FormFile", "Wrong!");
                return View();
            }


            if (!FileExtention.isImage(func.FormFile))
            {
                ModelState.AddModelError("FormFile", "Wronggg!");
                return View();
            }
            if (!FileExtention.isSizeOk(func.FormFile, 1))
            {
                ModelState.AddModelError("FormFile", "Wronggg!");
                return View();
            }

            func.Image = func.FormFile.CreateImage(_environment.WebRootPath, "assets/images/");

            func.CreatedDate = DateTime.Now;
            await _context.AddAsync(func);

            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Function");
        }
        public async Task<IActionResult> Update(int id)
        {
            Functions? func = await _context.Functions.Where(x => !x.IsDeleted && x.Id == id).FirstOrDefaultAsync();
            if (func is null)
            {
                return NotFound();
            }
            return View(func);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, Functions func)
        {

            Functions? Update = await _context.Functions.Where(x => !x.IsDeleted && x.Id == id).FirstOrDefaultAsync();

            if (func is null)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return View();
            }

            if (func.FormFile is not null)
            {
                if (!FileExtention.isImage(func.FormFile))
                {
                    ModelState.AddModelError("file", "Image is required");
                    return View();
                }
                if (!FileExtention.isSizeOk(func.FormFile, 1))
                {
                    ModelState.AddModelError("file", "Image size is wrong");
                    return View();
                }
                Update.Image = func.FormFile.CreateImage(_environment.WebRootPath, "assets/image/");
            }

            Update.UpdatedDate = DateTime.Now;
            Update.Title = func.Title;
            Update.Desc = func.Desc;
            Update.Link = func.Link;
          

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            Functions? func = await _context.Functions.Where(x => !x.IsDeleted && x.Id == id).FirstOrDefaultAsync();


            if (func is null)
            {
                return NotFound();
            }
            func.IsDeleted = true;
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
