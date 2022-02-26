using AutoMapper;
using OnlineStore.Business.DTOs;
using OnlineStore.DataAccess.Models.Entities;

namespace OnlineStore.Business.BusinessMapper
{
    public class AutoMapperBussinesProfile:Profile
    {
        public AutoMapperBussinesProfile()
        {
            CreateMap<Product, ProductDTO>();
            CreateMap<Category, CategoryDTO>();
        }
    }
}
