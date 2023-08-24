using Parfume.Core.Entities.BaseEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Parfume.Core.Entities
{
    public class Basket:BaseEntity
    {
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public List<BasketItem> basketItems { get; set; }
    }
}
