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
    public class SettingContact:BaseEntity
    {
        public string Title { get; set; }   
        public string Description { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Email { get; set; }
        public string Loc1 { get; set; }
        public string Loc2 { get; set; }
        public string? ImageLoc { get; set; }
        [NotMapped]
        public IFormFile? Loc { get; set; }
        public string? ImageTel { get; set; }
        [NotMapped]
        public IFormFile? Phone { get; set; }
        public string? ImageEmail { get; set; }
        [NotMapped]
        public IFormFile? Ema { get; set; }


    }
}
