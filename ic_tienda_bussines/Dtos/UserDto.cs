using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ic_tienda_bussines.Dtos
{
    public class UserResponse
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string? Name { get; set; }
        public string Email { get; set; } // Cambiado a no nullable para autenticación
        public string? Password { get; set; }
        public string Role { get; set; } // Cambiado a no nullable
        // Campos nuevos para autenticación externa
        public string? Provider { get; set; } // "Google", "Facebook", etc.
        public string? ProviderUserId { get; set; }
        public string? Token { get; set; }
    }

    public class UserRequest
    {
        public int CompanyId { get; set; }
        public string? Name { get; set; }
        public string Email { get; set; } // Cambiado a no nullable para autenticación
        public string? Password { get; set; }
        public string Role { get; set; } // Cambiado a no nullable
        // Campos nuevos para autenticación externa
        public string? Provider { get; set; } // "Google", "Facebook", etc.
        public string? ProviderUserId { get; set; }
        public string? Token { get; set; }
    }
}