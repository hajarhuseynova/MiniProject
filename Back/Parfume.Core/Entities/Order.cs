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
        public int TotalPrice { get; set; }
        public List<OrderItem> orderItems { get; set; }
        public bool isAccepted { get; set; }
        public bool isCompleted { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Email { get; set; }
        public int Number { get; set; }
        public string Loc { get; set; }
        public string Info { get; set; }
        public string? Where { get; set; }
        public string? What { get; set; }
        public long? CardNumbers { get; set; }
        public int? Tarix { get; set; }
        public int? Cvv { get; set; }
    }
}
