using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Application.Recipe.Queries.GetAllRecipes
{
    public class GetAllRecipesQuery : IRequest<IEnumerable<RecipeDto>>
    {
    }
}
