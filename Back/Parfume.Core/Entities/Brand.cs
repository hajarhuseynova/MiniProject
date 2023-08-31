using Parfume.Core.Entities.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parfume.Core.Entities
{
    public class Brand:BaseEntity
    {
        public string Name { get; set; }
        public List<Tester>? Testers { get; set; }
        public List<Parfum>? Parfums { get; set; }

    }
}
