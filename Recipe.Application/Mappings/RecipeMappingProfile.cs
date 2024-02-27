using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Recipe.Application.ApplicationUser;
using Recipe.Application.Recipe;
using Recipe.Application.Recipe.Commands.CreateRecipe;
using Recipe.Application.Recipe.Commands.EditRecipe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Application.Mappings
{
    public class RecipeMappingProfile : Profile
    {
        private string FromFIleToPath (IFormFile photo)
        {
            var fileName = Guid.NewGuid().ToString() + "_" + photo.FileName;
            return fileName;
        }
        public RecipeMappingProfile(IUserContext userContext)
        {
            CreateMap<CreateRecipeCommand, Domain.Entities.Recipe>()
                .ForMember(c=>c.ImagePath, opt => opt.MapFrom(src=>FromFIleToPath(src.Photo!)));

            CreateMap<Domain.Entities.Recipe, RecipeDto>()
                .ForMember(r => r.IsEditable, opt => opt.MapFrom(src => src.CreatedById == userContext.GetCurrentUser()!.Id && userContext.GetCurrentUser()!=null));
            CreateMap<RecipeDto, EditRecipeCommand>().ReverseMap();

        }
    }
}
