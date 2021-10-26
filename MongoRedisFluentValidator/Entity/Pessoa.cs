using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace MongoRedisFluentValidator.Entity
{
    public class Pessoa
    {
        [BsonRepresentation(BsonType.ObjectId)]
        [Display(Name = "_id")]
        public string Id { get; set; }

        [Display(Name="Nome")]
        public string Nome { get; set; }

        [Display(Name = "DataNascimento")]
        public DateTime DataNascimento { get; set; }

    }
}
