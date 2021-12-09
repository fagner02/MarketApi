using System.Collections.Generic;
using System.Linq;
using market_api.Context;
using market_api.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace market_api.Services {
    public class ProductService {
        private readonly Db _data;
        public ProductService(Db data) {
            _data = data;
        }

        public ActionResult<List<Product>> GetAll() {
            return _data.Products.ToList();
        }

        public void Post([FromBody] Product product) {
            _data.Products.Add(product);
            _data.SaveChanges();
        }

        public Product Get([FromRoute] Guid id) {
            return _data.Products.First(x => x.ProductId == id); ;
        }
    }
}