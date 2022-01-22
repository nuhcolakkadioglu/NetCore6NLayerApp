using AutoMapper;
using NLayer.Core;
using NLayer.Core.Dtos;

namespace NLayer.Service.Mapping
{
	public class MapProfile : Profile
	{
		public MapProfile()
		{
			CreateMap<Product, ProductDto>().ReverseMap();
			CreateMap<Category, CategoryDto>().ReverseMap();
			CreateMap<ProductFeature, ProductFeatureDto>().ReverseMap();
			CreateMap<ProductUpdateDto, Category>();
			CreateMap<Product, ProductWithCategoryDto>().ReverseMap();
			CreateMap<Category, CategoryWithProduct>().ReverseMap();

		}
	}
}
