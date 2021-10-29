using System;
using System.ComponentModel.DataAnnotations;

namespace MongoRedisFluentValidator.Entity
{
    public class Pessoa
    {
        [Display(Name = "_id")]
        public Guid Id { get; set; }

        [Display(Name="Nome")]
        public string Nome { get; set; }

        [Display(Name = "DataNascimento")]
        public DateTime DataNascimento { get; set; }

        [Display(Name = "Preco")]
        public decimal Preco { get; set; }

        public Pessoa(string nome,DateTime data,Decimal preco)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            DataNascimento = data;
            Preco = preco;
        }

    }
}
