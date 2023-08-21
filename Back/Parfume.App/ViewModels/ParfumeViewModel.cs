using Parfume.Core.Entities;

namespace Parfume.App.ViewModels
{
    public class ParfumeViewModel
    {
        public IEnumerable<Slider> Slides { get; set; }
        public IEnumerable<Brand> Brands { get; set; }

    }
}
