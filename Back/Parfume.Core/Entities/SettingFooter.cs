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
    public class SettingFooter:BaseEntity
    {
        public string Title1 { get; set; }
        public string Title2 { get; set; }
        public string Title3 { get; set; }
        public string Title4 { get; set; }

        public string Title1Par1 { get; set; }
        public string Title1Par2 { get; set; }
        public string Title2Par1 { get; set; }
        public string Title2Par2 { get; set; }
        public string Title3Par1 { get; set; }
        public string Title3Par2 { get; set; }
        public string Title4Par1 { get; set; }
        public string Title4Par2 { get; set; }
        
        public string FootIcon1 { get; set; }
        public string FootIcon2 { get; set; }
        public string FootIcon3 { get; set; }
        public string FootIcon4 { get; set; }
        public string Link1 { get; set; }
        public string Link2 { get; set; }
        public string Link3 { get; set; }
        public string Link4 { get; set; }



    }
}
