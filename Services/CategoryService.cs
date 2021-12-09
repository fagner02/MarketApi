using System.Collections.Generic;
using market_api.Models;
using System;
using market_api.Dtos;
using market_api.Repositories;
using AutoMapper;

namespace market_api.Services {
    public class CategoryService : IService<CategoryDto> {
        private readonly IMapper _mapper;
        private readonly IRepository<Category> _repo;


        public CategoryService(IMapper mapper, IRepository<Category> repo) {
            _mapper = mapper;
            _repo = repo;
        }

        public IEnumerable<CategoryDto> GetAll() {
            return _mapper.Map<IEnumerable<CategoryDto>>(_repo.GetAll());
        }

        public CategoryDto Get(Guid id) {
            return _mapper.Map<CategoryDto>(_repo.Get(id));
        }

        public CategoryDto Create(CategoryDto product) {
            _repo.Create(_mapper.Map<Category>(product));
            return product;
        }

        public bool Update(Guid id, CategoryDto product) {
            return _repo.Update(id, _mapper.Map<Category>(product));
        }

        public bool Delete(Guid id) {
            return _repo.Delete(id);
        }
    }
}