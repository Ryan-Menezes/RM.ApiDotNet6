using Microsoft.EntityFrameworkCore;
using RM.ApiDotNer6.Infra.Data.Context;
using RM.ApiDotNet6.Domain.Entities;
using RM.ApiDotNet6.Domain.Repositories;

namespace RM.ApiDotNer6.Infra.Data.Repositories
{
    public class PurchaseRepository : IPurchaseRepository
    {
        private readonly ApplicationDbContext _db;

        public PurchaseRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Purchase> CreateAsync(Purchase purchase)
        {
            _db.Add(purchase);
            await _db.SaveChangesAsync();
            return purchase;
        }

        public async Task DeleteAsync(Purchase purchase)
        {
            _db.Remove(purchase);
            await _db.SaveChangesAsync();
        }

        public async Task<ICollection<Purchase>> GetAllAsync()
        {
            return await _db.Purchases
                .Include(x => x.Product)
                .Include(x => x.Person)
                .ToListAsync();
        }

        public async Task<Purchase?> GetByIdAsync(int id)
        {
            var purchase = await _db.Purchases
                .Include(x => x.Product)
                .Include(x => x.Person)
                .FirstOrDefaultAsync(x => x.Id == id);

            return purchase;
        }

        public async Task<Purchase> UpdateAsync(Purchase purchase)
        {
            _db.Update(purchase);
            await _db.SaveChangesAsync();
            return purchase;
        }

        public async Task<ICollection<Purchase>> GetByPersonIdAsync(int personId)
        {
            return await _db.Purchases
                .Include(x => x.Product)
                .Include(x => x.Person)
                .Where(x => x.PersonId == personId)
                .ToListAsync();
        }

        public async Task<ICollection<Purchase>> GetByProductIdAsync(int productId)
        {
            return await _db.Purchases
                .Include(x => x.Product)
                .Include(x => x.Person)
                .Where(x => x.ProductId == productId)
                .ToListAsync();
        }
    }
}
