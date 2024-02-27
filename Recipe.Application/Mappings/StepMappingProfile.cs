using AutoMapper;
using Microsoft.AspNetCore.Http;
using Recipe.Application.Step;
using Recipe.Application.Step.Commands.CreateStep;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Application.Mappings
{
    public class StepMappingProfile : Profile
    {
        private string FromFIleToPath(IFormFile photo)
        {
            var fileName = Guid.NewGuid().ToString() + "_" + photo.FileName;
            return fileName;
        }
        public StepMappingProfile()
        {
            CreateMap<CreateStepCommand, Domain.Entities.Step>()
                .ForMember(s => s.ImagePath, opt => opt.MapFrom(src => FromFIleToPath(src.Photo!)));

            CreateMap<Domain.Entities.Step, StepDto>();
        }
    }
}
