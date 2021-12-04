using MongoDB.Driver;
using MongoRedisFluentValidator.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public interface IPessoaRepository
    {
        void InsertPessoa(Pessoa request);
        Task<IEnumerable<Pessoa>> GetPessoa();
        Task<Pessoa> GetPessoaById(Guid id);
        Task<DeleteResult> DeletePessoa(Guid id);
    }
}
