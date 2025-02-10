using RM.ApiDotNet6.Application.DTOs;

namespace RM.ApiDotNet6.Application.Services.Interfaces
{
    public interface IUserService
    {
        Task<ResultService<dynamic>> GenerateTokenAsync(UserDTO userDTO);
    }
}
