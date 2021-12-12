using System.Threading.Tasks;
using System.Collections.Generic;
using market_api.Models;
using System;
using market_api.Dtos;
using market_api.Repositories;
using AutoMapper;

namespace market_api.Services {
    public class ProductService : IService<ProductDto, ProductCreateDto> {
        private readonly IMapper _mapper;
        private readonly ProductRepository _repo;


        public ProductService(IMapper mapper, ProductRepository repo) {
            _mapper = mapper;
            _repo = repo;
        }

        public async Task<IEnumerable<ProductDto>> GetAll() {
            return _mapper.Map<IEnumerable<ProductDto>>(await _repo.GetAll());
        }

        public async Task<ProductDto> Get(Guid id) {
            return _mapper.Map<ProductDto>(await _repo.Get(id));
        }

        public async Task<ProductCreateDto> Create(ProductCreateDto product) {
            await _repo.Create(_mapper.Map<Product>(product));
            return product;
        }

        public async Task<bool> Update(Guid id, ProductDto product) {
            return await _repo.Update(id, _mapper.Map<Product>(product));
        }

        public async Task<bool> Delete(Guid id) {
            return await _repo.Delete(id);
        }

        public async Task<CategoryDto> GetDetails(Guid id) {
            return _mapper.Map<CategoryDto>(await _repo.GetDetails(id));
        }
    }
}