using Parfume.Core.Entities;

namespace Parfume.App.ViewModels
{
    public class ParfumeViewModel
    {
        public IEnumerable<Slider> Slides { get; set; }
        public IEnumerable<Brand> Brands { get; set; }
        public IEnumerable<Functions> Functions { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public Product Product { get; set; }


    }
}
