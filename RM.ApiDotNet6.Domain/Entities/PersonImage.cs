using RM.ApiDotNet6.Domain.Validations;

namespace RM.ApiDotNet6.Domain.Entities
{
    public sealed class PersonImage
    {
        public int Id { get; private set; }
        public int PersonId { get; private set; }
        public string? ImageUri { get; private set; }
        public string? ImageBase64 { get; private set; }
        public Person Person { get; private set; }

        public PersonImage(int personId, string? imageUri, string? imageBase64)
        {
            Validation(personId);

            ImageUri = imageUri;
            ImageBase64 = imageBase64;
        }

        public PersonImage(int id, int personId, string? imageUri, string? imageBase64)
        {
            DomainValidationException.When(id < 0, "Id inválido");

            Validation(personId);

            Id = id;
            ImageUri = imageUri;
            ImageBase64 = imageBase64;
        }

        private void Validation(int personId)
        {
            DomainValidationException.When(personId < 0, "Id da pessoa inválido");

            PersonId = personId;
        }
    }
}
