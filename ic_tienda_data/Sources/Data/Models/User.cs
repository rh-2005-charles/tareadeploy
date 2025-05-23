using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace ic_tienda_data.Sources.Data.Models
{
    [Table("user")]
    public class User
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("email")]
        public string? Email { get; set; }

        [Column("password")]
        public string? Password { get; set; }

        [Column("isEmailVerified")]
        public bool IsEmailVerified { get; set; }

        [Column("verificationToken")]
        public string? VerificationToken { get; set; }

        //public ICollection<Favorite> Favorites { get; set; } = new List<Favorite>();
        //public ICollection<Address> Addresses { get; set; } = new List<Address>();
        //public ICollection<Receipt> Receipts { get; set; } = new List<Receipt>();
        //public CustomerDetail? CustomerDetail { get; set; }
        //public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}