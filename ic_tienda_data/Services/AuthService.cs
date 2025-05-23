using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using ic_tienda_bussines.Dtos.Auth;
using ic_tienda_bussines.Services;
using ic_tienda_data.Sources.Data.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Google.Apis.Auth;
using ic_tienda_data.Sources.Data;


namespace ic_tienda_data.Services
{
    public class AuthService : IAuthService
    {
        private readonly IcTiendaDbContext _context;
        private readonly IConfiguration _configuration;

        public AuthService(IcTiendaDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<AuthResponseDto> ExternalLoginAsync(ExternalAuthDto externalAuth)
        {
            if (externalAuth.Provider == "Google")
            {
                var payload = await VerifyGoogleToken(externalAuth);
                if (payload == null)
                    return new AuthResponseDto { ErrorMessage = "Invalid Google Authentication." };

                // Buscar usuario por email
                var user = _context.Users.FirstOrDefault(u => u.Email == payload.Email);

                if (user == null)
                {
                    // Crear nuevo usuario si no existe
                    user = new User
                    {
                        Email = payload.Email,
                        IsEmailVerified = true,
                        Password = "external-auth",
                        VerificationToken = null
                    };

                    _context.Users.Add(user);
                    await _context.SaveChangesAsync();
                }

                var token = GenerateJwtToken(user);
                return new AuthResponseDto
                {
                    IsAuthSuccessful = true,
                    Token = token,
                    Provider = externalAuth.Provider,
                    User = new UserDto
                    {
                        Id = user.Id,
                        Email = user.Email,
                        IsEmailVerified = user.IsEmailVerified
                    }
                };
            }
            else if (externalAuth.Provider == "Facebook")
            {
                // Implementación similar para Facebook
                // Necesitarías validar el token de Facebook aquí
                throw new NotImplementedException("Facebook login not implemented yet");
            }

            return new AuthResponseDto { ErrorMessage = "Provider not supported." };
        }

        private async Task<GoogleJsonWebSignature.Payload> VerifyGoogleToken(ExternalAuthDto externalAuth)
        {
            try
            {
                var settings = new GoogleJsonWebSignature.ValidationSettings()
                {
                    Audience = new List<string>() { _configuration["Authentication:Google:ClientId"] }
                };
                return await GoogleJsonWebSignature.ValidateAsync(externalAuth.IdToken, settings);
            }
            catch
            {
                return null;
            }
        }

        private string GenerateJwtToken(User user)
        {
            var jwtKey = _configuration["Authentication:Jwt:Key"];
            if (string.IsNullOrEmpty(jwtKey))
            {
                throw new ArgumentNullException("Jwt:Key no está configurado en appsettings.json");
            }

            var claims = new List<Claim>
            {
                 new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim("isEmailVerified", user.IsEmailVerified.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(Convert.ToDouble(_configuration["Authentication:Jwt:ExpireDays"]));

            var token = new JwtSecurityToken(
                _configuration["Authentication:Jwt:Issuer"],
                _configuration["Authentication:Jwt:Audience"],
                claims,
                expires: expires,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}