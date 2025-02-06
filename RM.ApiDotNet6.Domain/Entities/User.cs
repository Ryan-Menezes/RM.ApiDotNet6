using RM.ApiDotNet6.Domain.Validations;

namespace RM.ApiDotNet6.Domain.Entities
{
    public class User
    {
        public int Id { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }

        public User(string email, string password)
        {
            Validation(email, password);
        }

        public User(int id, string email, string password)
        {
            DomainValidationException.When(id < 0, "Id inválido");

            Validation(email, password);

            Id = id;
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
