using MediatR;
using Recipe.Application.Recipe.Queries.GetRecipeByEncodedTitle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Application.Comment.Commands.CreateComment
{
    public class CreateCommentCommand : CommentDto, IRequest
    {
        public string RecipeEncodedTitle { get; set; } = default!;
    }
}
