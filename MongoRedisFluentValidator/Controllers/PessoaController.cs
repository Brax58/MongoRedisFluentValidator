using MediatR;
using Microsoft.AspNetCore.Mvc;
using MongoRedisFluentValidator.DTO;
using MongoRedisFluentValidator.Service.DTO;
using MongoRedisFluentValidator.Service.DTO.BaseDTO;
using System;
using System.Threading.Tasks;

namespace MongoRedisFluentValidator.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class PessoaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PessoaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> InsertPessoa([FromBody] InsertPessoaDTO request)
        {
            return Ok(await _mediator.Send(request));
        }

        [HttpGet]
        public async Task<ActionResult> GetPessoa()
        {
            return Ok(await _mediator.Send(new ParamEmpty<GetPessoaDTO>()));
        }
    }                                                                                                                                          
}
