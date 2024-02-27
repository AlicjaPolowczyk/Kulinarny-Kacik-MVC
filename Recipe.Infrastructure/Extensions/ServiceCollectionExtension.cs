using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Recipe.Domain.Entities;
using Recipe.Domain.Interfaces;
using Recipe.Infrastructure.Persistence;
using Recipe.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddDbContext<RecipeDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("Recipe")));
            services.AddDefaultIdentity<ApplicationUser>()
                .AddEntityFrameworkStores<RecipeDbContext>();

            services.AddScoped<IRecipeRepository, RecipeRepository>();
            services.AddScoped<IStepRepository, StepRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();
        }
    }
}
