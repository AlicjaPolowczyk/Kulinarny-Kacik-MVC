using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Recipe.Application.ApplicationUser;
using Recipe.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Application.Comment.Commands.CreateComment
{
    public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand>
    {
        private readonly IRecipeRepository _recipeRepository;
        private readonly IMapper _mapper;
        private readonly ICommentRepository _commentRepository;
        private readonly IUserContext _userContext;

        public CreateCommentCommandHandler(IRecipeRepository recipeRepository, IMapper mapper, ICommentRepository commentRepository, IUserContext userContext)
        {
            _recipeRepository = recipeRepository;
            _mapper = mapper;
            _commentRepository = commentRepository;
            _userContext=userContext;
        }
        public async Task Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            var recipe = await _recipeRepository.GetRecipeByEncodedTitle(request.RecipeEncodedTitle);
            var comment = _mapper.Map<Domain.Entities.Comment>(request);
            comment.RecipeId = recipe.Id;
            comment.UserName = _userContext.GetCurrentUser()!.Email;
            await _commentRepository.CreateComment(comment);
        }
    }
}
