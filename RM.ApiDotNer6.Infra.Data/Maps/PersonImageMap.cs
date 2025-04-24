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
                .HasColumnName("image_uri");

            builder
                .Property(x => x.ImageBase64)
                .HasColumnName("image_base_64");

            builder
                .HasOne(x => x.Person)
                .WithMany(x => x.PersonImages);
        }
    }
}
