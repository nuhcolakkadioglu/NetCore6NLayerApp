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
    internal class CategorySeed : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
                new Category { CreatedDate = DateTime.Now, Id = 1, Name = "php" },
                new Category { CreatedDate = DateTime.Now, Id = 2, Name = "Kalem" },
                new Category { CreatedDate = DateTime.Now, Id = 3, Name = "Silgi" }
                );
              
        }
    }
}
