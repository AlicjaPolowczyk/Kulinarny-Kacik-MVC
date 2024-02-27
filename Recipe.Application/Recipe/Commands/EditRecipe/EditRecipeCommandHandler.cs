using MediatR;
using Microsoft.AspNetCore.Hosting;
using Recipe.Application.ApplicationUser;
using Recipe.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Application.Recipe.Commands.EditRecipe
{
    public class EditRecipeCommandHandler : IRequestHandler<EditRecipeCommand>
    {

        private readonly IRecipeRepository _recipeRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IUserContext _userContext;

        public EditRecipeCommandHandler(IRecipeRepository recipeRepository, IWebHostEnvironment webHostEnvironment, IUserContext userContext)
        {
             _recipeRepository=recipeRepository;
             _webHostEnvironment=webHostEnvironment;
            _userContext = userContext;
        }
        public async Task Handle(EditRecipeCommand request, CancellationToken cancellationToken)
        {
            var currentUser = _userContext.GetCurrentUser();
            
            var recipe = await _recipeRepository.GetRecipeByEncodedTitle(request.EncodedTitle!);
            if (currentUser == null || currentUser.Id!=recipe.CreatedById)
            {
                return;
            }
            var oldTitle=recipe.Title;
            var oldAuthor=recipe.Author;
            recipe.Title = request.Title;
            recipe.PreparationTime = request.PreparationTime;
            recipe.BakingTime = request.BakingTime;
            recipe.NumberOfServings = request.NumberOfServings;
            recipe.Ingredients = request.Ingredients;
            recipe.Author = request.Author;
            if (request.Photo?.FileName != null)
            {
                var currentPathFile = Path.Combine(_webHostEnvironment.WebRootPath, "images", request.ImagePath!);

                var newFileName = Guid.NewGuid().ToString() + "-" + request.Photo.FileName;
                var newPathFile = Path.Combine(_webHostEnvironment.WebRootPath, "images", newFileName);
                var fileStream = new FileStream(newPathFile, FileMode.Create);
                request.Photo.CopyTo(fileStream);
                fileStream.Close();

                File.Delete(currentPathFile);

                recipe.ImagePath = newFileName;
            }

            if (request.Title != oldTitle || request.Author != oldAuthor) 
            {
                var encodedTitle = recipe.EncodedTitle.Split("-");
                var number = int.Parse(encodedTitle[encodedTitle.Length - 1]);
                recipe.EncodeTitle(number);

            }
            await _recipeRepository.Commit();

        }
    }
}
