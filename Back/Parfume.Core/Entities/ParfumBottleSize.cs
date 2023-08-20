using Parfume.Core.Entities.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parfume.Core.Entities
{
    public class ParfumBottleSize:BaseEntity
    {
        public int ParfumId { get; set; }
        public int BottleSizeId { get; set; }
        public Parfum Parfum { get; set; }
        public BottleSize BottleSize { get; set; }
    }
}
