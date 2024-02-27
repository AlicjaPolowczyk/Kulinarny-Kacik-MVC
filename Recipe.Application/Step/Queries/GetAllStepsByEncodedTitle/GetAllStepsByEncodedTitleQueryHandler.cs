using AutoMapper;
using MediatR;
using Recipe.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Application.Step.Queries.GetAllStepsByEncodedTitle
{
    public class GetAllStepsByEncodedTitleQueryHandler : IRequestHandler<GetAllStepsByEncodedTitleQuery, IEnumerable<StepDto>>
    {
        private readonly IStepRepository _stepRepository;
        private readonly IMapper _mapper;

        public GetAllStepsByEncodedTitleQueryHandler(IStepRepository stepRepository, IMapper mapper)
        {
            _stepRepository = stepRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<StepDto>> Handle(GetAllStepsByEncodedTitleQuery request, CancellationToken cancellationToken)
        {
            var steps = await _stepRepository.GetAllStepsByEncodedTitle(request.EncodedTitle);
            var stepsdto = _mapper.Map<IEnumerable<StepDto>>(steps);
            return stepsdto;
        }
    }
}
