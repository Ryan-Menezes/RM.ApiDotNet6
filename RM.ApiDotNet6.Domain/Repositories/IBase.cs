namespace RM.ApiDotNet6.Domain.Repositories
{
    public interface IBase<T>
    {
        Task<T?> GetByIdAsync(int id);
        Task<ICollection<T>> GetAllAsync();
        Task<T> CreateAsync(T model);
        Task<T> UpdateAsync(T model);
        Task DeleteAsync(T model);
    }
}
