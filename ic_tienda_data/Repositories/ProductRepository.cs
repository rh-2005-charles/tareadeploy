using ic_tienda_bussines.Dtos;
using ic_tienda_bussines.Helpers;
using ic_tienda_bussines.Repositories;
using ic_tienda_data.Mapper;
using ic_tienda_data.Sources.Data;
using ic_tienda_data.Sources.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ic_tienda_data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IcTiendaDbContext _context;
        public ProductRepository(IcTiendaDbContext context)
        {
            _context = context;
        }

        public async Task<ProductDto> AddAsync(ProductCreateDto productCreateDto)
        {
            var product = productCreateDto.ToCreateProduct();
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return product.ToProductDto();
        }

        /* public async Task<PagedDto<ProductDto>> GetAllAsync(Q)
        {
            var products = await _context.Products.ToListAsync();
            return products.Select(p => p.ToProductDto());
        } */

        public async Task<PagedDto<ProductDto>> GetAllAsync(QueryObject query)
        {
            var queryable = _context.Products.AsQueryable();

            // Filtro de búsqueda
            if (!string.IsNullOrEmpty(query.Search))
            {
                queryable = queryable.Where(c => c.Name.Contains(query.Search));
            }

            // Ordenación
            if (!string.IsNullOrEmpty(query.SortBy))
            {
                queryable = query.SortBy.ToLower() switch
                {
                    "id" => query.IsDecsending ? queryable.OrderByDescending(c => c.Id) : queryable.OrderBy(c => c.Id),
                    _ => queryable.OrderBy(c => c.Id), // Por defecto, ordenar por Id
                };
            }

            // Paginación
            var totalCount = await queryable.CountAsync();
            var items = await queryable
                .Skip((query.PageNumber - 1) * query.PageSize)
                .Take(query.PageSize)
                .ToListAsync();

            var productDto = items.Select(c => c.ToProductDto()).ToList();

            return new PagedDto<ProductDto>
            {
                Items = productDto,
                TotalCount = totalCount,
                PageNumber = query.PageNumber,
                PageSize = query.PageSize
            };
        }

        public async Task<ProductDto> GetByIdAsync(int productId)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null)
            {
                throw new KeyNotFoundException($"El producto con ID {productId} no fue encontrado.");
            }
            return product.ToProductDto();
        }

        public async Task UpdateAsync(int producId, ProductUpdateDto productUpdateDto)
        {
            // Buscar la entidad existente en la base de datos
            var existingProduct = await _context.Products.FindAsync(producId);
            if (existingProduct == null)
            {
                throw new KeyNotFoundException($"El producto con ID {producId} no existe.");
            }

            // Usar el mapeador para actualizar las propiedades
            existingProduct.UpdateProductDto(productUpdateDto);

            // Guardar los cambios
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int productId)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
        }

        // Para traer los productos asociados a una categoria
        public async Task<IEnumerable<ProductDto>> GetByCategoryAsync(int categoryId)
        {
            var products = await _context.Products
            .Where(p => p.CategoryId == categoryId) // Filtrar por CategoryId
            .Join(
                _context.Categories, // Tabla de categorías
                product => product.CategoryId, // Clave foránea en productos
                category => category.Id, // Clave primaria en categorías
                (product, category) => new ProductDto // Proyección al DTO
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                    Stock = product.Stock,
                    Description = product.Description,
                    CategoryId = category.Id,
                    CategoryName = category.Name // Nombre de la categoría
                }
            )
            .ToListAsync(); // Ejecutar la consulta y devolver la lista

            return products; // Retornar la lista de productos con el nombre de categoría
        }


    }
}