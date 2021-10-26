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
        [HttpPost]
        public async Task<Guid> InsertPessoa([FromBody] InsertPessoaDTO request) 
        {
            
        }
    }
}
