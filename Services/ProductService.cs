using System.Collections.Generic;
using market_api.Models;
using System;
using market_api.Dtos;
using market_api.Repositories;
using AutoMapper;

namespace market_api.Services {
    public class ProductService : IService<ProductDto> {
        private readonly IMapper _mapper;
        private readonly IRepository<Product> _repo;


        public ProductService(IMapper mapper, IRepository<Product> repo) {
            _mapper = mapper;
            _repo = repo;
        }

        public IEnumerable<ProductDto> GetAll() {
            return _mapper.Map<IEnumerable<ProductDto>>(_repo.GetAll());
        }

        public ProductDto Get(Guid id) {
            return _mapper.Map<ProductDto>(_repo.Get(id));
        }

        public ProductDto Create(ProductDto product) {
            _repo.Create(_mapper.Map<Product>(product));
            return product;
        }

        public bool Update(Guid id, ProductDto product) {
            return _repo.Update(id, _mapper.Map<Product>(product));
        }

        public bool Delete(Guid id) {
            return _repo.Delete(id);
        }
    }
}