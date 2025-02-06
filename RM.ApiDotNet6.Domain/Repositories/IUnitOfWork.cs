namespace RM.ApiDotNet6.Domain.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        Task BeginTransaction();
        Task Commit();
        Task Rollback();
    }
}
