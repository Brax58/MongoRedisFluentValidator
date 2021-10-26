using MongoRedisFluentValidator.Entity;

namespace Domain.Repository
{
    public interface IPessoaRepository
    {
        void InserirPessoa(Pessoa request);
    }
}
