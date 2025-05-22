using System.Security.Claims;
using ic_tienda_bussines.Dtos.Auth;
using ic_tienda_bussines.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ic_tienda.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("ExternalLogin")]
        public async Task<IActionResult> ExternalLogin([FromBody] ExternalAuthDto externalAuth)
        {
            var authResponse = await _authService.ExternalLoginAsync(externalAuth);

            if (!authResponse.IsAuthSuccessful)
                return BadRequest(authResponse.ErrorMessage);

            return Ok(authResponse);
        }
    }
}