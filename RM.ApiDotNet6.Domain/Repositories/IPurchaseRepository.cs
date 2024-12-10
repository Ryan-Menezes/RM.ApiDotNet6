using RM.ApiDotNet6.Domain.Entities;

namespace RM.ApiDotNet6.Domain.Repositories
{
    public interface IPurchaseRepository : IBase<Purchase>
    {
        Task<ICollection<Purchase>> GetByPersonIdAsync(int personId);
        Task<ICollection<Purchase>> GetByProductIdAsync(int productId);
    }
}
