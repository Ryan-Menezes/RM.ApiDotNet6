using Microsoft.AspNetCore.Mvc;
using RM.ApiDotNet6.Application.DTOs;
using RM.ApiDotNet6.Application.Services.Interfaces;

namespace RM.ApiDotNet6.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("token")]
        public async Task<ActionResult> PostAsync([FromForm] UserDTO userDTO)
        {
            var result = await _userService.GenerateTokenAsync(userDTO);

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result.Data);
        }
    }
}
