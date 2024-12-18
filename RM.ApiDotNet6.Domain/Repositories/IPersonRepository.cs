using RM.ApiDotNet6.Domain.Entities;
using RM.ApiDotNet6.Domain.FiltersDb;

namespace RM.ApiDotNet6.Domain.Repositories
{
    public interface IPersonRepository : IBase<Person>
    {
        Task<PagedBaseResponse<Person>> GetPagedAsync(PersonFilterDb request);
        Task<Person> GetByDocumentAsync(string document);
    }
}
