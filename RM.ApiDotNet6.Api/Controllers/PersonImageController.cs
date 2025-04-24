using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RM.ApiDotNet6.Application.DTOs;
using RM.ApiDotNet6.Application.Services.Interfaces;

namespace RM.ApiDotNet6.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PersonImageController : ControllerBase
    {
        private readonly IPersonImageService _personImageService;

        public PersonImageController(IPersonImageService personImageService)
        {
            _personImageService = personImageService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateImageBase64(PersonImageDTO personImageDTO)
        {
            var result = await _personImageService.CreateImageBase64Async(personImageDTO);

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost]
        [Route("pathimage")]
        public async Task<IActionResult> CreateImage(PersonImageDTO personImageDTO)
        {
            var result = await _personImageService.CreateImageAsync(personImageDTO);

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }
    }
}
