using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NLayer.Core;
using NLayer.Core.Dtos;
using NLayer.Core.Services;

namespace NLayer.Web.Controllers
{
	public class ProductsController : Controller
	{
		private readonly IProductService _productService;
		private readonly ICategoryService _categoryService;
		private readonly IMapper _mapper;
		public ProductsController(IProductService productService, ICategoryService categoryService, IMapper mapper)
		{
			_productService = productService;
			_categoryService = categoryService;
			_mapper = mapper;
		}

		public async Task<IActionResult> Index()
		{
			var customResponse = await _productService.GetProductWithCategory();

			return View(customResponse);
		}

		public async Task<IActionResult> Save()
		{
			var categories = _mapper.Map<List<CategoryDto>>(await _categoryService.GetAllAsync());
			ViewBag.Categories = new SelectList(categories.ToList(), "Id", "Name");
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Save(ProductDto model)
		{


			if (ModelState.IsValid)
			{
				await _productService.AddAsync(_mapper.Map<Product>(model));
				return RedirectToAction(nameof(Index));
			}

			var categories = _mapper.Map<List<CategoryDto>>(await _categoryService.GetAllAsync());
			ViewBag.Categories = new SelectList(categories.ToList(), "Id", "Name");


			return View(model);
		}
	}
}
