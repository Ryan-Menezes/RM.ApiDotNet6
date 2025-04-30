using Microsoft.EntityFrameworkCore;
using RM.ApiDotNer6.Infra.Data.Context;
using RM.ApiDotNet6.Domain.Entities;
using RM.ApiDotNet6.Domain.Repositories;

namespace RM.ApiDotNer6.Infra.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _db;

        public ProductRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Product> CreateAsync(Product product)
        {
            _db.Add(product);
            await _db.SaveChangesAsync();
            return product;
        }

        public async Task DeleteAsync(Product product)
        {
            _db.Remove(product);
            await _db.SaveChangesAsync();
        }

        public async Task<ICollection<Product>> GetAllAsync()
        {
            return await _db.Products.ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _db.Products.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Product> UpdateAsync(Product product)
        {
            _db.Update(product);
            await _db.SaveChangesAsync();
            return product;
        }

        public async Task<Product> GetByCodErpAsync(string codErp)
        {
            return await _db.Products.FirstOrDefaultAsync(x => x.CodErp == codErp);
        }
    }
}
