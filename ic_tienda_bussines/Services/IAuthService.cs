using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ic_tienda_bussines.Dtos.Auth;

namespace ic_tienda_bussines.Services
{
    public interface IAuthService
    {
        Task<AuthResponseDto> ExternalLoginAsync(ExternalAuthDto externalAuth);
    }
}