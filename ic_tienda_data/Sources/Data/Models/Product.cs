using System.ComponentModel.DataAnnotations;

namespace ic_tienda_data.Sources.Data.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public required string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string? Description { get; set; }

        //relacion con categoria
        public int CategoryId { get; set; }
    }
}