using eLearning.Interfaces;
using eLearning.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eLearning.Services
{
    public class SchoolServices : ISchoolServices
    {
        private readonly IMongoCollection<Skola> skole;

        public SchoolServices(IDatabaseSettings podesavanja)
        {
            var client = new MongoClient(podesavanja.ConnectionString);
            var database = client.GetDatabase(podesavanja.DatabaseName);
            this.skole = database.GetCollection<Skola>("Skole");
        }

        public List<Skola> Read()
        {
            List<Skola> s = skole.Find(s => true).ToList();
            return s;
        }

        public List<Skola> ReadPage(int stranica, int velicinaStranice)
        {
            int skip = velicinaStranice * (stranica - 1);

            List<Skola> s = skole.Find(s => true)
                .Skip(skip)
                .Limit(velicinaStranice)
                .ToList();

            return s;
        }

        public long Count(string name)
        {
            if (name != null)
                return skole.CountDocuments(s => s.naziv.ToLower().Contains(name.ToLower()));
            return skole.CountDocuments(s => true);
        }

        public Skola Find(string skolaID)
        {
            Skola s = skole.Find(s => s.skolaID == skolaID).SingleOrDefault();
            return s;
        }

        public List<Skola> FindByName(string name, int stranica, int velicinaStranice)
        {
            int skip = velicinaStranice * (stranica - 1);

            var s = skole.Find(s => s.naziv.ToLower().Contains(name.ToLower()))
                .Skip(skip)
                .Limit(velicinaStranice);

            return s.ToList();
        }
    }
}
