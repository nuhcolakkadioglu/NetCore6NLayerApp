using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository.Seeds
{
    internal class ProductSeed : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product { Id=1, Name="kırmızı kalem",CategoryId=1,CreatedDate=DateTime.Now,Price=10,Stock=5},
                new Product { Id = 2, Name = "kırmızı defter", CategoryId = 2, CreatedDate = DateTime.Now, Price = 15, Stock = 30 },
                new Product { Id = 3, Name = "kırmızı php kitap", CategoryId = 3, CreatedDate = DateTime.Now, Price = 98, Stock = 8 }
                );
        }
    }
}
