using ic_tienda_bussines.Dtos;
using ic_tienda_bussines.Helpers;
using ic_tienda_bussines.Repositories;
using ic_tienda_data.Mapper;
using ic_tienda_data.Sources.Data;
using Microsoft.EntityFrameworkCore;

namespace ic_tienda_data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IcTiendaDbContext _context;
        public CategoryRepository(IcTiendaDbContext context)
        {
            _context = context;
        }

        public async Task<CategoryDto> AddAsync(CategoryCreateDto categoryCreateDto)
        {
            var category = categoryCreateDto.ToCreateCategory();
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return category.ToCategoryDto();
        }

        public async Task DeleteAsync(int categoryId)
        {
            var category = await _context.Categories.FindAsync(categoryId);
            if (category != null)
            {
                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<PagedDto<CategoryDto>> GetAllAsync(QueryObject query)
        {
            var queryable = _context.Categories.AsQueryable();

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

            var categoryDto = items.Select(c => c.ToCategoryDto()).ToList();

            return new PagedDto<CategoryDto>
            {
                Items = categoryDto,
                TotalCount = totalCount,
                PageNumber = query.PageNumber,
                PageSize = query.PageSize
            };
        }

        public async Task<CategoryDto> GetByIdAsync(int categoryId)
        {
            var category = await _context.Categories.FindAsync(categoryId);
            if (category == null)
            {
                throw new KeyNotFoundException($"La categoria con ID {categoryId} no fue encontrado.");
            }
            return category.ToCategoryDto();
        }

        public async Task UpdateAsync(int categoryId, CategoryUpdateDto categoryUpdateDto)
        {
            // Buscar la entidad existente en la base de datos
            var existingCategory = await _context.Categories.FindAsync(categoryId);
            if (existingCategory == null)
            {
                throw new KeyNotFoundException($"La categoria con ID {categoryId} no existe.");
            }

            // Usar el mapeador para actualizar las propiedades
            existingCategory.UpdateCategoryDto(categoryUpdateDto);

            // Guardar los cambios
            await _context.SaveChangesAsync();
        }
    }
}