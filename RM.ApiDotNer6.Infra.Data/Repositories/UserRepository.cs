using Microsoft.EntityFrameworkCore;
using RM.ApiDotNer6.Infra.Data.Context;
using RM.ApiDotNet6.Domain.Entities;
using RM.ApiDotNet6.Domain.Repositories;

namespace RM.ApiDotNer6.Infra.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _db;

        public UserRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<User> CreateAsync(User user)
        {
            _db.Add(user);
            await _db.SaveChangesAsync();
            return user;
        }

        public async Task DeleteAsync(User user)
        {
            _db.Remove(user);
            await _db.SaveChangesAsync();
        }

        public async Task<ICollection<User>> GetAllAsync()
        {
            return await _db.Users.ToListAsync();
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await _db.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<User> UpdateAsync(User user)
        {
            _db.Update(user);
            await _db.SaveChangesAsync();
            return user;
        }

        public async Task<User?> GetUserByEmailAndPasswordAsync(string email, string password)
        {
            return await _db.Users
                .Include(x => x.UserPermissions).ThenInclude(x => x.Permission)
                .FirstOrDefaultAsync(x => x.Email == email && x.Password == password);
        }
    }
}
