using RM.ApiDotNet6.Application.DTOs;

namespace RM.ApiDotNet6.Application.Services.Interfaces
{
    public interface IPersonImageService
    {
        Task<ResultService> CreateImageBase64Async(PersonImageDTO personImageDTO);
        Task<ResultService> CreateImageAsync(PersonImageDTO personImageDTO);
    }
}
