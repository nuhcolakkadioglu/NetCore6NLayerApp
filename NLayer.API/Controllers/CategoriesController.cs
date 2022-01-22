using Microsoft.AspNetCore.Mvc;
using NLayer.Core.Services;

namespace NLayer.API.Controllers
{


	public class CategoriesController : CustomBaseController
	{
		private readonly ICategoryService _categoryService;

		public CategoriesController(ICategoryService categoryService)
		{
			_categoryService = categoryService;
		}

		[HttpGet("GetSingleCateogryByWithProduct/{id}")]
		public async Task<IActionResult> GetSingleCateogryByWithProduct(int id)
		{
			return CreateActionResult(await _categoryService.GetSingleCateogryByWithProductAsync(id));
		}
	}
}
