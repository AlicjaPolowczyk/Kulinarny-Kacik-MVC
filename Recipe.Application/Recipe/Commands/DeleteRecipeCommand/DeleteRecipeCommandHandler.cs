using MediatR;
using Microsoft.AspNetCore.Hosting;
using Recipe.Application.ApplicationUser;
using Recipe.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Application.Recipe.Commands.DeleteRecipeCommand
{
    public class DeleteRecipeCommandHandler : IRequestHandler<DeleteRecipeCommand>
    {
        private readonly IRecipeRepository _recipeRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IUserContext _userContext;

        public DeleteRecipeCommandHandler(IRecipeRepository recipeRepository, IWebHostEnvironment webHostEnvironment, IUserContext userContext)
        {
            _recipeRepository = recipeRepository;
            _webHostEnvironment = webHostEnvironment;
            _userContext = userContext;
        }

        public async Task Handle(DeleteRecipeCommand request, CancellationToken cancellationToken)
        {
            var currentUser = _userContext.GetCurrentUser();
            var recipe = await _recipeRepository.GetRecipeByEncodedTitle(request.EncodedTitle);

            if (currentUser == null || currentUser.Id != recipe.CreatedById)
            {
                return;
            }
            
            await _recipeRepository.DeleteRecipe(request.EncodedTitle);
            var fileName = recipe.ImagePath;
            var filePath = Path.Combine(_webHostEnvironment.WebRootPath, "images", fileName);
            File.Delete(filePath);
        }
    }
}
