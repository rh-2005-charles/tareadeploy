using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ic_tienda_bussines.Dtos;
using ic_tienda_bussines.Helpers;

namespace ic_tienda_bussines.Services
{
    public interface IProductService
    {
        Task<PagedDto<ProductDto>> GetAllAsync(QueryObject query);
        Task<ProductDto> GetByIdAsync(int productId);
        Task<ProductDto> AddAsync(ProductCreateDto productCreateDto);
        Task UpdateAsync(int producId, ProductUpdateDto productUpdateDto);
        Task DeleteAsync(int productId);

        // Para traer los productos asociados a una categoria
        Task<IEnumerable<ProductDto>> GetByCategoryAsync(int categoryId);
    }
}