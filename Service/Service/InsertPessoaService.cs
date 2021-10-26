using Domain.Repository;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace MongoRedisFluentValidator.Service
{
    public class InsertPessoaService : IRequestHandler<Unit,InsertPessoaService>
    {
        private readonly IPessoaRepository _pessoaRepository;

        public InsertPessoaService(IPessoaRepository pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }

        public async Task<Unit> Handle(InsertPessoaService request, CancellationToken cancellationToken) 
        {
           
        }
    }
}
