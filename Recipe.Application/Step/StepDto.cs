using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Application.Step
{
    public class StepDto
    {
        public IFormFile? Photo { get; set; }
        public string? ImagePath { get; set; }
        public string Description { get; set; } = default!;
    }
}
