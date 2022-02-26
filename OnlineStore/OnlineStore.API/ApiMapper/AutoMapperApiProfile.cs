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
            CreateMap<CategoryDTO, PopularProductVM>();

        }
    }
}
