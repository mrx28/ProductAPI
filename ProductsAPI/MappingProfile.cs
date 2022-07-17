using AutoMapper;
using ProductsAPI.Dto;
using ProductsAPI.Entities;

namespace ProductsAPI
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDto>();

        }
    }
}
