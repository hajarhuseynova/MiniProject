using Parfume.Core.Entities;

namespace Parfume.App.ViewModels
{
    public class ReportViewModel
    {
        public List<Order> Orders { get; set; }
        public Order Order { get; set; }

        public List<OrderItem> OrderItems { get; set; }
        public OrderItem OrderItem { get; set; }

    }
}
