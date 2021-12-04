using Domain.Repository;
using MediatR;
using MongoRedisFluentValidator.Service.DTO;
using MongoRedisFluentValidator.Service.DTO.BaseDTO;
using StackExchange.Redis;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;
using System;
using MongoRedisFluentValidator.Entity;

namespace MongoRedisFluentValidator.Service.Service
{
    public class GetPessoaService : IRequestHandler<ParamEmpty<IEnumerable<Pessoa>>, IEnumerable<Pessoa>>
    {
        private readonly IPessoaRepository _pessoaRepository;
        private readonly IConnectionMultiplexer _redis;

        public GetPessoaService(IPessoaRepository repository, IConnectionMultiplexer redis)
        {
            _pessoaRepository = repository;
            _redis = redis;
        }

        public async Task<IEnumerable<Pessoa>> Handle(ParamEmpty<IEnumerable<Pessoa>> request,CancellationToken cancellationToken) 
        {
            var redis = _redis.GetDatabase(2);

            var pessoaCache = await redis.StringGetAsync($"Get:Pessoa");

            if (pessoaCache.HasValue) 
            {
                return JsonConvert.DeserializeObject<List<Pessoa>>(pessoaCache);
            }

            var pessoa = await _pessoaRepository.GetPessoa();

            await redis.StringSetAsync($"GET:Pessoa",JsonConvert.SerializeObject(pessoa),TimeSpan.FromDays(30));
            return pessoa;
        }
    }
}
