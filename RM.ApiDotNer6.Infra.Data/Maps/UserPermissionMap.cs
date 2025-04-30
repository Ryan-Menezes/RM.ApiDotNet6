using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RM.ApiDotNet6.Domain.Entities;

namespace RM.ApiDotNer6.Infra.Data.Maps
{
    public class UserPermissionMap : IEntityTypeConfiguration<UserPermission>
    {
        public void Configure(EntityTypeBuilder<UserPermission> builder)
        {
            builder.ToTable("permissaousuario");
            builder.HasKey(x => x.Id);

            builder
                .Property(x => x.Id)
                .HasColumnName("id")
                .UseIdentityColumn();

            builder
                .Property(x => x.UserId)
                .HasColumnName("usuario_id");

            builder
                .Property(x => x.PermissionId)
                .HasColumnName("permissao_id");

            builder
                .HasOne(x => x.Permission)
                .WithMany(x => x.UserPermissions);

            builder
                .HasOne(x => x.User)
                .WithMany(x => x.UserPermissions);
        }
    }
}
