using Parfume.Core.Entities.BaseEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Parfume.Core.Entities
{
    public class Log:BaseEntity
    {
        public string AppUserId { get; set; }
        public string Action { get; set; }
    }
}
