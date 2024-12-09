using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ic_tienda_bussines.Dtos
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
    }

    public class CategoryCreateDto
    {
        public required string Name { get; set; }
        public string? Description { get; set; }
    }

    public class CategoryUpdateDto
    {
        public required string Name { get; set; }
        public string? Description { get; set; }
    }

}