using eLearning.Interfaces;
using eLearning.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eLearning.Services
{
    public class KurseviServices : IKurseviServices
    {
        private readonly IMongoCollection<Kursevi> kursevi;

        public KurseviServices(IDatabaseSettings podesavanja)
        {
            var client = new MongoClient(podesavanja.ConnectionString);
            var database = client.GetDatabase(podesavanja.DatabaseName);
            this.kursevi = database.GetCollection<Kursevi>("kursevi");
        }

        public List<Kursevi> Read()
        {
            // selektovanje svih korisnika
            var k = kursevi.Find(k => true);
            return k.ToList();
        }
    }
}
