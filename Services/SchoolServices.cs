using eLearning.Interfaces;
using eLearning.Models;
using MongoDB.Bson;
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

        public Skola FindID(string id) =>
                skole.Find(sub => sub.skolaID == id).SingleOrDefault();
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

        public Skola Find(string skolaID)
        {
            Skola s = skole.Find(s => s.skolaID == skolaID).SingleOrDefault();
            return s;
        }

        public (List<Skola>, int) GetSchools(string name, int page, int pageSize)
        {
            var builder = Builders<Skola>.Filter;

            var filter = builder.Empty;
            if (!String.IsNullOrEmpty(name))
                filter &= builder.Regex("naziv", new BsonRegularExpression($"/{name}/i"));

            int skip = pageSize * (page - 1);
            var count = skole.CountDocuments(filter);
            var s = skole.Find(filter).Skip(skip).Limit(pageSize);

            return (s.ToList(), (int)count);
        }


        //INSERT
        public Skola Insert(Skola skola)
        {
            skole.InsertOne(skola);
            return skola;
        }

        //UPDATE
        public void UpdateSchool(Skola skola) =>
                    skole.ReplaceOne(sub => sub.skolaID == skola.skolaID, skola);

        //DELETE
        public void DeleteSchool(string id)
        {
            skole.DeleteOne(sub => sub.skolaID == id);
        }
    }
}
