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
    public class Brand:BaseEntity
    {
        public string Name { get; set; }
        public List<Product>? Products { get; set; }
        public string? Image { get; set; }
        [NotMapped]
        public IFormFile? FormFile { get; set; }

    }
}
