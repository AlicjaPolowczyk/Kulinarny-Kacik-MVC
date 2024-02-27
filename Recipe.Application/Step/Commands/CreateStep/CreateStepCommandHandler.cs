using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Recipe.Application.ApplicationUser;
using Recipe.Domain.Entities;
using Recipe.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Application.Step.Commands.CreateStep
{
    public class CreateStepCommandHandler : IRequestHandler<CreateStepCommand>
    {
        private readonly IMapper _mapper;
        private readonly IStepRepository _stepRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IRecipeRepository _recipeRepository;
        private readonly IUserContext _userContext;

        public CreateStepCommandHandler(IMapper mapper, IStepRepository stepRepository, IWebHostEnvironment webHostEnvironment, IRecipeRepository recipeRepository, IUserContext userContext)
        {
            _mapper=mapper;
            _stepRepository=stepRepository;
            _webHostEnvironment=webHostEnvironment;
            _recipeRepository =recipeRepository;
            _userContext = userContext;

        }
        public async Task Handle(CreateStepCommand request, CancellationToken cancellationToken)
        {
            var currentUser = _userContext.GetCurrentUser();
            var recipe = await _recipeRepository.GetRecipeByEncodedTitle(request.RecipeEncodedTitle);

            if (currentUser == null || currentUser.Id != recipe.CreatedById)
            {
                return;
            }
            var step = _mapper.Map<Domain.Entities.Step>(request);
            var folder = Path.Combine(_webHostEnvironment.WebRootPath, "steps");
            var file = Path.Combine(folder, step.ImagePath);
            var fileStream = new FileStream(file, FileMode.Create);
            request.Photo!.CopyTo(fileStream);
            fileStream.Close();
            step.RecipeId = recipe.Id; 
            await _stepRepository.CreateStep(step);
        }
    }
}
