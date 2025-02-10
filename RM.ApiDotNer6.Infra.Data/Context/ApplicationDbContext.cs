using Microsoft.EntityFrameworkCore;
using RM.ApiDotNet6.Domain.Entities;

namespace RM.ApiDotNer6.Infra.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Person> People { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<User> Users { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
