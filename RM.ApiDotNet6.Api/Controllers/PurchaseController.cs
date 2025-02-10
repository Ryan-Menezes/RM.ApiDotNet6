using Microsoft.AspNetCore.Mvc;
using RM.ApiDotNet6.Application.DTOs;
using RM.ApiDotNet6.Application.Services.Interfaces;

namespace RM.ApiDotNet6.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseController : ControllerBase
    {
        private readonly IPurchaseService _purchaseService;

        public PurchaseController(IPurchaseService purchaseService)
        {
            _purchaseService = purchaseService;
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] PurchaseDTO purchaseDTO)
        {
            var result = await _purchaseService.CreateAsync(purchaseDTO);

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult> GetAsync()
        {
            var result = await _purchaseService.GetAsync();

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetByIdAsync(int id)
        {
            var result = await _purchaseService.GetByIdAsync(id);

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAsync([FromBody] PurchaseDTO purchaseDTO)
        {
            var result = await _purchaseService.UpdateAsync(purchaseDTO);

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var result = await _purchaseService.DeleteAsync(id);

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }
    }
}
