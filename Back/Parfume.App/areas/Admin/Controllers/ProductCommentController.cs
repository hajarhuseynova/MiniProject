
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

using Microsoft.EntityFrameworkCore;
using Parfume.App.Context;
using Parfume.Core.Entities;

namespace Parfume.App.areas.Admin.Controllers
{
    [Area("Admin")]

    [Authorize(Roles = "Admin,SuperAdmin")]
    public class ProductCommentController : Controller
    {

        private readonly ParfumeDbContext _context;
        public ProductCommentController(ParfumeDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Comment> comments = await _context.Comments.Where(x => !x.IsDeleted)
                .Include(x=>x.AppUser).
                Include(x => x.Product).ToListAsync();
            return View(comments);
        }
        public async Task<IActionResult> Accept(int id)
        {
            Comment? comment = await _context.Comments.Where(x => !x.isVisible&& x.Id==id).FirstOrDefaultAsync();
            if(comment == null)
            {
                return NotFound();
            }

            comment.isVisible =true;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Reject(int id)
        {
            Comment? comment = await _context.Comments.Where(x => !x.isVisible && x.Id == id).FirstOrDefaultAsync();
            if (comment == null)
            {
                return NotFound();
            }

            comment.IsDeleted = true;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }

}
