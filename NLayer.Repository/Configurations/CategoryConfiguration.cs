using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core;

namespace NLayer.Repository.Configurations
{
	internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
	{
		public void Configure(EntityTypeBuilder<Category> builder)
		{
			builder.HasKey(m => m.Id);
			builder.Property(m => m.Id).UseIdentityColumn();
			builder.Property(m => m.Name).IsRequired().HasMaxLength(50);

			builder.ToTable("Categories");
		}
	}
}
