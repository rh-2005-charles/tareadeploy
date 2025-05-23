/* using ic_tienda_bussines.Dtos;
using ic_tienda_bussines.Repositories;
using ic_tienda_data.Sources.Data;
using Microsoft.EntityFrameworkCore;

namespace ic_tienda_data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IcTiendaDbContext _context;

        public UserRepository(IcTiendaDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(UserRequest request)
        {
            await _context.Users.AddAsync(request);
            await _context.SaveChangesAsync();
        }

        public async Task<UserResponse> GetByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task UpdateAsync(UserRequest request)
        {
            _context.Users.Update(request);
            await _context.SaveChangesAsync();
        }
    }
} */