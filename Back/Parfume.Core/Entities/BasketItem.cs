using Parfume.Core.Entities.BaseEntities;
using System;
using System.Collections.Generic;
using System.Text;


namespace Parfume.Core.Entities
{
	public class BasketItem:BaseEntity
	{
        public int ProductId { get; set; }
        public int BasketId { get; set; }
        public Basket Basket { get; set; }
        public Product Product { get; set; }
        public int ProductCount { get; set; }



    }
}
