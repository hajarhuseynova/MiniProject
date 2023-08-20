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
        //Alish satish
        public double BuyPrice { get; set; }
        public double SellPrice { get; set; }
        public int CountSell { get; set; }
        public DateTime TimeSell { get; set; }

        public List<CommentP> CommentPs { get; set; }   
       
        public Rating Rating { get; set; }

        //BRAND-Chanel
        public int BrandId { get; set; }
        public Brand Brand { get; set; }
        //Bottlesize
        public List<ParfumBottleSize> PerfumeBottleSizes { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ProductCode { get; set; }
        public string Info1 { get; set; }
        public string Info2 { get; set; }
        public bool isNew { get; set; }
        public bool isTrend { get; set; }
        public bool isDiscount { get; set; }
        public bool isStock { get; set; }
        public int? DiscountPrice { get; set; }
        public string? Image { get; set; }
        [NotMapped]
        public IFormFile? FormFile { get; set; }
    }
}
