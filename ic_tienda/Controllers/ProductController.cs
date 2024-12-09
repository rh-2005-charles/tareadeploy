using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ic_tienda_bussines.Dtos;
using ic_tienda_bussines.Helpers;
using ic_tienda_bussines.Services;
using Microsoft.AspNetCore.Mvc;

namespace ic_tienda.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        // POST api/products
        [HttpPost]
        public async Task<ActionResult<ProductDto>> AddProduct(ProductCreateDto productCreateDto)
        {
            var product = await _productService.AddAsync(productCreateDto);
            return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
        }

        
        // GET api/products
        [HttpGet]
        public async Task<ActionResult<PagedDto<ProductDto>>> GetAll([FromQuery] QueryObject query)
        {
            var products = await _productService.GetAllAsync(query);
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetById(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            if (product == null)
                return NotFound();
            return Ok(product);
        }



        // PUT api/products/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, ProductUpdateDto productUpdateDto)
        {
            // Verificar si el producto existe
            var existingProduct = await _productService.GetByIdAsync(id);
            if (existingProduct == null)
                return NotFound();

            // Llamar al servicio para actualizar el producto
            await _productService.UpdateAsync(id, productUpdateDto);
            return NoContent();
        }

        // DELETE api/products/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var existingProduct = await _productService.GetByIdAsync(id);
            if (existingProduct == null)
                return NotFound();

            await _productService.DeleteAsync(id);
            return NoContent();
        }


        // Para traer los productos asociados a una categoria
        [HttpGet("category/{categoryId}")]
        public async Task<IActionResult> GetProductsByCategory(int categoryId)
        {
            var products = await _productService.GetByCategoryAsync(categoryId);
            return Ok(products);
        }
    }
}