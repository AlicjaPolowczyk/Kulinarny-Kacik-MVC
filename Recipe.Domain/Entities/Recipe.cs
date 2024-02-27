using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Domain.Entities
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Title { get; set; } = default!;
        public string PreparationTime { get; set; } = default!;
        public string BakingTime { get; set; } = default!;
        public string NumberOfServings { get; set; } = default!;
        public string Ingredients { get; set; } = default!;
        public string EncodedTitle { get; private set; } = default!;
        public string ImagePath { get; set; } = default!;
        public string Author {  get; set; } = default!;
        public void EncodeTitle(int number)
        {
            EncodedTitle = (Title + " " + Author+" "+number.ToString()).Replace(" ", "-").ToLower();
        }

        public List<Domain.Entities.Step> Steps { get; set; } = new();
        public List<Domain.Entities.Comment> Comments { get; set; } = new();

        public string CreatedById { get; set; } = default!;
        public ApplicationUser CreatedBy { get; set; } = default!;
    }
}
