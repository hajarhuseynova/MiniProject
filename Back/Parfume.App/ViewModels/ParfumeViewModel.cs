using Parfume.Core.Entities;

namespace Parfume.App.ViewModels
{
    public class ParfumeViewModel
    {
        public IEnumerable<Slider> Slides { get; set; }
        public IEnumerable<Brand> Brands { get; set; }
        public IEnumerable<Functions> Functions { get; set; }

        public IEnumerable<Volume> Volumes { get; set; }

        public IEnumerable<Parfum> Parfumes { get; set; }
        public Parfum Parfum { get; set; }


    }
}
