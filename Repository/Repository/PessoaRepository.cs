using Domain.Repository;
using MongoDB.Driver;
using MongoRedisFluentValidator.Entity;
using MongoRedisFluentValidator.Infraestrutura.Base;
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

        public void InserirPessoa(Pessoa request)
        {
            _connectionMongo.InsertOne(request);
        }

        public Task<Pessoa> BuscarPessoa(string request)
        {
            return _connectionMongo.Find(x => x.Nome == request).SingleAsync();
        }
    }
}
