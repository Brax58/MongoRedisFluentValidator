using MediatR;
using Microsoft.AspNetCore.Mvc;
using MongoRedisFluentValidator.DTO;
using StackExchange.Redis;
using System;
using System.Threading.Tasks;

namespace MongoRedisFluentValidator.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class PessoaController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IConnectionMultiplexer _redis;

        public PessoaController(IMediator mediator,IConnectionMultiplexer redis)
        {
            _mediator = mediator;
            _redis = redis;
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> InsertPessoa([FromBody] InsertPessoaDTO request)
        {
            return Ok(await _mediator.Send(request));
        }

        [HttpGet]
        public async Task<ActionResult> GetPessoa()
        {
        }
    }                                                                                                                                          
}
