using AutoMapper;
using NLayer.Core;
using NLayer.Core.Dtos;
using NLayer.Core.Repositories;
using NLayer.Core.Services;
using NLayer.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Service.Services
{
    public class CategoryService : Service<Category>, ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryService(IUnitOfWork unitOfWork, IGenericRepository<Category> genericRepository, ICategoryRepository categoryRepository, IMapper mapper) : base(unitOfWork, genericRepository)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<CategoryWithProduct>> GetSingleCateogryByWithProductAsync(int categoryId)
        {
            var data = _mapper.Map<CategoryWithProduct>(await _categoryRepository.GetSingleCateogryByWithProductAsync(categoryId));

            return CustomResponseDto<CategoryWithProduct>.Success(200, data); ;
        }
    }
}
