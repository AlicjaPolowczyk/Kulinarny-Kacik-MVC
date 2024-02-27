using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Application.Recipe
{
    public class RecipeDto
    {
        public string Title { get; set; } = default!;
        public string PreparationTime { get; set; } = default!;
        public string BakingTime { get; set; } = default!;
        public string NumberOfServings { get; set; } = default!;
        public string Ingredients { get; set; } = default!;

        public string? EncodedTitle { get; set; }

        public string? ImagePath { get; set; }

        public IFormFile? Photo { get; set; }

        public string Author { get; set; } = default!;

        public bool IsEditable { get; set; } = default!;

    }
}
