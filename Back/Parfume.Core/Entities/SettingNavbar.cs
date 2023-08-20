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
    public class SettingNavbar:BaseEntity
    {
        public string? Logo { get; set; }
        [NotMapped]
        public IFormFile? LogoFormFile { get; set; }
        public string? Hamburger { get; set; }
        [NotMapped]
        public IFormFile? HamburgerFormFile { get; set; }
        public string? Delete { get; set; }
        [NotMapped]
        public IFormFile? DeleteFormFile { get; set; }

        public string Icon1 { get; set; }
        public string Icon2 { get; set; }
        public string Icon3 { get; set; }

        public string SiderbarP1 { get; set; }
        public string SiderbarP2 { get; set; }
        public string SiderbarP3 { get; set; }
        public string SiderbarP4 { get; set; }
        public string SiderbarP5 { get; set; }
        public string SiderbarP6 { get; set; }

    }
}
