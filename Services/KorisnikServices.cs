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
    public class KorisnikServices : IKorisnikServices
    {
        private readonly IMongoCollection<Korisnik> korisnici;

        public KorisnikServices(IDatabaseSettings podesavanja)
        {
            var client = new MongoClient(podesavanja.ConnectionString);
            var database = client.GetDatabase(podesavanja.DatabaseName);
            this.korisnici = database.GetCollection<Korisnik>("Korisnici");
        }
        //FIND
        public Korisnik FindID(string id) =>
            korisnici.Find(sub => sub.userID == id).SingleOrDefault();

        // selektovanje svih korisnika
        public List<Korisnik> Read()
        {
            var k = korisnici.Find(k => true);
            return k.ToList();
        }
        public Korisnik Find(string korisnickoIme)
        {
            // pretraga korisnika po korisnickom imenu
            var k = korisnici.Find(k => k.korisnickoIme == korisnickoIme).SingleOrDefault();
            return k;
        }
        public Korisnik FindUserById(string id)
        {
            // pretraga korisnika po ID korisnika
            var k = korisnici.Find(k => k.userID == id).SingleOrDefault();
            return k;
        }
        public Korisnik UpdateUserPassword(string id, Korisnik korisnik)
        {
            // update user password-a po ID korisnika
            var k = korisnici.UpdateOne(x => x.userID == id, Builders<Korisnik>.Update.Set(x => x.password, korisnik.password));

            return korisnik;
        }
        
        public Korisnik Insert(Korisnik k)
        {
            // dodavanje novog korisnika
            korisnici.InsertOne(k);
            return k;
        }
        //UPDATE
        public void UpdateUser(Korisnik korisnik) =>
                korisnici.ReplaceOne(sub => sub.userID == korisnik.userID, korisnik);
        //DELETE 
        public void DeleteUser(string id)
        {
            korisnici.DeleteOne(sub => sub.userID == id);
        }

       
        
    }
}
