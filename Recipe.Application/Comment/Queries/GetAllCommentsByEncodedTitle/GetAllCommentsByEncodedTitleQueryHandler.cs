using AutoMapper;
using MediatR;
using Recipe.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Application.Comment.Queries.GetAllCommentsByEncodedTitle
{
    public class GetAllCommentsByEncodedTitleQueryHandler : IRequestHandler<GetAllCommentsByEncodedTitleQuery, IEnumerable<CommentDto>>
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;

        public GetAllCommentsByEncodedTitleQueryHandler(ICommentRepository commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<CommentDto>> Handle(GetAllCommentsByEncodedTitleQuery request, CancellationToken cancellationToken)
        {
            var comments = await _commentRepository.GetAllCommentsByEncodedTitle(request.RecipeEncodedTitle);
            var dtos = _mapper.Map<IEnumerable<CommentDto>>(comments);
            return dtos;
        }
    }
}
