using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NLayer.Core;
using NLayer.Core.Dtos;
using NLayer.Core.Services;
using NLayer.Web.Services;

namespace NLayer.Web.Controllers
{
	public class ProductsController : Controller
	{
		private readonly ProductApiService _productApiService;
		private readonly CategoryApiService _categoryApiService;

		public ProductsController(ProductApiService productApiService, CategoryApiService categoryApiService)
        {
            _productApiService = productApiService;
            _categoryApiService = categoryApiService;
        }

		public async Task<IActionResult> Index()
		{
			var customResponse = await _productApiService.GetProductWithCategoryAsync();

			return View(customResponse);
		}

		public async Task<IActionResult> Save()
		{
			var categories = await _categoryApiService.GetAllAsync();
			ViewBag.Categories = new SelectList(categories, "Id", "Name");
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Save(ProductDto model)
		{


			if (ModelState.IsValid)
			{
				await _productApiService.SaveAsync(model);

				return RedirectToAction(nameof(Index));
			}


			ViewBag.Categories = new SelectList(await _categoryApiService.GetAllAsync(), "Id", "Name");


			return View(model);
		}

		public async Task<IActionResult> Update(int id)
		{
			var product = await _productApiService.GetByIdAsync(id);

			ViewBag.Categories = new SelectList(await _categoryApiService.GetAllAsync(), "Id", "Name", product.CategoryId);
			return View(product);
		}

		[HttpPost]
		public async Task<IActionResult> Update(ProductDto model)
		{


			if (ModelState.IsValid)
			{
				await _productApiService.UpdateAsync(model);
				return RedirectToAction(nameof(Index));
			}

			var categories =await _categoryApiService.GetAllAsync();
			ViewBag.Categories = new SelectList(categories.ToList(), "Id", "Name",model.CategoryId);


			return View(model);
		}

		public async Task<IActionResult> Remove(int id)
		{
			await _productApiService.DeleteAsync(id);
			return RedirectToAction(nameof(Index));
		}
	}
}
