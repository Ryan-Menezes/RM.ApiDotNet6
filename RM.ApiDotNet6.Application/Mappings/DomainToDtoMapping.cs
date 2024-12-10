using AutoMapper;
using RM.ApiDotNet6.Application.DTOs;
using RM.ApiDotNet6.Domain.Entities;

namespace RM.ApiDotNet6.Application.Mappings
{
    public class DomainToDtoMapping : Profile
    {
        public DomainToDtoMapping()
        {
            CreateMap<Person, PersonDTO>();
        }
    }
}
