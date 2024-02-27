using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Application.Step.Queries.GetAllStepsByEncodedTitle
{
    public class GetAllStepsByEncodedTitleQuery : IRequest<IEnumerable<StepDto>>
    {
        public string EncodedTitle { get; set; }
        public GetAllStepsByEncodedTitleQuery(string encodedTitle)
        {
            EncodedTitle = encodedTitle;
        }
    }
}
