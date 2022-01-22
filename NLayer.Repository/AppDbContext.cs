using Microsoft.EntityFrameworkCore;
using NLayer.Core;
using System.Reflection;

namespace NLayer.Repository
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductFeature> ProductFeatures { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {

            foreach (var item in ChangeTracker.Entries())
            {
                if (item.Entity is BaseEntity entityreference)
                {
                    switch (item.State)
                    {
                        case EntityState.Added:
                            entityreference.CreatedDate = DateTime.Now;
                            break;
                        case EntityState.Modified:
                            Entry(entityreference).Property(m=>m.CreatedDate).IsModified = false;
                            entityreference.Updateddate = DateTime.Now;
                            break;

                    }
                }
            }
           return base.SaveChangesAsync(cancellationToken);
        }
		public override int SaveChanges()
		{
            foreach (var item in ChangeTracker.Entries())
            {
                if (item.Entity is BaseEntity entityreference)
                {
                    switch (item.State)
                    {
                        case EntityState.Added:
                            entityreference.CreatedDate = DateTime.Now;
                            break;
                        case EntityState.Modified:
                            Entry(entityreference).Property(m => m.CreatedDate).IsModified = false;
                            entityreference.Updateddate = DateTime.Now;
                            break;

                    }
                }
            }
            return base.SaveChanges();
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<ProductFeature>().HasData(
                    new ProductFeature
                    {
                        Color = "Red",
                        Height = 40,
                        Width = 80,
                        Id = 1,
                        ProductId = 1,
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
