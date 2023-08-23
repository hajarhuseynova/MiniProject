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
    public class SettingHomePage:BaseEntity
    {
        public string TitleGift { get; set; }
        public string DescriptionGift { get; set; }
        public string? ImageGift1 { get; set; }
        [NotMapped]
        public IFormFile? Gift1FormFile { get; set; }
        public string? ImageGift2 { get; set; }
        [NotMapped]
        public IFormFile? Gift2FormFile { get; set; }

        public string DescTester { get; set; }
        public string? ImageTester { get; set; }
        [NotMapped]
        public IFormFile? TesterFormFile { get; set; }

        public string DescSmoke { get; set; }
        public string? ImageSmoke { get; set; }
        [NotMapped]
        public IFormFile? SmokeFormFile { get; set; }

    }
}
