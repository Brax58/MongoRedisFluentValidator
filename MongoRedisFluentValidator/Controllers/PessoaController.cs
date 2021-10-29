using MediatR;
using Microsoft.AspNetCore.Mvc;
using MongoRedisFluentValidator.DTO;
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
        public ActionResult<Guid> InsertPessoa([FromBody] InsertPessoaDTO request) 
        {
            return Ok(_mediator.Send(request));
        }
    }
}
