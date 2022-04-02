using AutoMapper;
using OnlineStore.API.ViewModels;
using OnlineStore.Business.DTOs;

namespace OnlineStore.API.AutoMapper
{
    public class AutoMapperApiProfile : Profile
    {
        public AutoMapperApiProfile()
        {
            CreateMap<ProductDTO, PopularProductVM>();
            CreateMap<ProductDTO, RecentProductVM>();
            CreateMap<CategoryDTO, PopularProductVM>();
            CreateMap<CategoryDTO, CategoryVM>();
            CreateMap<ProductDTO, ProductVM>();
            CreateMap<AddCategoryVM,AddCategoryDTO>();
            CreateMap<EditCategoryVM,EditCategoryDTO>();

        }
    }
}
