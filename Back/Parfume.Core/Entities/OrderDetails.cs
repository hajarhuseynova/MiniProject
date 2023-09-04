using Parfume.Core.Entities.BaseEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Parfume.Core.Entities
{
    public class OrderDetails:BaseEntity
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Email { get; set; }
        public int Number { get; set; }
        public string Loc { get; set; }
        public string Info{ get; set; }
        public bool inMarket { get; set; }
        public bool inHome { get; set; }      
        public bool isCash { get; set; }
        public bool PayinHomewhithCard { get; set; }
        public bool withCard { get; set; }
        public long? CardNumbers { get; set; }
        public int? Tarix { get; set; }
        public int? Cvv { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
