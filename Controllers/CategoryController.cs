using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System;
using market_api.Services;
using market_api.Dtos;
using System.Threading.Tasks;

namespace market_api.Controllers {
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase {
        private readonly CategoryService _categoryService;

        public CategoryController(CategoryService categoryService) {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetProducts() {
            return Ok(await _categoryService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDto>> GetProduct([FromRoute] Guid id) {
            CategoryDto temp = await _categoryService.Get(id);
            if (temp == null) {
                return NotFound();
            }
            return Ok(temp);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CategoryCreateDto category) {
            await _categoryService.Create(category);
            return Ok(category);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put([FromRoute] Guid id, [FromBody] CategoryDto category) {
            if (!await _categoryService.Update(id, category)) {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] Guid id) {
            if (!await _categoryService.Delete(id)) {
                return NotFound();
            }
            return NoContent();
        }

        [HttpGet("{id}/products")]
        public async Task<IEnumerable<ProductDto>> GetProducts([FromRoute] Guid id) {
            return await _categoryService.GetDetails(id);
        }
    }
}