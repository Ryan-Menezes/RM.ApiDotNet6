using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RM.ApiDotNet6.Domain.Entities;

namespace RM.ApiDotNer6.Infra.Data.Maps
{
    public class PersonImageMap : IEntityTypeConfiguration<PersonImage>
    {
        public void Configure(EntityTypeBuilder<PersonImage> builder)
        {
            builder.ToTable("pessoaimagem");
            builder.HasKey(x => x.Id);

            builder
                .Property(x => x.Id)
                .HasColumnName("id")
                .UseIdentityColumn();

            builder
                .Property(x => x.PersonId)
                .HasColumnName("pessoa_id");

            builder
                .Property(x => x.ImageUri)
                .HasColumnName("uri");

            builder
                .Property(x => x.ImageBase)
                .HasColumnName("base");

            builder
                .HasOne(x => x.Person)
                .WithMany(x => x.PersonImages);
        }
    }
}
