using Aniventi.DAL.ORM.Entity.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aniventi.DAL.ORM.Entity
{
    public class Brand : BaseEntity, ISort
    {
        public string Name { get; set; }
        public int SortNumber { get; set; }
    }
}
