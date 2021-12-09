using System.Collections.Generic;
using market_api.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using market_api.Models;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace market_api.Controllers {
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase {
        private readonly Db _data;

        public CategoriesController(Db data) {
            _data = data;
        }

        [HttpGet]
        public async Task<ActionResult<List<Category>>> GetCategories() {
            return await _data.Categories.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategory([FromRoute] Guid id) {
            Category temp = await _data.Categories.FirstAsync(x => x.CategoryId == id);
            if (temp == null) {
                return NotFound();
            }
            return temp;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Category category) {
            _data.Categories.Add(category);
            await _data.SaveChangesAsync();
            return CreatedAtAction(nameof(GetCategory), new { id = category.CategoryId }, category);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put([FromBody] Category category) {
            if (!_data.Categories.Contains(category)) {
                return NotFound();
            }
            _data.Categories.Update(category);
            await _data.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] Guid id) {
            Category temp = await _data.Categories.FirstAsync(x => x.CategoryId == id);
            if (temp == null) {
                return NotFound();
            }
            _data.Categories.Remove(temp);
            await _data.SaveChangesAsync();
            return NoContent();
        }
    }
}