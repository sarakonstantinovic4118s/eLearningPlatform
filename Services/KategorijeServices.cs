using eLearning.Interfaces;
using eLearning.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace eLearning.Services
{
    public class KategorijeServices : IKategorijeServices
    {

        private readonly IMongoCollection<Kategorije> kategorije;

        public KategorijeServices(IDatabaseSettings podesavanja)
        {
            var client = new MongoClient(podesavanja.ConnectionString);
            var database = client.GetDatabase(podesavanja.DatabaseName);
            this.kategorije = database.GetCollection<Kategorije>("Kategorije");
        }

        //SEARCH 
        public List<Kategorije> searchReadCategory(string name)
        {
            var kategorija = kategorije.Find(kategorija => kategorija.imekategorije.ToLower().Contains(name.ToLower()));

            return kategorija.ToList();
        }

        //READ
        public List<Kategorije> Read()
        {
            // selektovanje svih kategorija
            var k = kategorije.Find(k => true);
            return k.ToList();
        }
        //INSERT
        public Kategorije Insert(Kategorije kategorija)
        {
            kategorije.InsertOne(kategorija);
            return kategorija;
        }

        public Kategorije Find(string id) => kategorije.Find(sub => sub.kategorijaID == id).SingleOrDefault();
        public Kategorije FindByName(string name) => kategorije.Find(sub => sub.imekategorije == name).SingleOrDefault();

        //DELETE
        public void DeleteCategory(string id)
        {
            kategorije.DeleteOne(sub => sub.kategorijaID == id);
        }
        //UPDATE
        public void UpdateCategory(Kategorije kategorija) => 
                kategorije.ReplaceOne(sub => sub.kategorijaID == kategorija.kategorijaID, kategorija);
        
    }
}

