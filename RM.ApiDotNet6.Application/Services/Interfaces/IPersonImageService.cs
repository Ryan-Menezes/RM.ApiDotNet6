using RM.ApiDotNet6.Application.DTOs;
using RM.ApiDotNet6.Domain.Entities;
using RM.ApiDotNet6.Domain.FiltersDb;

namespace RM.ApiDotNet6.Application.Services.Interfaces
{
    public interface IPersonImageService
    {
        Task<ResultService> CreateImageBase64Async(PersonImageDTO personImageDTO);
    }
}
