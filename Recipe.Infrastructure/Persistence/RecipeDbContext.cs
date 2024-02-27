using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Recipe.Application.Mappings;
using Recipe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Infrastructure.Persistence
{
    public class RecipeDbContext : IdentityDbContext<ApplicationUser>
    {
        public RecipeDbContext(DbContextOptions<RecipeDbContext> options) : base(options) { }

        public DbSet<Domain.Entities.Recipe> Recipes { get; set; }

        public DbSet<Step> Steps { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Domain.Entities.Recipe>()
                  .HasMany(r => r.Steps)
                  .WithOne(s => s.Recipe)
                  .HasForeignKey(s => s.RecipeId);

            modelBuilder.Entity<Domain.Entities.Recipe>()
                .HasMany(r => r.Comments)
                .WithOne(c=>c.Recipe)
                .HasForeignKey(c=> c.RecipeId);

            modelBuilder.Entity<Domain.Entities.Recipe>()
                .HasOne(r => r.CreatedBy)
                .WithMany(u => u.Recipes)
                .HasForeignKey(r => r.CreatedById);
                
                
        }




    }
}
