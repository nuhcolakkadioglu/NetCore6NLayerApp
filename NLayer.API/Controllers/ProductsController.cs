using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayer.Core;
using NLayer.Core.Dtos;
using NLayer.Core.Services;

namespace NLayer.API.Controllers
{

    public class ProductsController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IProductService _service;

        public ProductsController(IMapper mapper,  IProductService productService)
        {
            _mapper = mapper;
            _service = productService;
        }

        [HttpGet("GetProductWithcCategory")]
        public async Task<IActionResult> GetProductWithcCategory()
        {

            return CreateActionResult(await _service.GetProductWithCategory());
        }


        [HttpGet]
        public async Task<IActionResult> All()
        {
            var products = await _service.GetAllAsync();
            var productDto = _mapper.Map<List<ProductDto>>(products);

            return CreateActionResult(CustomResponseDto<List<ProductDto>>.Success(200, productDto));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var products = await _service.GetByIdAsync(id);
            var productDto = _mapper.Map<ProductDto>(products);

            return CreateActionResult(CustomResponseDto<ProductDto>.Success(200, productDto));
        }
        [HttpPost]
        public async Task<IActionResult> Save(ProductDto model)
        {
            var products = await _service.AddAsync(_mapper.Map<Product>(model));

            var productDto = _mapper.Map<ProductDto>(products);

            return CreateActionResult(CustomResponseDto<ProductDto>.Success(201, productDto));
        }
        [HttpPut]
        public async Task<IActionResult> Update(ProductUpdateDto model)
        {
            await _service.UpdateAsync(_mapper.Map<Product>(model));

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var productDelete = await _service.GetByIdAsync(id);

            if (productDelete == null)
                return CreateActionResult(CustomResponseDto<NoContentDto>.Fail(404, "Kayıt bulunamadı"));

            await _service.RemoveAsync(productDelete);

            var productDto = _mapper.Map<ProductDto>(productDelete);

            return CreateActionResult(CustomResponseDto<ProductDto>.Success(200, productDto));
        }

    }
}
