using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using market_api.Models;
using market_api.Context;
using Microsoft.EntityFrameworkCore;

namespace market_api.Repositories {

    public class ProductRepository : IRepository<Product> {
        private readonly Db _data;

        public ProductRepository(Db data) {
            _data = data;
        }

        public async Task<IEnumerable<Product>> GetAll() {
            return await _data.Products.ToListAsync();
        }

        public async Task<Product> Get(Guid id) {
            return await _data.Products.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task Create(Product product) {
            await _data.Products.AddAsync(product);
            await _data.SaveChangesAsync();
        }

        public async Task<bool> Update(Guid id, Product product) {
            product.Id = id;
            Product temp = await _data.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (temp == null) {
                return false;
            }
            _data.Entry(temp).State = EntityState.Detached;
            _data.Products.Update(product);
            await _data.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(Guid id) {
            var temp = await _data.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (temp == null) {
                return false;
            }
            _data.Products.Remove(temp);
            await _data.SaveChangesAsync();
            return true;
        }
    }
}