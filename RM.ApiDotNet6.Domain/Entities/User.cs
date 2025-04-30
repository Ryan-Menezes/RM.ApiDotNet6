using RM.ApiDotNet6.Domain.Validations;

namespace RM.ApiDotNet6.Domain.Entities
{
    public sealed class User
    {
        public int Id { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public ICollection<UserPermission> UserPermissions { get; private set; }

        public User(string email, string password)
        {
            Validation(email, password);

            UserPermissions = new List<UserPermission>();
        }

        public User(int id, string email, string password)
        {
            DomainValidationException.When(id < 0, "Id inválido");

            Validation(email, password);

            Id = id;
            UserPermissions = new List<UserPermission>();
        }

        private void Validation(string email, string password)
        {
            DomainValidationException.When(string.IsNullOrEmpty(email), "O email é obrigatório");
            DomainValidationException.When(string.IsNullOrEmpty(password), "A senha é obrigatória");

            Email = email;
            Password = password;
        }
    }
}
