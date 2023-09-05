using Parfume.Core.Entities;

namespace Parfume.App.ViewModels
{
    public class ProductViewModel
    {
        public List<Product> Products { get; set; }
        public Product Product { get; set; }
        public List<Functions> Functions { get; set; }
        public List<Brand>? Brands { get; set; }
        public List<ProductCategory>? Category { get; set; }





    }
}
