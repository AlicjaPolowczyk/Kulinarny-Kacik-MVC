using FluentValidation;
using Microsoft.AspNetCore.Http;
using Recipe.Application.Recipe.Queries.GetAllRecipes;
using Recipe.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Application.Recipe.Commands.CreateRecipe
{
    public class CreateRecipeCommandValidator : AbstractValidator<CreateRecipeCommand>
    {
        public CreateRecipeCommandValidator()
        {
            RuleFor(r => r.Title).NotEmpty().WithMessage("Podaj nazwę");
            RuleFor(r => r.PreparationTime).NotEmpty().WithMessage("Podaj czas przygotowania");
            RuleFor(r => r.BakingTime).NotEmpty().WithMessage("Podaj czas pieczenia");
            RuleFor(r => r.NumberOfServings).NotEmpty().WithMessage("Podaj liczbę porcji");
            RuleFor(r => r.Ingredients).NotEmpty().WithMessage("Podaj składniki");
            RuleFor(r => r.Photo).NotEmpty().WithMessage("Wgraj zdjęcie");
            RuleFor(r => r.Author).NotEmpty().WithMessage("Podaj autora");
        }
    }
}
