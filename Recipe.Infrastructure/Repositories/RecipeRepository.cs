using MediatR;
using Microsoft.EntityFrameworkCore;
using Recipe.Application.Recipe.Commands.CreateRecipe;
using Recipe.Domain.Entities;
using Recipe.Domain.Interfaces;
using Recipe.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Infrastructure.Repositories
{
    public class RecipeRepository : IRecipeRepository
    {
        private readonly RecipeDbContext _dbContext;

        public RecipeRepository(RecipeDbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public async Task Commit()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task CreateRecipe(Domain.Entities.Recipe recipe)
        {
            _dbContext.Recipes.Add(recipe);
            await _dbContext.SaveChangesAsync();
     
        }

        public async Task DeleteRecipe(string encodeTitle)
        {
            var recipe = await _dbContext.Recipes.FirstAsync(r => r.EncodedTitle == encodeTitle);
            _dbContext.Remove(recipe);
            await _dbContext.SaveChangesAsync();    

        }

        public async Task<IEnumerable<Domain.Entities.Recipe>> GetAllRecipes()
        {
            return await _dbContext.Recipes.ToListAsync();
        }

        public async Task<Domain.Entities.Recipe?> GetLastRecipeByAuthor(string author)
        {

            return await _dbContext.Recipes.Where(r => r.Author == author).OrderBy(r => r.Id).LastOrDefaultAsync();

        }

        public async Task<Domain.Entities.Recipe> GetRecipeByEncodedTitle(string encodedTitle)
        {
            return await _dbContext.Recipes.FirstAsync(r => r.EncodedTitle == encodedTitle);
        }
    }
}
