using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ic_tienda_bussines.Dtos;

namespace ic_tienda_bussines.Repositories
{
    public interface IUserRepository
    {
        Task<UserResponse> GetByEmailAsync(string email);
        Task AddAsync(UserRequest request);
        Task UpdateAsync(UserRequest request);
    }
}