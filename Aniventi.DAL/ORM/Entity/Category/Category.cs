using Aniventi.DAL.ORM.Entity.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aniventi.DAL.ORM.Entity.Category
{
    public class Category : BaseEntity, ISort
    {
        public int SortNumber { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }


    }
}
