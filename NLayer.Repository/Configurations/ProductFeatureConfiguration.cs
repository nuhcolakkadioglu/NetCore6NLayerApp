using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core;

namespace NLayer.Repository.Configurations
{
	public class ProductFeatureConfiguration : IEntityTypeConfiguration<ProductFeature>
	{
		public void Configure(EntityTypeBuilder<ProductFeature> builder)
		{
			builder.HasKey(m => m.Id);
			builder.Property(m => m.Id).UseIdentityColumn();
			builder.HasOne(m => m.Product).WithOne(m => m.ProductFeature).HasForeignKey<ProductFeature>(m => m.ProductId);
		}
	}
}
