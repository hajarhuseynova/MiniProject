using Microsoft.AspNetCore.Http;
using Parfume.Core.Entities.BaseEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parfume.Core.Entities
{
    public class Parfum:BaseEntity
    {
        public string Title { get; set; }
        public string Desc { get; set; }
        public string Info1 { get; set; }
        public string Info2 { get; set; }
        public string ProductCode { get; set; }
        public bool IsNew { get; set; }
        public bool IsTrend { get; set; }
        public bool IsDiscount { get; set; }
        public bool IsStock { get; set; }
        public int? DiscountPercentage { get; set; } 
        public string? Image { get; set; }
        [NotMapped]
        public IFormFile? FormFile { get; set; }
        public string BuyPrice { get; set; }
        public string SellPrice { get; set; }
        public int? CountSell { get; set; }
        public DateTime? TimeSell { get; set; }
        //Brand
        public int? BrandId { get; set; }
        public Brand? Brand { get; set; }
        //Volume
        public List<ParfumVolume>? ParfumVolume { get; set; }
        [NotMapped]
        public List<int>? ParfumVolumeIds { get; set; }
        public List<CommentP>? CommentPs { get; set; }
        
        public Rating? Rating { get; set; }



    }
}
