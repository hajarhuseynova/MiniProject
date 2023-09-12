using Parfume.Core.Entities;

namespace Parfume.App.ViewModels
{
    public class ReportViewModel
    {
        public List<Order> Orders { get; set; }
        public Order Order { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        public OrderItem OrderItem { get; set; }
        public DateTime SelectedDate { get; set; } // Seçilen tarihi tutmak için eklenen özellik
        public decimal TotalSales { get; set; } // Toplam Satış
        public decimal TotalPurchases { get; set; } // Toplam Alış
        public decimal TotalProfit { get; set; } // Toplam Kar
    }

}
