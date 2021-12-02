using Domain.Repository;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoRedisFluentValidator.Entity;
using MongoRedisFluentValidator.Infraestrutura.Base;
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
            return await _connectionMongo.Find(new BsonDocument()).ToListAsync();
        }
        
        public async Task<Pessoa> GetPessoaById(string nome)
        {
            return await _connectionMongo.Find(x => x.Nome == nome).SingleAsync();
        }
    }
}
