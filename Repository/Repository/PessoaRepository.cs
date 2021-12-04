using Domain.Repository;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoRedisFluentValidator.Entity;
using MongoRedisFluentValidator.Infraestrutura.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MongoRedisFluentValidator.Infraestrutura
{
    public class PessoaRepository : IPessoaRepository
    {
        private readonly IMongoCollection<Pessoa> _connectionMongo;
        public PessoaRepository()
        {
            _connectionMongo = Conexao.Database().GetCollection<Pessoa>("Pessoa");
        }

        public void InsertPessoa(Pessoa request)
        {
            _connectionMongo.InsertOne(request);
        }

        public async Task<IEnumerable<Pessoa>> GetPessoa()
        {
            return await _connectionMongo.Find(Builders<Pessoa>.Filter.Empty).ToListAsync();
        }

        public async Task<Pessoa> GetPessoaById(Guid id)
        {
            return await _connectionMongo.Find(x => x.Id == id).SingleAsync();
        }

        public async Task<DeleteResult> DeletePessoa(Guid id) 
        {
            return await _connectionMongo.DeleteOneAsync<Pessoa>(x => x.Id == id);
        }
    }
}
