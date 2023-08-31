using Parfume.Core.Entities.BaseEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Parfume.Core.Entities
{
    public class ProductCategory:BaseEntity
    {
        public string Name { get; set; }
        public List<Product>? Products { get; set; }
    }
}
