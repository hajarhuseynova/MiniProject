using Parfume.Core.Entities.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parfume.Core.Entities
{
    public class Volume:BaseEntity
    {
        public int MilliLiters { get; set; }
        public List<ParfumVolume>? ParfumVolume { get; set; }
    }
}
