using Parfume.Core.Entities;
using Parfume.Core.Entities.BaseEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Parfume.Core.Entities
{
	public class Order:BaseEntity
	{
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public decimal TotalPrice { get; set; }
        public List<OrderItem> orderItems { get; set; }
        public bool isAccepted { get; set; }
        public bool isCompleted { get; set; }
    }
}
