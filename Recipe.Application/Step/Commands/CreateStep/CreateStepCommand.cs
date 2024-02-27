using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Application.Step.Commands.CreateStep
{
    public class CreateStepCommand : StepDto, IRequest
    {
        public string RecipeEncodedTitle { get; set; } = default!;
    }
}
