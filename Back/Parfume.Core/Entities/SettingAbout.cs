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
    public class SettingAbout:BaseEntity
    {
        public string? ImageWho1 { get; set; }
        [NotMapped]
        public IFormFile? Who1FormFile { get; set; }
        public string? ImageWho2 { get; set; }
        [NotMapped]
        public IFormFile? Who2FormFile { get; set; }
        public string? ImageWhy1 { get; set; }
        [NotMapped]
        public IFormFile? Why1FormFile { get; set; }
        public string? ImageWhy2 { get; set; }
        [NotMapped]
        public IFormFile? Why2FormFile { get; set; }

        public string WhoTitle { get; set; }
        public string WhoP1 { get; set; }
        public string WhoP2 { get; set; }
        public string WhoP3 { get; set; }

        public string WhyTitle { get; set; }
        public string WhyP1 { get; set; }
        public string WhyP2 { get; set; }

        public string Icon1 { get; set; }
        public string Icon2 { get; set; }
        public string Icon3 { get; set; }
        public string Icon4 { get; set; }
        public string IconP1 { get; set; }
        public string IconP2 { get; set; }
        public string IconP3 { get; set; }
        public string IconP4 { get; set; }




    }
}
