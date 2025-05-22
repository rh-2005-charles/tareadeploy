using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using ic_tienda_bussines.Dtos.Auth;
using ic_tienda_bussines.Services;
using ic_tienda_data.Sources.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Google.Apis.Auth;



namespace ic_tienda_data.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;

        public AuthService(UserManager<User> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<AuthResponseDto> ExternalLoginAsync(ExternalAuthDto externalAuth)
        {
            var payload = await VerifyGoogleToken(externalAuth);
            if (payload == null)
                return new AuthResponseDto { ErrorMessage = "Invalid External Authentication." };

            var info = new UserLoginInfo(externalAuth.Provider, payload.Subject, externalAuth.Provider);
            var user = await _userManager.FindByLoginAsync(info.LoginProvider, info.ProviderKey);

            if (user == null)
            {
                user = await _userManager.FindByEmailAsync(payload.Email);

                if (user == null)
                {
                    user = new User
                    {
                        Email = payload.Email,
                        UserName = payload.Email,
                        Provider = externalAuth.Provider,
                        ProviderUserId = payload.Subject
                    };
                    await _userManager.CreateAsync(user);

                    // Prepare and send an email for the email confirmation if needed
                }

                await _userManager.AddLoginAsync(user, info);
            }

            if (user == null)
                return new AuthResponseDto { ErrorMessage = "Invalid External Authentication." };

            // Check for the Locked out account
            var token = await GenerateJwtToken(user);

            return new AuthResponseDto { IsAuthSuccessful = true, Token = token, Provider = externalAuth.Provider };
        }

        private async Task<GoogleJsonWebSignature.Payload> VerifyGoogleToken(ExternalAuthDto externalAuth)
        {
            try
            {
                var settings = new GoogleJsonWebSignature.ValidationSettings()
                {
                    Audience = new List<string>() { _configuration["Authentication:Google:ClientId"] }
                };

                var payload = await GoogleJsonWebSignature.ValidateAsync(externalAuth.IdToken, settings);
                return payload;
            }
            catch
            {
                // Log error
                return null;
            }
        }

        private async Task<string> GenerateJwtToken(User user)
        {
            var jwtKey = _configuration["Authentication:Jwt:Key"];
            if (string.IsNullOrEmpty(jwtKey))
            {
                throw new ArgumentNullException("Jwt:Key no está configurado en appsettings.json");
            }


            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email)
            };

            var roles = await _userManager.GetRolesAsync(user);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

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