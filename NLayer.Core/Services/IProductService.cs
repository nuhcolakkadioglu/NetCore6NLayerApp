using NLayer.Core.Dtos;

namespace NLayer.Core.Services
{
	public interface IProductService : IService<Product>
	{
		Task<List<ProductWithCategoryDto>> GetProductWithCategory();
	}
}
