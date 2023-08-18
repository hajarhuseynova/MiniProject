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
    public class GiftBoxController : Controller
    {
        private readonly ParfumeDbContext _context;
        private readonly IWebHostEnvironment _environment;
        private readonly IMailService _mailService;
        public GiftBoxController(ParfumeDbContext context, IWebHostEnvironment environment, IMailService mailService)
        {
            _context = context;
            _environment = environment;
            _mailService = mailService;
        }
        public async Task<IActionResult> Index(int page=1)
        {
            int TotalCount = _context.GiftBoxes.Where(x => !x.IsDeleted).Count();
            ViewBag.TotalPage = (int)Math.Ceiling((decimal)TotalCount / 5);
            ViewBag.CurrentPage = page;
            IEnumerable<GiftBox> gift = await _context.GiftBoxes.
                Where(x => !x.IsDeleted).Skip((page - 1) * 5).Take(5).ToListAsync();
            return View(gift);
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(GiftBox gift)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }
            if (gift.FormFile is null)
            {
                ModelState.AddModelError("file", "Image is required");
                return View();
            }

            if (!FileExtention.isImage(gift.FormFile))
            {
                ModelState.AddModelError("file", "Image is required");
                return View();
            }
            if (!FileExtention.isSizeOk(gift.FormFile, 1))
            {
                ModelState.AddModelError("file", "Image size is wrong");
                return View();
            }

            gift.CreatedDate = DateTime.Now;
            gift.Image = gift.FormFile.CreateImage(_environment.WebRootPath, "assets/images/");
            await _context.AddAsync(gift);
            await _context.SaveChangesAsync();

            var mails = await _context.Subscribes.Where(x => !x.IsDeleted).ToListAsync();
            string? link = Request.Scheme + "://" + Request.Host + $"/Giftbox/detail/{gift.Id}";
            foreach (var mail in mails)
            {
                await _mailService.Send("hajarih@code.edu.az", mail.Email, link, "New GiftBox");
            }

            return RedirectToAction("Index", "GiftBox");
        }
        public async Task<IActionResult> Update(int id)
        {
            GiftBox? slides = await _context.GiftBoxes.Where(x => !x.IsDeleted && x.Id == id).FirstOrDefaultAsync();
            if (slides is null)
            {
                return NotFound();
            }
            return View(slides);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, GiftBox gift)
        {

            GiftBox? Update = await _context.GiftBoxes.Where(x => !x.IsDeleted && x.Id == id).FirstOrDefaultAsync();

            if (gift is null)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return View();
            }

            if (gift.FormFile is not null)
            {
                if (!FileExtention.isImage(gift.FormFile))
                {
                    ModelState.AddModelError("file", "Image is required");
                    return View();
                }
                if (!FileExtention.isSizeOk(gift.FormFile, 1))
                {
                    ModelState.AddModelError("file", "Image size is wrong");
                    return View();
                }
                Update.Image = gift.FormFile.CreateImage(_environment.WebRootPath, "assets/image/");
            }
            Update.UpdatedDate = DateTime.Now;
            Update.Title = gift.Title;
            Update.Desc= gift.Desc;
            Update.Price= gift.Price;   
        
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
           GiftBox? giftBoxes = await _context.GiftBoxes.Where(x => !x.IsDeleted && x.Id == id).FirstOrDefaultAsync();


            if (giftBoxes is null)
            {
                return NotFound();
            }
            giftBoxes.IsDeleted = true;
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
