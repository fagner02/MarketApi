using AutoMapper;
using market_api.Models;
using market_api.Dtos;

namespace market_api.Mapping {
    public class Mapping : Profile {
        public Mapping() {
            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>();
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();
        }
    }
}