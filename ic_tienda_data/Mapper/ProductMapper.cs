using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ic_tienda_bussines.Dtos;
using ic_tienda_data.Sources.Data.Models;

namespace ic_tienda_data.Mapper
{
    public static class ProductMapper
    {
        // Convierte una entidad Product a un DTO ProductDto.
        // Este método mapea los datos de la entidad Product a un ProductDto.

        public static ProductDto ToProductDto(this Product product)
        {
            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Stock = product.Stock,
                Description = product.Description,
                CategoryId = product.CategoryId
            };
        }

        // Convierte un DTO ProductDto a una entidad Product.
        // Este método mapea los datos de un ProductDto a una entidad Product.
        // Típicamente usado para actualizar o crear productos en la base de datos.

        public static Product ToProduct(this ProductDto productDto)
        {
            return new Product
            {
                Name = productDto.Name,
                Price = productDto.Price,
                Stock = productDto.Stock,
                Description = productDto.Description,
                CategoryId = productDto.CategoryId

            };
        }

        // Convierte un DTO ProductCreateDto a una entidad Product.
        // Este método se usa para crear un nuevo producto desde los datos recibidos en el DTO de creación.
        public static Product ToCreateProduct(this ProductCreateDto productDto)
        {
            return new Product
            {
                Name = productDto.Name,
                Price = productDto.Price,
                Stock = productDto.Stock,
                Description = productDto.Description,
                CategoryId = productDto.CategoryId
            };
        }

        // Actualiza las propiedades de una entidad Product con los datos de un DTO ProductUpdateDto.
        // Este método aplica los cambios a un producto existente en la base de datos sin crear una nueva instancia.
        public static void UpdateProductDto(this Product product, ProductUpdateDto productUpdateDto)
        {
            product.Name = productUpdateDto.Name;
            product.Price = productUpdateDto.Price;
            product.Stock = productUpdateDto.Stock;
            product.Description = productUpdateDto.Description;
            product.CategoryId = productUpdateDto.CategoryId;
        }


    }
}