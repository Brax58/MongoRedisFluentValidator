using MongoDB.Driver;
using MongoRedisFluentValidator.Entity;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public interface IPessoaRepository
    {
        void InserirPessoa(Pessoa request);
        Task<Pessoa> BuscarPessoa(string request);
    }
}
