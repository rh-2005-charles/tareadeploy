using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ic_tienda_bussines.Dtos;
using ic_tienda_data.Sources.Data.Models;

namespace ic_tienda_data.Mapper
{
    public static class CategoryMapper
    {
        // Convierte una entidad Product a un DTO ProductDto.
        public static CategoryDto ToCategoryDto(this Category category)
        {
            return new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description
            };
        }

        // Convierte un DTO ProductDto a una entidad Product.
        public static Category ToCategory(this CategoryDto categoryDto)
        {
            return new Category
            {
                Name = categoryDto.Name,
                Description = categoryDto.Description
            };
        }

        // Convierte un DTO ProductCreateDto a una entidad Product.
        public static Category ToCreateCategory(this CategoryCreateDto categoryDto)
        {
            return new Category
            {
                Name = categoryDto.Name,
                Description = categoryDto.Description
            };
        }

        // Actualiza las propiedades de una entidad Product con los datos de un DTO ProductUpdateDto.
        public static void UpdateCategoryDto(this Category category, CategoryUpdateDto categoryUpdateDto)
        {
            category.Name = categoryUpdateDto.Name;
            category.Description = categoryUpdateDto.Description;
        }
    }
}