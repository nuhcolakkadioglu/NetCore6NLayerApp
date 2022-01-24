using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NLayer.Core.Dtos;
using NLayer.Core.Services;

namespace NLayer.API.Controllers
{


	public class CategoriesController : CustomBaseController
	{
		private readonly ICategoryService _categoryService;
		private readonly IMapper _mapper;

        public CategoriesController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
		public async Task<IActionResult> GetAll()
        {
			var categories =await _categoryService.GetAllAsync();
			var categorieDto = _mapper.Map<List<CategoryDto>>(categories.ToList());

			return CreateActionResult(CustomResponseDto<List<CategoryDto>>.Success(200, categorieDto));

		}


		[HttpGet("GetSingleCateogryByWithProduct/{id}")]
		public async Task<IActionResult> GetSingleCateogryByWithProduct(int id)
		{
			return CreateActionResult(await _categoryService.GetSingleCateogryByWithProductAsync(id));
		}
	}
}
