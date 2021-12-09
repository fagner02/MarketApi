using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System;
using market_api.Services;
using market_api.Dtos;

namespace market_api.Controllers {
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase {
        private readonly CategoryService _categoryService;

        public CategoryController(CategoryService categoryService) {
            _categoryService = categoryService;
        }

        [HttpGet]
        public ActionResult<List<CategoryDto>> GetProducts() {
            return Ok(_categoryService.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<CategoryDto> GetProduct([FromRoute] Guid id) {
            CategoryDto temp = _categoryService.Get(id);
            if (temp == null) {
                return NotFound();
            }
            return Ok(temp);
        }

        [HttpPost]
        public ActionResult Post([FromBody] CategoryDto category) {
            _categoryService.Create(category);
            return Ok(category);
        }

        [HttpPut("{id}")]
        public ActionResult Put([FromRoute] Guid id, [FromBody] CategoryDto category) {
            if (!_categoryService.Update(id, category)) {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] Guid id) {
            if (!_categoryService.Delete(id)) {
                return NotFound();
            }
            return NoContent();
        }
    }
}