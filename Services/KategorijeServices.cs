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
    public class KategorijeServices : IkategorijeServices
    {

        private readonly IMongoCollection<Kategorije> kategorije;

        public KategorijeServices(IDatabaseSettings podesavanja)
        {
            var client = new MongoClient(podesavanja.ConnectionString);
            var database = client.GetDatabase(podesavanja.DatabaseName);
            this.kategorije = database.GetCollection<Kategorije>("Kategorije");
        }



        public List<Kategorije> Read()
        {
            // selektovanje svih kurseva
            var k = kategorije.Find(k => true);
            return k.ToList();
        }
    }
}
