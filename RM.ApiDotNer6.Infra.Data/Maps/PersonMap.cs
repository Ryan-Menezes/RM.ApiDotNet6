using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RM.ApiDotNet6.Domain.Entities;

namespace RM.ApiDotNer6.Infra.Data.Maps
{
    public class PersonMap : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("pessoa");
            builder.HasKey(x => x.Id);

            builder
                .Property(c => c.Id)
                .HasColumnName("id")
                .UseIdentityColumn();

            builder
                .Property(c => c.Name)
                .HasColumnName("nome");

            builder
                .Property(c => c.Document)
                .HasColumnName("documento");

            builder
                .Property(c => c.Phone)
                .HasColumnName("celular");

            builder
                .HasMany(c => c.Purchases)
                .WithOne(p => p.Person)
                .HasForeignKey(c => c.PersonId);

            builder
                .HasMany(c => c.PersonImages)
                .WithOne(i => i.Person)
                .HasForeignKey(c => c.PersonId);
        }
    }
}
