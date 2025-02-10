using RM.ApiDotNet6.Application.DTOs;
using RM.ApiDotNet6.Application.DTOs.Validations;
using RM.ApiDotNet6.Application.Services.Interfaces;
using RM.ApiDotNet6.Domain.Authentication;
using RM.ApiDotNet6.Domain.Repositories;

namespace RM.ApiDotNet6.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenGenerator _tokenGenerator;

        public UserService(IUserRepository userRepository, ITokenGenerator tokenGenerator)
        {
            _userRepository = userRepository;
            _tokenGenerator = tokenGenerator;
        }

        public async Task<ResultService<dynamic>> GenerateTokenAsync(UserDTO userDTO)
        {
            if (userDTO == null)
                return ResultService.Fail<dynamic>("O objeto deve ser informado");

            var result = new UserDTOValidator().Validate(userDTO);

            if (!result.IsValid)
                return ResultService.RequestError<dynamic>("Problemas de validação", result);

            var user = await _userRepository.GetUserByEmailAndPasswordAsync(userDTO.Email, userDTO.Password);

            if (user == null)
                return ResultService.Fail<dynamic>("Email ou senha inválidos!");

            return ResultService.Ok<dynamic>(_tokenGenerator.Generator(user));
        }
    }
}
