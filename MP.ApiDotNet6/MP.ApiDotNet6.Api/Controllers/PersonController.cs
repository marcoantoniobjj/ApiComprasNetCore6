using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MP.ApiDotNet6.Application.DTOs;
using MP.ApiDotNet6.Application.Services.Interfaces;
using MP.ApiDotNet6.Domain.FiltersDb;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MP.ApiDotNet6.Api.Controllers
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
        public async Task<ActionResult> Post([FromBody] PersonDTO personDTO)
        {
            var result = await _personService.CreateAsync(personDTO);
            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);

        }


        //Fizemos o servico agora faremos os endpoints

        [HttpGet] //metod para retornar VARIAS pessoas
        public async Task<ActionResult> GetAsync()
        {

            var result = await _personService.GetAsync();
            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet]//metod para retornar UMA pessoa
        [Route("{id}")]
        public async Task<ActionResult> GetByIdAsync(int id)
        {

            var result = await _personService.GetByIdAsync(id);
            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAsync([FromBody] PersonDTO personDTO)
        {
            var result = await _personService.UpdateAsync(personDTO);
            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);

        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var result = await _personService.DeleteAsync(id);
            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);

        }

        [HttpGet]
        [Route("paged")]
        public async Task<ActionResult> GetPagedAsync([FromQuery] PersonFilterDb personFilterDb)
        {
          var result = await _personService.GetPagedAsync(personFilterDb);
            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);

        }



    }



}

