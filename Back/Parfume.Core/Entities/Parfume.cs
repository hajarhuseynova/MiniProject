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
    public class Parfume:BaseEntity
    {
        //BRAND-Chanel
        public int BrandId { get; set; }
        public Brand Brand { get; set; }
        //Bottlesize
        public List<ParfumeBottleSize> PerfumeBottleSizes { get; set; }


        public string Title { get; set; }
        public string Description { get; set; }
        public string ProductCode { get; set; }
        public string Info1 { get; set; }
        public string Info2 { get; set; }
        public int Price { get; set; }
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
