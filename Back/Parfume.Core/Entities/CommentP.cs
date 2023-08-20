using Parfume.Core.Entities.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parfume.Core.Entities
{
    public class CommentP:BaseEntity
    {
        public int ParfumeId { get; set; }
        public Parfum Parfume { get; set; }
        public string Title { get; set; }
        public string Desc { get; set; }    
        public Rating Rating { get; set; }
        public ICollection<LikeP> Likes { get; set; }
        public ICollection<DislikeP> Dislikes { get; set; }


    }
}
