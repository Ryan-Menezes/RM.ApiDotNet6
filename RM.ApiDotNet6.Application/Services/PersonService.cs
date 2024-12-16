using AutoMapper;
using RM.ApiDotNet6.Application.DTOs;
using RM.ApiDotNet6.Application.DTOs.Validations;
using RM.ApiDotNet6.Application.Services.Interfaces;
using RM.ApiDotNet6.Domain.Entities;
using RM.ApiDotNet6.Domain.Repositories;

namespace RM.ApiDotNet6.Application.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;

        public PersonService(IPersonRepository personRepository, IMapper mapper)
        {
            _personRepository = personRepository;
            _mapper = mapper;
        }

        public async Task<ResultService<PersonDTO>> CreateAsync(PersonDTO personDTO)
        {
            if (personDTO == null)
                return ResultService.Fail<PersonDTO>("O objeto deve ser informado");

            var result = new PersonDTOValidator().Validate(personDTO);

            if (!result.IsValid)
                return ResultService.RequestError<PersonDTO>("Problemas de validação", result);

            var person = _mapper.Map<Person>(personDTO);
            var data = await _personRepository.CreateAsync(person);

            return ResultService.Ok<PersonDTO>(_mapper.Map<PersonDTO>(data));
        }

        public async Task<ResultService<ICollection<PersonDTO>>> GetAsync()
        {
            var people = await _personRepository.GetAllAsync();

            return ResultService.Ok<ICollection<PersonDTO>>(_mapper.Map<ICollection<PersonDTO>>(people));
        }

        public async Task<ResultService<PersonDTO>> GetByIdAsync(int id)
        {
            var person = await _personRepository.GetByIdAsync(id);

            if (person == null)
                return ResultService.Fail<PersonDTO>("Pessoa não encontrada!");

            return ResultService.Ok(_mapper.Map<PersonDTO>(person));
        }

        public async Task<ResultService> UpdateAsync(PersonDTO personDTO)
        {
            if (personDTO == null)
                return ResultService.Fail("O objeto deve ser informado");

            var result = new PersonDTOValidator().Validate(personDTO);

            if (!result.IsValid)
                return ResultService.RequestError("Problemas de validação", result);

            var person = await _personRepository.GetByIdAsync(personDTO.Id);

            if (person == null)
                return ResultService.Fail("Pessoa não encontrada!");

            person = _mapper.Map<PersonDTO, Person>(personDTO, person);

            await _personRepository.UpdateAsync(person);

            return ResultService.Ok($"Pessoa do id:{personDTO.Id} foi atualizada");
        }

        public async Task<ResultService> DeleteAsync(int id)
        {
            var person = await _personRepository.GetByIdAsync(id);

            if (person == null)
                return ResultService.Fail("Pessoa não encontrada!");

            await _personRepository.DeleteAsync(person);

            return ResultService.Ok($"Pessoa do id:{id} foi deletada");
        }
    }
}
