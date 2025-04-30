using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RM.ApiDotNet6.Domain.Entities;

namespace RM.ApiDotNer6.Infra.Data.Maps
{
    public class PermissionMap : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.ToTable("permissao");
            builder.HasKey(x => x.Id);

            builder
                .Property(x => x.Id)
                .HasColumnName("id")
                .UseIdentityColumn();

            builder
                .Property(x => x.VisualName)
                .HasColumnName("nomevisual");

            builder
                .Property(x => x.PermissionName)
                .HasColumnName("nomepermissao");

            builder
                .HasMany(x => x.UserPermissions)
                .WithOne(x => x.Permission)
                .HasForeignKey(x => x.PermissionId);
        }
    }
}
