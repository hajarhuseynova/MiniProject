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
    public class PlaceController : Controller
    {
        private readonly ParfumeDbContext _context;
        private readonly IWebHostEnvironment _environment;
        private readonly IMailService _mailService;
        public PlaceController(ParfumeDbContext context, IWebHostEnvironment environment, IMailService mailService)
        {
            _context = context;
            _environment = environment;
            _mailService = mailService;
        }
        public async Task<IActionResult> Index(int page = 1)
        {
            int TotalCount = _context.Places.Where(x => !x.IsDeleted).Count();
            ViewBag.TotalPage = (int)Math.Ceiling((decimal)TotalCount / 5);
            ViewBag.CurrentPage = page;

            IEnumerable<Place> places = await _context.Places.
                Where(x => !x.IsDeleted).Skip((page - 1) * 5).Take(5).ToListAsync();

            return View(places);
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Place places)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }
            if (places.FormFile is null)
            {
                ModelState.AddModelError("file", "Image is required");
                return View();
            }

            if (!FileExtention.isImage(places.FormFile))
            {
                ModelState.AddModelError("file", "Image is required");
                return View();
            }
            if (!FileExtention.isSizeOk(places.FormFile, 1))
            {
                ModelState.AddModelError("file", "Image size is wrong");
                return View();
            }

            places.CreatedDate = DateTime.Now;
            places.Image = places.FormFile.CreateImage(_environment.WebRootPath, "assets/images/");
            await _context.AddAsync(places);

            await _context.SaveChangesAsync();

            var mails = await _context.Subscribes.Where(x => !x.IsDeleted).ToListAsync();
            string? link = Request.Scheme + "://" + Request.Host + $"/Place/detail/{places.Id}";
            foreach (var mail in mails)
            {
                await _mailService.Send("hajarih@code.edu.az", mail.Email, link, "New GiftBox");
            }


            return RedirectToAction("Index", "place");
        }
        public async Task<IActionResult> Update(int id)
        {
            Place? places = await _context.Places.Where(x => !x.IsDeleted && x.Id == id).FirstOrDefaultAsync();
            if (places is null)
            {
                return NotFound();
            }
            return View(places);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, Place places)
        {

            Place? Update = await _context.Places.Where(x => !x.IsDeleted && x.Id == id).FirstOrDefaultAsync();

            if (places is null)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return View();
            }

            if (places.FormFile is not null)
            {
                if (!FileExtention.isImage(places.FormFile))
                {
                    ModelState.AddModelError("file", "Image is required");
                    return View();
                }
                if (!FileExtention.isSizeOk(places.FormFile, 1))
                {
                    ModelState.AddModelError("file", "Image size is wrong");
                    return View();
                }
                Update.Image = places.FormFile.CreateImage(_environment.WebRootPath, "assets/images/");
            }
            Update.UpdatedDate = DateTime.Now;
            Update.Title = places.Title;
            Update.Address = places.Address;
            Update.Location = places.Location;
            Update.Phone1 = places.Phone1;
            Update.Phone2 = places.Phone2;


            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            Place? places = await _context.Places.Where(x => !x.IsDeleted && x.Id == id).FirstOrDefaultAsync();


            if (places is null)
            {
                return NotFound();
            }
            places.IsDeleted = true;
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
    }
