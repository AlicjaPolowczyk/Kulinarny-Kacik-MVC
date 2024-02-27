using Microsoft.Extensions.DependencyInjection;
using Recipe.Application.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Recipe.Application.Recipe.Commands.CreateRecipe;
using Recipe.Domain.Interfaces;
using Microsoft.AspNetCore.Hosting;
using FluentValidation.AspNetCore;
using FluentValidation;
using Recipe.Application.ApplicationUser;

namespace Recipe.Application.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddApplication(this IServiceCollection services) 
        {
            // services.AddAutoMapper(typeof(RecipeMappingProfile));
            //services.AddAutoMapper(typeof(StepMappingProfile));
            // services.AddAutoMapper(typeof(CommentMappingProfile));

            services.AddScoped(provider => new MapperConfiguration(cfg =>
            {
                var scope = provider.CreateScope();
                var userContext = scope.ServiceProvider.GetRequiredService<IUserContext>();
                cfg.AddProfile(new RecipeMappingProfile(userContext));
                cfg.AddProfile(new StepMappingProfile());
                cfg.AddProfile(new CommentMappingProfile());
            }).CreateMapper()
            );
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssemblies(typeof(CreateRecipeCommand).Assembly);
            });
            services.AddValidatorsFromAssemblyContaining<CreateRecipeCommandValidator>()
                  .AddFluentValidationAutoValidation()
                  .AddFluentValidationClientsideAdapters();
            services.AddScoped<IUserContext, UserContext>();


        }
    }
}
