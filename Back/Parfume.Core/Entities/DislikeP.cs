﻿using Parfume.Core.Entities.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parfume.Core.Entities
{
    public class DislikeP : BaseEntity
    {
        public int? CommentPId { get; set; }
        public CommentP? Comment { get; set; }
        public int CountDislike { get; set; }
    }
}