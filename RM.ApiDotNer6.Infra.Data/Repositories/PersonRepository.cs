﻿using Microsoft.EntityFrameworkCore;
using RM.ApiDotNer6.Infra.Data.Context;
using RM.ApiDotNet6.Domain.Entities;
using RM.ApiDotNet6.Domain.FiltersDb;
using RM.ApiDotNet6.Domain.Repositories;

namespace RM.ApiDotNer6.Infra.Data.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly ApplicationDbContext _db;

        public PersonRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Person> CreateAsync(Person person)
        {
            _db.Add(person);
            await _db.SaveChangesAsync();
            return person;
        }

        public async Task DeleteAsync(Person person)
        {
            _db.Remove(person);
            await _db.SaveChangesAsync();
        }

        public async Task<ICollection<Person>> GetAllAsync()
        {
            return await _db.People.ToListAsync();
        }

        public async Task<Person?> GetByIdAsync(int id)
        {
            return await _db.People.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Person> UpdateAsync(Person person)
        {
            _db.Update(person);
            await _db.SaveChangesAsync();
            return person;
        }

        public async Task<Person> GetByDocumentAsync(string document)
        {
            return await _db.People.FirstOrDefaultAsync(x => x.Document == document);
        }

        public async Task<PagedBaseResponse<Person>> GetPagedAsync(PersonFilterDb request)
        {
            var query = _db.People.AsQueryable();

            if (!string.IsNullOrEmpty(request.Name))
                query = query.Where(x => x.Name.Contains(request.Name));

            return await PagedBaseResponseHelper.GetResponseAsync<PagedBaseResponse<Person>, Person>(query, request);
        }
    }
}
