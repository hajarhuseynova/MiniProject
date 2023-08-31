﻿using Microsoft.AspNetCore.Http;
using Parfume.Core.Entities.BaseEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Parfume.Core.Entities
{
    public class Smoke:BaseEntity
    {
        public string Title { get; set; }
        public string Desc { get; set; }
        public string Info1 { get; set; }
        public string Info2 { get; set; }
        public string ProductCode { get; set; }
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
    }
}