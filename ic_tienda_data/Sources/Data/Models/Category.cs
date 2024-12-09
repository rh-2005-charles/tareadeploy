using System.ComponentModel.DataAnnotations;

namespace ic_tienda_data.Sources.Data.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
    }
}