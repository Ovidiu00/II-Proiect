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
            CreateMap<AddProductVM, AddProductDTO>()
                .ForMember(dt => dt.Price, opt => opt.MapFrom(src => double.Parse(src.Price)))
                .ForMember(dt => dt.Quantity, opt => opt.MapFrom(src => int.Parse(src.Quantity)));

            CreateMap<EditProductVM, EditProductDTO>()
                .ForMember(dt => dt.Price, opt => opt.MapFrom(src => double.Parse(src.Price)))
                .ForMember(dt => dt.Quantity, opt => opt.MapFrom(src => int.Parse(src.Quantity)));

        }
    }
}
