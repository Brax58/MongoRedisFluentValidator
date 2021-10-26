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

    }
}
