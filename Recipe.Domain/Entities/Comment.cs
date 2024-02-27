using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Domain.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public string UserName { get; set; } = default!;
        public string Description { get; set; } = default!;
        public int RecipeId { get; set; } = default!;
        public Recipe Recipe { get; set; } = default!;
    }
}
