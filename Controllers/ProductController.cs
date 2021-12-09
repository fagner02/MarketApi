using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System;
using market_api.Services;
using market_api.Dtos;

namespace market_api.Controllers {
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase {
        private readonly ProductService _productService;

        public ProductsController(ProductService productService) {
            _productService = productService;
        }

        [HttpGet]
        public ActionResult<List<ProductDto>> GetProducts() {
            return Ok(_productService.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<ProductDto> GetProduct([FromRoute] Guid id) {
            ProductDto temp = _productService.Get(id);
            if (temp == null) {
                return NotFound();
            }
            return Ok(temp);
        }

        [HttpPost]
        public ActionResult Post([FromBody] ProductDto product) {
            _productService.Create(product);
            return Ok(product);
        }

        [HttpPut("{id}")]
        public ActionResult Put([FromRoute] Guid id, [FromBody] ProductDto product) {
            if (!_productService.Update(id, product)) {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] Guid id) {
            if (!_productService.Delete(id)) {
                return NotFound();
            }
            return NoContent();
        }
    }
}