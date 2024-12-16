using RM.ApiDotNet6.Domain.Entities;

namespace RM.ApiDotNet6.Domain.Repositories
{
    public interface IProductRepository : IBase<Product>
    {
        Task<Product> GetByCodErpAsync(string codErp);
    }
}
