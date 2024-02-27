using AutoMapper;
using Recipe.Application.Comment;
using Recipe.Application.Comment.Commands.CreateComment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Application.Mappings
{
    public class CommentMappingProfile : Profile
    {
        public CommentMappingProfile()
        {
            CreateMap<CreateCommentCommand, Domain.Entities.Comment>();
            CreateMap<Domain.Entities.Comment, CommentDto>();
        }
    }
}
