using CrudMongoDb.Config;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using CrudMongoDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudMongoDb.Models {
    public class Contexto {
        //Variáveis privadas
        private readonly IMongoDatabase _mongoDatabase;

        //Construtor que recebe o parâmetro de IOptions<ConfigDB>
        public Contexto(IOptions<ConfigDB> opcoes ) {
            MongoClient mongoClient = new MongoClient(opcoes.Value.ConnectionString);

            if(mongoClient != null) {
                _mongoDatabase = mongoClient.GetDatabase(opcoes.Value.Database);
            } 
        }
        //Propriedade
        public IMongoCollection<Pessoa> Pessoas {
            get {
                return _mongoDatabase.GetCollection<Pessoa>("Pessoas");
            }
        }
    }
}

