using ic_tienda_bussines.Dtos;
using ic_tienda_bussines.Helpers;

namespace ic_tienda_bussines.Repositories
{
    public interface ICategoryRepository
    {
        Task<PagedDto<CategoryDto>> GetAllAsync(QueryObject query);

        /* Task<IEnumerable<CategoryDto>> GetAllAsync(); */
        Task<CategoryDto> GetByIdAsync(int categoryId);
        Task<CategoryDto> AddAsync(CategoryCreateDto categoryCreateDto);
        Task UpdateAsync(int categoryId, CategoryUpdateDto categoryUpdateDto);
        Task DeleteAsync(int categoryId);
    }
}