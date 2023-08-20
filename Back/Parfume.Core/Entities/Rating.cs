using Parfume.Core.Entities.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parfume.Core.Entities
{
    public class Rating:BaseEntity
    {
        public double AvarageRating { get; set; }   
        public double RatingCount { get; set; }
        public int ParfumId { get; set; }
        public Parfum Parfum { get; set; }
        public int CommentPId { get; set; }
        public CommentP Comment { get; set; }

    }
}
