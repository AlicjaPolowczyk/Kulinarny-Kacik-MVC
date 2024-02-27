using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public List<Recipe> Recipes { get; set; } = new();
    }
}
