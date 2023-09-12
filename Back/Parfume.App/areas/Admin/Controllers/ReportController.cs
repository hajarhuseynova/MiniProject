using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Parfume.App.Context;
using Parfume.App.ViewModels;
using Parfume.Core.Entities;

namespace areas.Admin.Controllers
{
    [Area("Admin")]
    public class ReportController : Controller
    {
        private readonly ParfumeDbContext _context;
        private readonly IWebHostEnvironment _environment;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signinManager;

        public ReportController(ParfumeDbContext context, IWebHostEnvironment environment, UserManager<AppUser> userManager, SignInManager<AppUser> signinManager)
        {
            _context = context;
            _environment = environment;
            _userManager = userManager;
            _signinManager = signinManager;
        }

        public async Task<IActionResult> Index()
        {
            ReportViewModel reportViewModel = new ReportViewModel();
            reportViewModel.Order = await _context.Orders.Where(x => !x.IsDeleted).Include(x => x.orderItems).FirstOrDefaultAsync();
            reportViewModel.OrderItem = await _context.OrderItems.Where(x => !x.IsDeleted).Include(x => x.Product).FirstOrDefaultAsync();

            reportViewModel.Orders = await _context.Orders.Where(x => !x.IsDeleted).Include(x => x.orderItems).ToListAsync();
            reportViewModel.OrderItems = await _context.OrderItems.Where(x => !x.IsDeleted).Include(x => x.Product).ToListAsync();



            return View(reportViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Index(ReportViewModel viewModel)
        {
            // Seçilen tarihi ViewModel'den alın
            DateTime selectedDate = viewModel.SelectedDate;

            // Seçilen tarihe göre siparişleri filtreleyin ve ViewModel'i güncelleyin
            viewModel.Orders = await _context.Orders
                .Where(x => !x.IsDeleted && x.CreatedDate.Date == selectedDate.Date)
                .Include(x => x.orderItems)
                .ToListAsync();
            viewModel.OrderItems = await _context.OrderItems
                .Where(x => !x.IsDeleted && x.CreatedDate.Date == selectedDate.Date)
                .Include(x => x.Product)
                .ToListAsync();

            viewModel.TotalSales = viewModel.Orders.Sum(x => x.TotalPrice);
            viewModel.TotalPurchases = viewModel.Orders.Sum(x => x.TotalBuyPrice);
            viewModel.TotalProfit = viewModel.TotalSales - viewModel.TotalPurchases;



            return View(viewModel);
        }

    }
}
