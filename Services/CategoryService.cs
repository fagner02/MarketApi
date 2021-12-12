using System.Collections.Generic;
using market_api.Models;
using System;
using market_api.Dtos;
using market_api.Repositories;
using AutoMapper;
using System.Threading.Tasks;

namespace market_api.Services {
    public class CategoryService : IService<CategoryDto, CategoryCreateDto> {
        private readonly IMapper _mapper;
        private readonly CategoryRepository _repo;


        public CategoryService(IMapper mapper, CategoryRepository repo) {
            _mapper = mapper;
            _repo = repo;
        }

        public async Task<IEnumerable<CategoryDto>> GetAll() {
            return _mapper.Map<IEnumerable<CategoryDto>>(await _repo.GetAll());
        }

        public async Task<CategoryDto> Get(Guid id) {
            return _mapper.Map<CategoryDto>(await _repo.Get(id));
        }

        public async Task<CategoryCreateDto> Create(CategoryCreateDto product) {
            await _repo.Create(_mapper.Map<Category>(product));
            return product;
        }

        public async Task<bool> Update(Guid id, CategoryDto product) {
            return await _repo.Update(id, _mapper.Map<Category>(product));
        }

        public async Task<bool> Delete(Guid id) {
            return await _repo.Delete(id);
        }

        public async Task<IEnumerable<ProductDto>> GetDetails(Guid id) {
            return _mapper.Map<IEnumerable<ProductDto>>(await _repo.GetDetails(id));
        }
    }
}