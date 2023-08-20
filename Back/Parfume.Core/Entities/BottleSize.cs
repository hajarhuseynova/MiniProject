using Parfume.Core.Entities.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parfume.Core.Entities
{
    public class BottleSize:BaseEntity
    {
        public int Milliliters { get; set; }
        public List<ParfumBottleSize> ParfumBottleSizes { get; set; }
    }
}
