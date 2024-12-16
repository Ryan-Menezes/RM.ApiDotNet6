using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RM.ApiDotNet6.Domain.Entities;

namespace RM.ApiDotNer6.Infra.Data.Maps
{
    public class PurchaseMap : IEntityTypeConfiguration<Purchase>
    {
        public void Configure(EntityTypeBuilder<Purchase> builder)
        {
            builder.ToTable("compra");
            builder.HasKey(x => x.Id);

            builder
                .Property(x => x.Id)
                .HasColumnName("id")
                .UseIdentityColumn();

            builder
                .Property(x => x.PersonId)
                .HasColumnName("pessoa_id");

            builder
                .Property(x => x.ProductId)
                .HasColumnName("produto_id");

            builder
                .Property(x => x.Date)
                .HasColumnType("date")
                .HasColumnName("data_compra");

            builder
                .HasOne(x => x.Person)
                .WithMany(c => c.Purchases);

            builder
                .HasOne(x => x.Product)
                .WithMany(c => c.Purchases);
        }
    }
}
