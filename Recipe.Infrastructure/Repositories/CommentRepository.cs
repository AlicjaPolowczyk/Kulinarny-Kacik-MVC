using Microsoft.EntityFrameworkCore;
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
    public class CommentRepository : ICommentRepository
    {
        private readonly RecipeDbContext _dbContext;

        public CommentRepository(RecipeDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task CreateComment(Comment comment)
        {
            _dbContext.Comments.Add(comment);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Comment>> GetAllCommentsByEncodedTitle(string recipeEncodedTitle)
        {
            return await _dbContext.Comments.Where(c => c.Recipe.EncodedTitle == recipeEncodedTitle).ToListAsync();
        }
    }   
}
