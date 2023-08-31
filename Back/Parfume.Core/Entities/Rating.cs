using Parfume.Core.Entities.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parfume.Core.Entities
{
    public class Rating : BaseEntity
    {
        public double RatingCount { get; set; }
        public int one { get; set; }
        public int two { get; set; }
        public int three { get; set; }
        public int four { get; set; }
        public int fifth { get; set; }
        //public int? ParfumId { get; set; }
        //public Parfum? Parfum { get; set; }
        public int? CommentPId { get; set; }
        public CommentP? Comment { get; set; }

    }
}
