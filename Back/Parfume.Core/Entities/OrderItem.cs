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
        //parfum
        public int ParfumId { get; set; }
        public Parfum Parfum { get; set; }
        //tutsu
        public int SmokeId { get; set; }
        public Smoke Smoke { get; set; }
        //tester
        public int TesterId { get; set; }
        public Tester Tester { get; set; }
        //qutu
        public int GiftBoxId { get; set; }
        public GiftBox GiftBox { get; set; }
        //say
        public int ParfumCount { get; set; }
    }
}
