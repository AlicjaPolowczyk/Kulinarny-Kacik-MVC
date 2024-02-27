using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Application.Step.Commands.CreateStep
{
    public class CreateStepCommandValidator : AbstractValidator<CreateStepCommand>
    {
        public CreateStepCommandValidator() 
        {
            RuleFor(s=>s.Description).NotEmpty().WithMessage("Podaj opis");
            RuleFor(s=>s.Photo).NotEmpty().WithMessage("Wgraj zdjęcie");
        }

    }
}
