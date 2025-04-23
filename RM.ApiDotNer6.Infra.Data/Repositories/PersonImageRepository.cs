using Microsoft.EntityFrameworkCore;
using RM.ApiDotNer6.Infra.Data.Context;
using RM.ApiDotNet6.Domain.Entities;
using RM.ApiDotNet6.Domain.Repositories;

namespace RM.ApiDotNer6.Infra.Data.Repositories
{
    public class PersonImageRepository : IPersonImageRepository
    {
        private readonly ApplicationDbContext _db;

        public PersonImageRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<PersonImage> CreateAsync(PersonImage personImage)
        {
            _db.Add(personImage);
            await _db.SaveChangesAsync();
            return personImage;
        }

        public async Task DeleteAsync(PersonImage personImage)
        {
            _db.Remove(personImage);
            await _db.SaveChangesAsync();
        }

        public async Task<ICollection<PersonImage>> GetAllAsync()
        {
            return await _db.PersonImages.ToListAsync();
        }

        public async Task<PersonImage> GetByIdAsync(int id)
        {
            return await _db.PersonImages.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<PersonImage> UpdateAsync(PersonImage personImage)
        {
            _db.Update(personImage);
            await _db.SaveChangesAsync();
            return personImage;
        }

        public async Task<ICollection<PersonImage>> GetByPersonIdAsync(int personId)
        {
            return await _db.PersonImages.AsNoTracking().Where(x => x.PersonId == personId).ToListAsync();
        }
    }
}
