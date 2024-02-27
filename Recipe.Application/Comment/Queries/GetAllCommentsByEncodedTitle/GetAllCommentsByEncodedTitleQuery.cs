using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Application.Comment.Queries.GetAllCommentsByEncodedTitle
{
    public class GetAllCommentsByEncodedTitleQuery : IRequest<IEnumerable<CommentDto>>
    {
        public GetAllCommentsByEncodedTitleQuery(string recipeEncodedTitle)
        {
            RecipeEncodedTitle = recipeEncodedTitle;
        }

        public string RecipeEncodedTitle { get; set; }
    }
}
