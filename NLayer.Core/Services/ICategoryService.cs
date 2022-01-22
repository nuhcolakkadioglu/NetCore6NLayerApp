using NLayer.Core.Dtos;

namespace NLayer.Core.Services
{
	public interface ICategoryService : IService<Category>
	{
		Task<CustomResponseDto<CategoryWithProduct>> GetSingleCateogryByWithProductAsync(int categoryId);

	}
}
