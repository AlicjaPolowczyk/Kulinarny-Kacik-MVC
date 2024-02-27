using AutoMapper;
using MediatR;
using Recipe.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Application.Recipe.Queries.GetAllRecipes
{
    public class GetAllRecpesQueryHandler : IRequestHandler<GetAllRecipesQuery, IEnumerable<RecipeDto>>
    {
        private readonly IRecipeRepository _recipeRepository;
        private readonly IMapper _mapper;

        public GetAllRecpesQueryHandler(IRecipeRepository recipeRepository, IMapper mapper)
        {
            _recipeRepository = recipeRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<RecipeDto>> Handle(GetAllRecipesQuery request, CancellationToken cancellationToken)
        {
            var recipes = await _recipeRepository.GetAllRecipes();
            var dtos = _mapper.Map<IEnumerable<RecipeDto>>(recipes);
            return dtos;
        }
    }
}
