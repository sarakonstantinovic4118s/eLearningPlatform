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
    public class KurseviServices : IKurseviServices
    {
        private readonly IMongoCollection<Kursevi> kursevi;

       // KONEKCIJA
        public KurseviServices(IDatabaseSettings podesavanja)
        {
            var client = new MongoClient(podesavanja.ConnectionString);
            var database = client.GetDatabase(podesavanja.DatabaseName);
            this.kursevi = database.GetCollection<Kursevi>("Kursevi");
        }

        //READ
        public List<Kursevi> Read()
        {
            // selektovanje svih kurseva
            var k = kursevi.Find(k => true);
            return k.ToList();
        }
        //INSERT
        public Kursevi Insert(Kursevi kurs)
        {
            kursevi.InsertOne(kurs);
            return kurs;
        }
        //FIND
        public Kursevi Find(string id) =>
          kursevi.Find(sub => sub.kursID == id).SingleOrDefault();

        //UPDATE
        public void UpdateCourse(Kursevi kurs) =>
                    kursevi.ReplaceOne(sub => sub.kursID == kurs.kursID, kurs);

        //DELETE
        public void DeleteCourse(string id)
        {
            kursevi.DeleteOne(sub => sub.kursID == id);
        }

        //trazi sve kurseve koji imaju odredjen id kategorije
        public List<Kursevi> findCourses(string kategorijaID)
            {
                var k = kursevi.Find(k => k.kategorijaID == kategorijaID);
                return k.ToList();
            }
        

        public List<Kursevi> FindBySchool(string schoolID)
        {
            var k = kursevi.Find(k => k.skolaID == schoolID);
            return k.ToList();
        }

    }


}
