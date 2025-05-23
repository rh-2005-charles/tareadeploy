using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ic_tienda_bussines.Dtos.Auth
{
    public class ExternalAuthDto
    {
        public string Provider { get; set; }
        public string IdToken { get; set; }
    }

    public class AuthResponseDto
    {
        public bool IsAuthSuccessful { get; set; }
        public string ErrorMessage { get; set; }
        public string Token { get; set; } // JWT token
        public string Provider { get; set; }
        public UserDto User { get; set; } // Información básica del usuario
    }

    public class UserDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public bool IsEmailVerified { get; set; }
    }
}