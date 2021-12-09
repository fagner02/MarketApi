using System;
using System.Collections.Generic;
using System.Linq;
using market_api.Models;
using market_api.Context;
using Microsoft.EntityFrameworkCore;

namespace market_api.Repositories {

    public class CategoryRepository : IRepository<Category> {
        private readonly Db _data;

        public CategoryRepository(Db data) {
            _data = data;
        }

        public IEnumerable<Category> GetAll() {
            return _data.Categories.ToList();
        }

        public Category Get(Guid id) {
            return _data.Categories.FirstOrDefault(x => x.Id == id);
        }

        public void Create(Category product) {
            _data.Categories.Add(product);
            _data.SaveChanges();
        }

        public bool Update(Guid id, Category product) {
            product.Id = id;
            Category temp = _data.Categories.FirstOrDefault(x => x.Id == id);
            if (temp == null) {
                return false;
            }
            _data.Entry(temp).State = EntityState.Detached;
            _data.Categories.Update(product);
            _data.SaveChanges();
            return true;
        }

        public bool Delete(Guid id) {
            var temp = _data.Categories.FirstOrDefault(x => x.Id == id);
            if (temp == null) {
                return false;
            }
            _data.Categories.Remove(temp);
            _data.SaveChanges();
            return true;
        }
    }
}