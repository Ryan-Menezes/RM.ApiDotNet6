using RM.ApiDotNet6.Domain.Entities;

namespace RM.ApiDotNet6.Domain.Repositories
{
    public interface IPersonImageRepository : IBase<PersonImage>
    {
        Task<ICollection<PersonImage>> GetByPersonIdAsync(int personId);
    }
}
