using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ic_tienda_bussines.Dtos;
using ic_tienda_bussines.Helpers;
using ic_tienda_bussines.Repositories;
using ic_tienda_bussines.Services;

namespace ic_tienda_data.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<CategoryDto> AddAsync(CategoryCreateDto categoryCreateDto)
        {
            return await _categoryRepository.AddAsync(categoryCreateDto);
        }

        public async Task DeleteAsync(int categoryId)
        {
            await _categoryRepository.DeleteAsync(categoryId);
        }

        /* public async Task<IEnumerable<CategoryDto>> GetAllAsync()
        {
            return await _categoryRepository.GetAllAsync();
        } */

        public async Task<PagedDto<CategoryDto>> GetAllAsync(QueryObject query)
        {
            return await _categoryRepository.GetAllAsync(query);
        }

        public async Task<CategoryDto> GetByIdAsync(int categoryId)
        {
            return await _categoryRepository.GetByIdAsync(categoryId);
        }

        public async Task UpdateAsync(int categoryId, CategoryUpdateDto categoryUpdateDto)
        {
            await _categoryRepository.UpdateAsync(categoryId, categoryUpdateDto);
        }
    }
}