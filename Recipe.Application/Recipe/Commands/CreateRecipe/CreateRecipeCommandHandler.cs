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

namespace Recipe.Application.Recipe.Commands.CreateRecipe
{
    public class CreateRecipeCommandHandler : IRequestHandler<CreateRecipeCommand>
    {
        private readonly IRecipeRepository _repository;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IUserContext _userContext;

        public CreateRecipeCommandHandler(IRecipeRepository repository, IMapper mapper, IWebHostEnvironment webHostEnvironment, IUserContext userContext )
        {
            _repository= repository;
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;
            _userContext = userContext;
        }
        public async Task Handle(CreateRecipeCommand request, CancellationToken cancellationToken)
        {
            var recipe = _mapper.Map<Domain.Entities.Recipe>(request);
            var folder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
            var file = Path.Combine(folder, recipe.ImagePath);
            var fileStream = new FileStream(file, FileMode.Create);
            request.Photo!.CopyTo(fileStream);
            fileStream.Close();

            var lastRecipe=await _repository.GetLastRecipeByAuthor(recipe.Author);
            if (lastRecipe == null)
            {
                recipe.EncodeTitle(1);
            }
            else
            {
                var encodedTitle = lastRecipe.EncodedTitle.Split("-");
                var number = int.Parse(encodedTitle[encodedTitle.Length - 1])+1;
                recipe.EncodeTitle(number);
            }

            recipe.CreatedById = _userContext.GetCurrentUser().Id;
            await _repository.CreateRecipe(recipe);
        }
    }
}
