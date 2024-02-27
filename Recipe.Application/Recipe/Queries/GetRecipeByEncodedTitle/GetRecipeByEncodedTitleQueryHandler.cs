using AutoMapper;
using MediatR;
using Recipe.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Application.Recipe.Queries.GetRecipeByEncodedTitle
{
    public class GetRecipeByEncodedTitleQueryHandler : IRequestHandler<GetRecipeByEncodedTitleQuery, RecipeDto>
    {
        private readonly IRecipeRepository _recipeRepository;
        private readonly IMapper _mapper;

        public GetRecipeByEncodedTitleQueryHandler(IRecipeRepository recipeRepository, IMapper mapper)
        {
            _recipeRepository = recipeRepository; 
            _mapper = mapper;
        }
        public async Task<RecipeDto> Handle(GetRecipeByEncodedTitleQuery request, CancellationToken cancellationToken)
        {
            var recipe = await _recipeRepository.GetRecipeByEncodedTitle(request.EncodedTitle);
            var dto = _mapper.Map<RecipeDto>(recipe);
            return dto;
        }
    }
}
