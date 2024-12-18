using RM.ApiDotNet6.Application.DTOs;
using RM.ApiDotNet6.Domain.Entities;
using RM.ApiDotNet6.Domain.FiltersDb;
using RM.ApiDotNet6.Domain.Repositories;

namespace RM.ApiDotNet6.Application.Services.Interfaces
{
    public interface IPersonService
    {
        Task<ResultService<PersonDTO>> CreateAsync(PersonDTO personDTO);
        Task<ResultService<ICollection<PersonDTO>>> GetAsync();
        Task<ResultService<PersonDTO>> GetByIdAsync(int id);
        Task<ResultService> UpdateAsync(PersonDTO personDTO);
        Task<ResultService> DeleteAsync(int id);
        Task<ResultService<PagedBaseResponseDTO<PersonDTO>>> GetPagedAsync(PersonFilterDb request);
    }
}
