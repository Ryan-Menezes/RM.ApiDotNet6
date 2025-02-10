using RM.ApiDotNet6.Domain.Entities;

namespace RM.ApiDotNet6.Domain.Repositories
{
    public interface IUserRepository : IBase<User>
    {
        Task<User> GetUserByEmailAndPasswordAsync(string email, string password);
    }
}
