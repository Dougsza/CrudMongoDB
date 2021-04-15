using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;

namespace CrudMongoDb.Models {
    public class Pessoa {
        [BsonElement("_id")]
        //Propriedades
        public Guid PessoaId { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Telefone { get; set; }


    }
}
