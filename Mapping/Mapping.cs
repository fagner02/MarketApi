using AutoMapper;
using market_api.Models;
using market_api.Dtos;

namespace market_api.Mapping {
    public class Mapping : Profile {
        public Mapping() {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Product, ProductCreateDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, CategoryCreateDto>().ReverseMap();
        }
    }
}