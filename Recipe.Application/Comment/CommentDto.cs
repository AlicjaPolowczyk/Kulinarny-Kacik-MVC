using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Application.Comment
{
    public class CommentDto
    {
        public string UserName { get; set; } = default!;
        public string Description { get; set; } = default!;
    }
}
