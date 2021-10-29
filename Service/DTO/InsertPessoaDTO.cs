using MediatR;
using System;

namespace MongoRedisFluentValidator.DTO
{
    public class InsertPessoaDTO : IRequest<Guid>
    {
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public decimal Preco { get; set; }
    }
}
