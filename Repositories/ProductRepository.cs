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

        public IEnumerable<Product> GetAll() {
            return _data.Products.ToList();
        }

        public Product Get(Guid id) {
            return _data.Products.FirstOrDefault(x => x.ProductId == id);
        }

        public void Create(Product product) {
            _data.Products.Add(product);
            _data.SaveChanges();
        }

        public bool Update(Guid id, Product product) {
            product.ProductId = id;
            Product temp = _data.Products.FirstOrDefault(x => x.ProductId == id);
            if (temp == null) {
                return false;
            }
            _data.Entry(temp).State = EntityState.Detached;
            _data.Products.Update(product);
            _data.SaveChanges();
            return true;
        }

        public bool Delete(Guid id) {
            var temp = _data.Products.FirstOrDefault(x => x.ProductId == id);
            if (temp == null) {
                return false;
            }
            _data.Products.Remove(temp);
            _data.SaveChanges();
            return true;
        }
    }
}