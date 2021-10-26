using Domain.Repository;

namespace MongoRedisFluentValidator.Service
{
    public class InsertPessoaService
    {
        private readonly IPessoaRepository _pessoaRepository;

        public InsertPessoaService(IPessoaRepository pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }


    }
}
