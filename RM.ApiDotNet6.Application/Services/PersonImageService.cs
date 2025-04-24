using AutoMapper;
using RM.ApiDotNet6.Application.DTOs;
using RM.ApiDotNet6.Domain.Repositories;
using RM.ApiDotNet6.Application.Services.Interfaces;
using RM.ApiDotNet6.Application.DTOs.Validations;
using RM.ApiDotNet6.Domain.Entities;
using RM.ApiDotNet6.Domain.Integrations;

namespace RM.ApiDotNet6.Application.Services
{
    public class PersonImageService : IPersonImageService
    {
        private readonly IPersonRepository _personRepository;
        private readonly IPersonImageRepository _personImageRepository;
        private readonly ISavePersonImage _savePersonImage;
        private readonly IMapper _mapper;

        public PersonImageService(IPersonRepository personRepository, IPersonImageRepository personImageRepository, ISavePersonImage savePersonImage, IMapper mapper)
        {
            _personRepository = personRepository;
            _personImageRepository = personImageRepository;
            _savePersonImage = savePersonImage;
            _mapper = mapper;
        }

        public async Task<ResultService> CreateImageBase64Async(PersonImageDTO personImageDTO)
        {
            if (personImageDTO == null)
                return ResultService.Fail("O objegto deve ser informado");

            var validations = new PersonImageDTOValidator().Validate(personImageDTO);

            if (!validations.IsValid)
                return ResultService.RequestError("Problemas de validação", validations);

            var person = await _personRepository.GetByIdAsync(personImageDTO.PersonId);

            if (person == null)
                return ResultService.Fail("Id da pessoa não encontrado");

            var personImage = new PersonImage(person.Id, null, personImageDTO.Image);

            await _personImageRepository.CreateAsync(personImage);

            return ResultService.Ok("Imagem em base64 salva");
        }

        public async Task<ResultService> CreateImageAsync(PersonImageDTO personImageDTO)
        {
            if (personImageDTO == null)
                return ResultService.Fail("O objegto deve ser informado");

            var validations = new PersonImageDTOValidator().Validate(personImageDTO);

            if (!validations.IsValid)
                return ResultService.RequestError("Problemas de validação", validations);

            var person = await _personRepository.GetByIdAsync(personImageDTO.PersonId);

            if (person == null)
                return ResultService.Fail("Id da pessoa não encontrado");

            var path = _savePersonImage.Save(personImageDTO.Image);
            var personImage = new PersonImage(person.Id, path, null);

            await _personImageRepository.CreateAsync(personImage);

            return ResultService.Ok("Imagem salva");
        }
    }
}
