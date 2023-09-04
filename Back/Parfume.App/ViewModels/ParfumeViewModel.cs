using Parfume.Core.Entities;

namespace Parfume.App.ViewModels
{
    public class ParfumeViewModel
    {
        public IEnumerable<Slider> Slides { get; set; }
        public IEnumerable<Brand> Brands { get; set; }
        public IEnumerable<Functions> Functions { get; set; }
        public IEnumerable<CommentP> CommentPs { get; set; }
        public IEnumerable<DislikeP> DislikePs { get; set; }
        public IEnumerable<LikeP> LikePs { get; set; }
        public IEnumerable<Rating> RatingPs { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public Product Product { get; set; }


    }
}
