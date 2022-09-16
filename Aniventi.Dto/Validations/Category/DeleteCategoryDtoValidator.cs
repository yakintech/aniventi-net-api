using Aniventi.Dto.Models.Category;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aniventi.Dto.Validations.Category
{
    public class DeleteCategoryDtoValidator : AbstractValidator<DeleteCategoryDto>
    {
        public DeleteCategoryDtoValidator()
        {
            RuleFor(q =>q.Id).NotEmpty();
        }
    }
}
