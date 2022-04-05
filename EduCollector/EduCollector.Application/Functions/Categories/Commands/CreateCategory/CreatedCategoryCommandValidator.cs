using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduCollector.Application
{
    public class CreatedCategoryCommandValidator : AbstractValidator<CreatedCategoryCommand>
    {
        public CreatedCategoryCommandValidator()
        {
            RuleFor(c => c.Name)
                .MinimumLength(2)
                .MaximumLength(15)
                .WithMessage("{PropertyName} Length is between 2 and 15")
                .NotEmpty()
                .WithMessage("{PropertyName} Length is between 2 and 15");
            RuleFor(c => c.DisplayName)
                .MinimumLength(2).MaximumLength(15)
                .WithMessage("{PropertyName} Length is between 2 and 15");
        }
    }
}
