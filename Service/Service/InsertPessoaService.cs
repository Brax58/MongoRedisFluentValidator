using Domain.Repository;
using MediatR;
using MongoDB.Bson;
using MongoRedisFluentValidator.DTO;
using MongoRedisFluentValidator.Entity;
using StackExchange.Redis;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MongoRedisFluentValidator.Service
{
    public class InsertPessoaService : IRequestHandler<InsertPessoaDTO, Guid>
    {
        private readonly IPessoaRepository _pessoaRepository;
        private readonly IConnectionMultiplexer _redis;

        public InsertPessoaService(IPessoaRepository pessoaRepository, IConnectionMultiplexer redis)
        {
            _pessoaRepository = pessoaRepository;
            _redis = redis;
        }

        public Task<Guid> Handle(InsertPessoaDTO request, CancellationToken cancellationToken)
        {
            var redis = _redis.GetDatabase(2);
            var pessoa = new Pessoa(request.Nome, request.DataNascimento, request.Preco);
            
            _pessoaRepository.InsertPessoa(pessoa);
            redis.KeyDelete($"GET:Pessoa");

            return Task.FromResult(pessoa.Id);
        }
    }
}
