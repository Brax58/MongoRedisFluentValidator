using MediatR;
using Microsoft.AspNetCore.Mvc;
using MongoRedisFluentValidator.DTO;
using MongoRedisFluentValidator.Entity;
using MongoRedisFluentValidator.Service.DTO;
using MongoRedisFluentValidator.Service.DTO.BaseDTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MongoRedisFluentValidator.Controllers
{
    [ApiController]
    [Route("api")]
    public class PessoaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PessoaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Pessoa")]
        public async Task<ActionResult<Guid>> InsertPessoa([FromBody] InsertPessoaDTO request)
        {
            return Ok(await _mediator.Send(request));
        }

        [HttpGet("Pessoas")]
        public async Task<ActionResult> GetPessoa()
        {
            var request = new ParamEmpty<IEnumerable<Pessoa>>();

            return Ok(await _mediator.Send(request));
        }

        [HttpGet("Pessoas/{idPessoa}")]
        public async Task<ActionResult> GetPessoaById([FromRoute] Guid idPessoa)
        {
            return Ok(await _mediator.Send(new IdRequisitions<Pessoa>(idPessoa)));
        }

        [HttpDelete("Pessoa/{idPessoa}")]
        public async Task<ActionResult> DeletePessoa([FromRoute]Guid idPessoa)
        {
            return Ok(await _mediator.Send(new IdRequisitions<Unit>(idPessoa)));
        }

        [HttpDelete("Pessoa/{IdPessoa}")]
        public async Task<ActionResult> UpdatePessoa([FromRoute] Guid) 
        {
            return Ok(await _mediator.Send());
        }
    }                                                                                                                                          
}
