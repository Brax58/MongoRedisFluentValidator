using Domain.Repository;
using MediatR;
using MongoRedisFluentValidator.Entity;
using MongoRedisFluentValidator.Service.DTO;
using MongoRedisFluentValidator.Service.DTO.BaseDTO;
using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MongoRedisFluentValidator.Service.Service
{
    internal class GetPessoaByIdService : IRequestHandler<IdRequisitions<Pessoa>, Pessoa>
    {
        private readonly IPessoaRepository _pessoaRepository;
        private readonly IConnectionMultiplexer _redis;

        public GetPessoaByIdService(IPessoaRepository pessoaRepository, IConnectionMultiplexer redis)
        {
            _pessoaRepository = pessoaRepository;
            _redis = redis;
        }

        public async Task<Pessoa> Handle(IdRequisitions<Pessoa> request, CancellationToken cancellationToken)
        {
            if (request != null || request.Id != Guid.Empty)
            {
                var redis = _redis.GetDatabase(2);
                var pessoaRepository = await _pessoaRepository.GetPessoaById(request.Id);
                var pessoaCache = await redis.StringGetAsync($"GET:{request.Id}");

                if (!pessoaCache.HasValue)
                {
                    if (pessoaRepository == null)
                        throw new Exception("Pessoa não encontrada!");

                    await redis.StringSetAsync($"GET:{request.Id}", JsonConvert.SerializeObject(pessoaRepository), TimeSpan.FromDays(30));
                    return pessoaRepository;
                }

                return JsonConvert.DeserializeObject<Pessoa>(pessoaCache);
            }
            else
                throw new Exception("Id incorreto!");
        }
    }
}
