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
    public class KorisnikServices : IKorisnikServices
    {
        private readonly IMongoCollection<Korisnik> korisnici;

        public KorisnikServices(IDatabaseSettings podesavanja)
        {
            var client = new MongoClient(podesavanja.ConnectionString);
            var database = client.GetDatabase(podesavanja.DatabaseName);
            this.korisnici = database.GetCollection<Korisnik>("Korisnici");
        }

        public List<Korisnik> Read()
        {
            // selektovanje svih korisnika

            var k = korisnici.Find(k => true);
            return k.ToList();
        }
        public List<Korisnik> Read(Korisnik korisnik)
        {
            // selektovanje svih korisnika

            //var k = korisnici.Find(k => true);
            var k = korisnici.Find(x => x.korisnickoIme == korisnik.korisnickoIme).ToList();
            return k.ToList();
        }

        public Korisnik Insert(Korisnik k)
        {
            korisnici.InsertOne(k);
            return k;
        }
    }
}
