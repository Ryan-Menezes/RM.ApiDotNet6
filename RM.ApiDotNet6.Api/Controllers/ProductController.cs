using Microsoft.AspNetCore.Mvc;
using RM.ApiDotNet6.Application.DTOs;
using RM.ApiDotNet6.Application.Services.Interfaces;

namespace RM.ApiDotNet6.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] ProductDTO productDTO)
        {
            var result = await _productService.CreateAsync(productDTO);

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult> GetAsync()
        {
            var result = await _productService.GetAsync();

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetByIdAsync(int id)
        {
            var result = await _productService.GetByIdAsync(id);

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAsync([FromBody] ProductDTO productDTO)
        {
            var result = await _productService.UpdateAsync(productDTO);

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var result = await _productService.DeleteAsync(id);

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }
    }
}
