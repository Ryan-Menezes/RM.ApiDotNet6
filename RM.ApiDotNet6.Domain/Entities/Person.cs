using RM.ApiDotNet6.Domain.Validations;

namespace RM.ApiDotNet6.Domain.Entities
{
    public sealed class Person
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Document { get; private set; }
        public string Phone { get; private set; }
        public ICollection<Purchase> Purchases { get; private set; }

        public Person(string name, string document, string phone)
        {
            Validation(name, document, phone);

            Purchases = new List<Purchase>();
        }

        public Person(int id, string name, string document, string phone)
        {
            DomainValidationException.When(id < 0, "Id inválido");

            Validation(name, document, phone);

            Id = id;
            Purchases = new List<Purchase>();
        }

        private void Validation(string name, string document, string phone)
        {
            DomainValidationException.When(string.IsNullOrEmpty(name), "O nome é obrigatório");
            DomainValidationException.When(string.IsNullOrEmpty(document), "O documento é obrigatório");
            DomainValidationException.When(string.IsNullOrEmpty(phone), "O celular é obrigatório");

            Name = name;
            Document = document;
            Phone = phone;
        }
    }
}
