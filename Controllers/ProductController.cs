using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System;
using market_api.Services;
using market_api.Dtos;

namespace market_api.Controllers {
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase {
        private readonly IService<ProductDto, ProductCreateDto> _productService;

        public ProductsController(IService<ProductDto, ProductCreateDto> productService) {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductDto>>> GetProducts() {
            return Ok(await _productService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetProduct([FromRoute] Guid id) {
            ProductDto temp = await _productService.Get(id);
            if (temp == null) {
                return NotFound();
            }
            return Ok(temp);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ProductCreateDto product) {
            await _productService.Create(product);
            return Ok(product);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put([FromRoute] Guid id, [FromBody] ProductDto product) {
            if (!await _productService.Update(id, product)) {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] Guid id) {
            if (!await _productService.Delete(id)) {
                return NotFound();
            }
            return NoContent();
        }
    }
}