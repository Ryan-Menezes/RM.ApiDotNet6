using RM.ApiDotNet6.Domain.Validations;

namespace RM.ApiDotNet6.Domain.Entities
{
    public sealed class Product
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string CodErp { get; private set; }
        public decimal Price { get; private set; }
        public ICollection<Purchase> Purchases { get; private set; }

        public Product(string name, string codErp, decimal price)
        {
            Validation(name, codErp, price);

            Purchases = new List<Purchase>();
        }

        public Product(int id, string name, string codErp, decimal price)
        {
            DomainValidationException.When(id < 0, "Id inválido");

            Validation(name, codErp, price);

            Id = id;
            Purchases = new List<Purchase>();
        }

        private void Validation(string name, string codErp, decimal price)
        {
            DomainValidationException.When(string.IsNullOrEmpty(name), "O nome é obrigatório");
            DomainValidationException.When(string.IsNullOrEmpty(codErp), "O código erp é obrigatório");
            DomainValidationException.When(price < 0, "O preço é obrigatório");

            Name = name;
            CodErp = codErp;
            Price = price;
        }
    }
}
