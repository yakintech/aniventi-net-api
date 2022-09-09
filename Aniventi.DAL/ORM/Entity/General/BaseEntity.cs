﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aniventi.DAL.ORM.Entity
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }

        public DateTime AddDate { get; set; }

        public DateTime UpdateDate { get; set; }

        public DateTime? DeleteDate { get; set; }

        public bool IsDeleted { get; set; }

        //public bool IsActive { get; set; }
    }
}
