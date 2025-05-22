using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ic_tienda_bussines.Dtos;
using ic_tienda_bussines.Helpers;
using ic_tienda_bussines.Repositories;
using ic_tienda_bussines.Services;
using ic_tienda_data.Sources.Data.Models;

namespace ic_tienda_data.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ProductDto> AddAsync(ProductCreateDto productCreateDto)
        {
            return await _productRepository.AddAsync(productCreateDto);
        }

        public async Task<PagedDto<ProductDto>> GetAllAsync(QueryObject query)
        {
            return await _productRepository.GetAllAsync(query);
        }

        public async Task<ProductDto> GetByIdAsync(int productId)
        {
            return await _productRepository.GetByIdAsync(productId);
        }

        public async Task UpdateAsync(int producId, ProductUpdateDto productUpdateDto)
        {
            await _productRepository.UpdateAsync(producId, productUpdateDto);
        }

        public async Task DeleteAsync(int productId)
        {
            await _productRepository.DeleteAsync(productId);
        }


        // Para traer los productos asociados a una categoria
        public async Task<IEnumerable<ProductDto>> GetByCategoryAsync(int categoryId)
        {
            return await _productRepository.GetByCategoryAsync(categoryId);
        }
    }
}