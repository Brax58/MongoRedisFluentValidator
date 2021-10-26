using MongoDB.Driver;

namespace MongoRedisFluentValidator.Infraestrutura.Base
{
    public class Conexao
    {
        public static IMongoDatabase Database() 
        {
            var Conexao = new MongoClient("mongodb://localhost:27017");
            return Conexao.GetDatabase("Loja");
        }
    }
}
