using RM.ApiDotNet6.Domain.Validations;

namespace RM.ApiDotNet6.Domain.Entities
{
    public class Permission
    {
        public int Id { get; private set; }
        public string VisualName { get; private set; } = string.Empty;
        public string PermissionName { get; private set; } = string.Empty;
        public ICollection<UserPermission> UserPermissions { get; private set; }

        public Permission(string visualName, string permissionName)
        {
            Validation(visualName, permissionName);

            UserPermissions = new List<UserPermission>();
        }

        public Permission(int id, string visualName, string permissionName)
        {
            DomainValidationException.When(id < 0, "Id inválido");

            Validation(visualName, permissionName);

            Id = id;
            UserPermissions = new List<UserPermission>();
        }

        private void Validation(string visualName, string permissionName)
        {
            DomainValidationException.When(string.IsNullOrEmpty(visualName), "O nome visual é obrigatório");
            DomainValidationException.When(string.IsNullOrEmpty(permissionName), "O nome da permissão é obrigatório");

            VisualName = visualName;
            PermissionName = permissionName;
        }
    }
}
