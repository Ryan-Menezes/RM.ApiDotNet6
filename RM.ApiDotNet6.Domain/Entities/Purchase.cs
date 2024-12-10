using RM.ApiDotNet6.Domain.Validations;

namespace RM.ApiDotNet6.Domain.Entities
{
    public sealed class Purchase
    {
        public int Id { get; private set; }
        public int PersonId { get; private set; }
        public int ProductId { get; private set; }
        public DateTime Date { get; private set; }
        public Person Person { get; private set; }
        public Product Product { get; private set; }

        public Purchase(int personId, int productId) => Validation(personId, productId);

        public Purchase(int id, int personId, int productId)
        {
            DomainValidationException.When(id < 0, "Id inválido");

            Validation(personId, productId);

            Id = id;
        }

        private void Validation(int personId, int productId)
        {
            DomainValidationException.When(productId < 0, "Id do produto inválido");
            DomainValidationException.When(personId < 0, "Id da pessoa inválido");

            PersonId = personId;
            ProductId = productId;
            Date = DateTime.Now;
        }
    }
}
