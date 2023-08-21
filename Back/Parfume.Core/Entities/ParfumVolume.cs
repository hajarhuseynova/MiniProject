using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parfume.Core.Entities.BaseEntities
{
    public class ParfumVolume :BaseEntity
    {
        public int ParfumId { get; set; }
        public Parfum Parfum { get; set; }
        public int VolumeId { get; set; }
        public Volume Volume { get; set; }
    }
}
