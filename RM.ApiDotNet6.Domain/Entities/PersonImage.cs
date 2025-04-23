using RM.ApiDotNet6.Domain.Validations;

namespace RM.ApiDotNet6.Domain.Entities
{
    public class PersonImage
    {
        public int Id { get; private set; }
        public int PersonId { get; private set; }
        public string? ImageUri { get; private set; }
        public string? ImageBase { get; private set; }
        public Person Person { get; private set; }

        public PersonImage(int personId, string? uri, string? imageBase)
        {
            Validation(personId);

            ImageUri = uri;
            ImageBase = imageBase;
        }

        public PersonImage(int id, int personId, string? uri, string? imageBase)
        {
            DomainValidationException.When(id < 0, "Id inválido");

            Validation(personId);

            Id = id;
            ImageUri = uri;
            ImageBase = imageBase;
        }

        private void Validation(int personId)
        {
            DomainValidationException.When(personId < 0, "Id da pessoa inválido");

            PersonId = personId;
        }
    }
}
