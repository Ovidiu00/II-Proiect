using AutoMapper;
using OnlineStore.API.ViewModels;
using OnlineStore.Business.DTOs;
using OnlineStore.DataAccess.Models.Entities;

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
            CreateMap<AddProductDTO, AddProductVM>();
            CreateMap<AddProductDTO, Product>();

        }
    }
}
