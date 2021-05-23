using eLearning.Interfaces;
using eLearning.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eLearning.Services
{
    public class ProgramServices : IProgramServices
    {
        private readonly IMongoCollection<SekcijaPrograma> _programs;

        public ProgramServices(IDatabaseSettings podesavanja)
        {
            var client = new MongoClient(podesavanja.ConnectionString);
            var database = client.GetDatabase(podesavanja.DatabaseName);
            _programs = database.GetCollection<SekcijaPrograma>("SekcijePrograma");
        }

        public List<SekcijaPrograma> Read()
        {
            return _programs.Find(p => true).ToList();
        }

        public void Insert(SekcijaPrograma sekcija)
        {
            _programs.InsertOne(sekcija);
        }
    }
}
