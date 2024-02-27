using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Domain.Interfaces
{
    public interface ICommentRepository
    {
        Task CreateComment(Domain.Entities.Comment comment);
        Task <IEnumerable<Domain.Entities.Comment>> GetAllCommentsByEncodedTitle(string recipeEncodedTitle);
    }
}
