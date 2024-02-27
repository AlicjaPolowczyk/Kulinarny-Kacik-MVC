using Azure.Core;
using Microsoft.EntityFrameworkCore;
using Recipe.Application.Step;
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
    public class StepRepository : IStepRepository
    {
        private readonly RecipeDbContext _dbContext;

        public StepRepository(RecipeDbContext dbContext)
        {
            _dbContext=dbContext;
        }
        public async Task CreateStep(Step step)
        {
            _dbContext.Steps.Add(step);
            await _dbContext.SaveChangesAsync();
        }

        public async Task <IEnumerable<Domain.Entities.Step>> GetAllStepsByEncodedTitle(string encodedTitle)
        {
            var steps=await _dbContext.Steps.Where(s=>s.Recipe.EncodedTitle == encodedTitle).ToListAsync();
            return steps;
        }
    }
}
