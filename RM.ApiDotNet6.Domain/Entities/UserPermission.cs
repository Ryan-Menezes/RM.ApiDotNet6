using RM.ApiDotNet6.Domain.Validations;

namespace RM.ApiDotNet6.Domain.Entities
{
    public sealed class UserPermission
    {
        public int Id { get; private set; }
        public int UserId { get; private set; }
        public int PermissionId { get; private set; }
        public User User { get; private set; }
        public Permission Permission { get; private set; }

        public UserPermission(int userId, int permissionId)
        {
            Validation(userId, permissionId);
        }

        public UserPermission(int id, int userId, int permissionId)
        {
            DomainValidationException.When(id < 0, "Id inválido");

            Validation(userId, permissionId);

            Id = id;
        }

        private void Validation(int userId, int permissionId)
        {
            DomainValidationException.When(userId < 0, "Id do usuário inválido");
            DomainValidationException.When(permissionId < 0, "Id da permissão inválido");

            UserId = userId;
            PermissionId = permissionId;
        }
    }
}
