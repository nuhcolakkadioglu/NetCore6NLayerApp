using Microsoft.EntityFrameworkCore;
using NLayer.Core;
using NLayer.Repository.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt):base(opt)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductFeature> ProductFeatures { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<ProductFeature>().HasData(
                    new ProductFeature
                    {
                        Color ="Red",
                        Height =40,
                        Width =80, 
                        Id =1,
                        ProductId =1,
                    },
                    new ProductFeature
                    {
                        Color = "Blue",
                        Height = 50,
                        Width = 20,
                        Id = 2,
                        ProductId = 3,
                    }
                );

            base.OnModelCreating(modelBuilder);
        }

    }
}
