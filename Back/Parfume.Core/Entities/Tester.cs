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
    public class Tester:BaseEntity
    {
        public string Title { get; set; }
        public string BuyPrice { get; set; }
        public string SellPrice { get; set; }
        public int? CountSell{ get; set; }
        public DateTime? TimeSell { get; set; }

        public string? Image { get; set; }
        [NotMapped]
        public IFormFile? FormFile { get; set; }
        public int? BrandId { get; set; }
        public Brand? Brand { get; set; }


    }
}
