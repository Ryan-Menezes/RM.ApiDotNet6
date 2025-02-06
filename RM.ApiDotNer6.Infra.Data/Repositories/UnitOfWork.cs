using Microsoft.EntityFrameworkCore.Storage;
using RM.ApiDotNer6.Infra.Data.Context;
using RM.ApiDotNet6.Domain.Repositories;

namespace RM.ApiDotNer6.Infra.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        private IDbContextTransaction _transaction;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task BeginTransaction()
        {
            _transaction = await _db.Database.BeginTransactionAsync();
        }

        public async Task Commit()
        {
            await _transaction.CommitAsync();
        }

        public async Task Rollback()
        {
            await _transaction.RollbackAsync();
        }

        public void Dispose()
        {
            _transaction?.Dispose();
        }
    }
}
