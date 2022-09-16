using Aniventi.Dto.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aniventi.Dto.Models.Category
{
    public class CategoryListDto : BaseDto
    {
        public int SortNumber { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
