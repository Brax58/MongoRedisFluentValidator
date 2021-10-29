using Domain.Repository;
using MediatR;
using MongoRedisFluentValidator.DTO;
using MongoRedisFluentValidator.Entity;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MongoRedisFluentValidator.Service
{
    public class InsertPessoaService : IRequestHandler<InsertPessoaDTO, Guid>
    {
        private readonly IPessoaRepository _pessoaRepository;

        public InsertPessoaService(IPessoaRepository pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }

        public async Task<Guid> Handle(InsertPessoaDTO request, CancellationToken cancellationToken)
        {
            _pessoaRepository.InserirPessoa(new Pessoa(request.Nome,request.DataNascimento,request.Preco));
            var pessoa = await _pessoaRepository.BuscarPessoa(request.Nome);

            return pessoa.Id;
        }
    }
}
