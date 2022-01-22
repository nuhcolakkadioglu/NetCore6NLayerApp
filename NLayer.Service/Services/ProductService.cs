using AutoMapper;
using NLayer.Core;
using NLayer.Core.Dtos;
using NLayer.Core.Repositories;
using NLayer.Core.Services;
using NLayer.Core.UnitOfWorks;

namespace NLayer.Service.Services
{
    public class ProductService : Service<Product>, IProductService
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;
        public ProductService(IUnitOfWork unitOfWork, IGenericRepository<Product> genericRepository, IProductRepository repository, IMapper mapper) : base(unitOfWork, genericRepository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<List<ProductWithCategoryDto>>> GetProductWithCategory()
        {
            var products = _mapper.Map<List<ProductWithCategoryDto>>(await _repository.GetProductsWitCategory());
            return CustomResponseDto<List<ProductWithCategoryDto>>.Success(200, products);

        }
    }
}
