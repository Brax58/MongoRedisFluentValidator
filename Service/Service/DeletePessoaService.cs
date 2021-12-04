using Domain.Repository;
using MediatR;
using MongoRedisFluentValidator.Service.DTO.BaseDTO;
using StackExchange.Redis;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MongoRedisFluentValidator.Service.Service
{
    public class DeletePessoaService : IRequestHandler<IdRequisitions<Unit>,Unit>
    {
        private readonly IPessoaRepository _repository;
        private readonly IConnectionMultiplexer _redis;

        public DeletePessoaService(IPessoaRepository repository, IConnectionMultiplexer redis)
        {
            _repository = repository;
            _redis = redis;
        }

        public async Task<Unit> Handle(IdRequisitions<Unit> request,CancellationToken cancellationToken) 
        {
            var redis = _redis.GetDatabase(2);
            var pessoa = await _repository.GetPessoaById(request.Id);

            if (pessoa == null)
            {
                throw new Exception("Pessoa não encontrada!");
            }

            await _repository.DeletePessoa(pessoa.Id);
            await redis.KeyDeleteAsync($"GET:Pessoa");
            await redis.KeyDeleteAsync($"GET:{pessoa.Id}");

            return Unit.Value;
        }
    }
}
