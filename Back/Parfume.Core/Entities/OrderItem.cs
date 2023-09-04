using Parfume.Core.Entities.BaseEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Parfume.Core.Entities
{
	public class OrderItem:BaseEntity
	{
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int ProductCount { get; set; }
    }
}
