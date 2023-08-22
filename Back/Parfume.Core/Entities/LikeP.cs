using Parfume.Core.Entities.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parfume.Core.Entities
{
    public class LikeP : BaseEntity
    {
        public int? CommentPId { get; set; }
        public CommentP? Comment { get; set; }
        public int CountLike { get; set; }
    }
}
