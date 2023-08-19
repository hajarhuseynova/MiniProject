using Parfume.Core.Entities.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parfume.Core.Entities
{
    public class ParfumeBottleSize:BaseEntity
    {
        public int ParfumeId { get; set; }
        public int BottleSizeId { get; set; }
        public Parfume Parfume { get; set; }
        public BottleSize BottleSize { get; set; }
    }
}
