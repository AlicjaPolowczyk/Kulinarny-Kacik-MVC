using Recipe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Domain.Interfaces
{
    public interface IRecipeRepository
    {
       Task CreateRecipe(Domain.Entities.Recipe recipe);
       Task <IEnumerable<Domain.Entities.Recipe>> GetAllRecipes();

       Task DeleteRecipe(string encodedTitle);

       Task <Domain.Entities.Recipe> GetRecipeByEncodedTitle (string encodedTitle);

        Task Commit();

        Task<Domain.Entities.Recipe?> GetLastRecipeByAuthor(string author);

    }
}
