using MongoDB.Driver;
using MongoRedisFluentValidator.Entity;
using MongoRedisFluentValidator.Infraestrutura.Base;

namespace MongoRedisFluentValidator.Infraestrutura
{
    public class PessoaRepository
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
    }
}
