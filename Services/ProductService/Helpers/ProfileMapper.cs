using AutoMapper;
using Events;
using ProductService.Entities;
using ProductService.Models;

namespace ProductService.Helpers
{
    public class ProfileMapper : Profile
    {
        public ProfileMapper()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();
            CreateMap<Product, ProductCreated>().ReverseMap();
            CreateMap<Product, ProductUpdated>().ReverseMap();
            CreateMap<ProductDto, ProductCreated>().ReverseMap();
            CreateMap<ProductDto, UpdateProductDto>().ReverseMap();
        }
    }

}
