using Aniventi.Dto.Models.Category;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aniventi.Dto.Validations.Category
{
    public class CreateCategoryDtoValidator : AbstractValidator<CreateCategoryDto>
    {
        public CreateCategoryDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name alanı boş bırakılamaz!")
                .MaximumLength(20).WithMessage("Name alanı maksimum 20 karakter olabilir!");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description alanı boş bırakılamaz");
        }
    }
}
