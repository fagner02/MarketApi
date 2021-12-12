using System;
using System.Collections.Generic;
using System.Linq;
using market_api.Models;
using market_api.Context;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace market_api.Repositories {

    public class CategoryRepository : IRepository<Category, IEnumerable<Product>> {
        private readonly Db _data;

        public CategoryRepository(Db data) {
            _data = data;
        }

        public async Task<IEnumerable<Category>> GetAll() {
            return await _data.Categories.ToListAsync();
        }

        public async Task<Category> Get(Guid id) {
            return await _data.Categories.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task Create(Category product) {
            await _data.Categories.AddAsync(product);
            await _data.SaveChangesAsync();
        }

        public async Task<bool> Update(Guid id, Category product) {
            product.Id = id;
            Category temp = await _data.Categories.FirstOrDefaultAsync(x => x.Id == id);
            if (temp == null) {
                return false;
            }
            _data.Entry(temp).State = EntityState.Detached;
            _data.Categories.Update(product);
            await _data.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(Guid id) {
            var temp = await _data.Categories.FirstOrDefaultAsync(x => x.Id == id);
            if (temp == null) {
                return false;
            }
            _data.Categories.Remove(temp);
            await _data.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Product>> GetDetails(Guid id) {
            return await _data.Products.Where(x => x.CategoryId == id).ToListAsync();
        }
    }
}