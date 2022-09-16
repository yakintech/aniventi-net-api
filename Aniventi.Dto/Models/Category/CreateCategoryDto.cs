using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aniventi.Dto.Models.General;

namespace Aniventi.Dto.Models.Category
{
    public class CreateCategoryDto : BaseDto
    {
        public string Name { get; set; }

        public string? Description { get; set; }
    }
}
