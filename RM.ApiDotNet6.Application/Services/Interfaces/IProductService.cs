using RM.ApiDotNet6.Application.DTOs;

namespace RM.ApiDotNet6.Application.Services.Interfaces
{
    public interface IProductService
    {
        Task<ResultService<ProductDTO>> CreateAsync(ProductDTO productDTO);
        Task<ResultService<ICollection<ProductDTO>>> GetAsync();
        Task<ResultService<ProductDTO>> GetByIdAsync(int id);
        Task<ResultService> UpdateAsync(ProductDTO productDTO);
        Task<ResultService> DeleteAsync(int id);
    }
}
