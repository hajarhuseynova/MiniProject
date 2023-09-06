using Parfume.Core.Entities.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parfume.Core.Entities
{
    public class Comment:BaseEntity
    {
        public int ProductId { get; set; }
        public Product? Product { get; set; }
        public string AppUserId { get; set; }
        public AppUser? AppUser { get; set; }
        public string Title { get; set; }
        public string Desc { get; set; }
        public int Rating { get; set; }
        public bool isVisible { get; set; }

    }
}
