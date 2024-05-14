using AutoMapper;
using Ecom.Core.Dtos;
using Ecom.Core.Entities;
namespace Ecom.API.MappingProfiles
{
    public class MappingCategory:Profile
    {
        public MappingCategory()
        {
            CreateMap<CategoryDto, Category>().ReverseMap();
            CreateMap<ListingCategoryDto, Category>().ReverseMap();
            CreateMap<ProductDto, Product>().ReverseMap();
            CreateMap<CreateProductDto, Product>().ReverseMap();
            

        }
    }
}
