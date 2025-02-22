﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RM.ApiDotNet6.Application.DTOs;
using RM.ApiDotNet6.Application.Services.Interfaces;
using RM.ApiDotNet6.Domain.FiltersDb;

namespace RM.ApiDotNet6.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] PersonDTO personDTO)
        {
            var result = await _personService.CreateAsync(personDTO);

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult> GetAsync()
        {
            var result = await _personService.GetAsync();

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetByIdAsync(int id)
        {
            var result = await _personService.GetByIdAsync(id);

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAsync([FromBody] PersonDTO personDTO)
        {
            var result = await _personService.UpdateAsync(personDTO);

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var result = await _personService.DeleteAsync(id);

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet]
        [Route("paged")]
        public async Task<ActionResult> GetPagedAsync([FromQuery] PersonFilterDb request)
        {
            var result = await _personService.GetPagedAsync(request);

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }
    }
}
