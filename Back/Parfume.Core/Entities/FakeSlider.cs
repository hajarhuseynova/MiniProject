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
    public class FakeSlider:BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Thoughts { get; set; }
        public string? Image { get; set; }
        [NotMapped]
        public IFormFile? FormFile { get; set; }



    }
}
