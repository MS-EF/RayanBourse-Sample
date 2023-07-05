using Domain.Entities;
using Infrastructure.EF.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EF
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppUser>().HasData(
               new AppUser()
               {
                   Id = "a93406f8-0f41-4a6a-9978-16295c5ff250",
                   UserName = "user1",
                   Email = "u@u1.com",
                   NormalizedEmail = "u@u1.com",
                   NormalizedUserName = "user1",
                   EmailConfirmed = true
               },
               new AppUser()
               {
                   Id = "a0fb49d8-6c05-4471-8bd5-94addbda612e",
                   UserName = "user2",
                   Email = "u@u2.com",
                   NormalizedEmail = "u@u2.com",
                   NormalizedUserName = "user2",
                   EmailConfirmed = true
               }
               );

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductConfig).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
