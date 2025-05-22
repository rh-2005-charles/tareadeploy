using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using ic_tienda_bussines.Dtos;
using ic_tienda_bussines.Helpers;
using ic_tienda_bussines.Services;
using Microsoft.AspNetCore.Mvc;

namespace ic_tienda.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // POST api/category
        [HttpPost]
        public async Task<ActionResult<CategoryDto>> AddCategory(CategoryCreateDto categoryCreateDto)
        {
            var category = await _categoryService.AddAsync(categoryCreateDto);
            return CreatedAtAction(nameof(GetById), new { id = category.Id }, category);
        }

        // GET api/categories
        [HttpGet]
        public async Task<ActionResult<PagedDto<CategoryDto>>> GetAll([FromQuery] QueryObject query)
        {
            var result = await _categoryService.GetAllAsync(query);
            return Ok(result);
        }

        // GET api/category/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDto>> GetById(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            if (category == null)
                return NotFound();
            return Ok(category);
        }

        // PUT api/category/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, CategoryUpdateDto categoryUpdateDto)
        {
            // Verificar si la categoria existe
            var existingCategory = await _categoryService.GetByIdAsync(id);
            if (existingCategory == null)
                return NotFound();

            // Llamar al servicio para actualizar la categoria
            await _categoryService.UpdateAsync(id, categoryUpdateDto);
            return NoContent();
        }

        // DELETE api/category/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var existingCategory = await _categoryService.GetByIdAsync(id);
            if (existingCategory == null)
                return NotFound();

            await _categoryService.DeleteAsync(id);
            return NoContent();
        }
    }
}