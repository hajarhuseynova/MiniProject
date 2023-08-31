using Parfume.Core.Entities.BaseEntities;
using System;
using System.Collections.Generic;
using System.Text;


namespace Parfume.Core.Entities
{
	public class BasketItem:BaseEntity
	{
        public int BasketId { get; set; }
        public Basket Basket { get; set; }
        //parfum
        public int ParfumId { get; set; }
        public Parfum Parfum { get; set; }
        public int ParfumCount { get; set; }


    }
}
