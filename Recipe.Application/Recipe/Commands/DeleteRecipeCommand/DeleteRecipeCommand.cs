using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Application.Recipe.Commands.DeleteRecipeCommand
{
    public class DeleteRecipeCommand : IRequest
    {
        public string EncodedTitle { get; set; }

        public DeleteRecipeCommand(string encodedTitle)
        {
             EncodedTitle = encodedTitle;
        }
    }
}
