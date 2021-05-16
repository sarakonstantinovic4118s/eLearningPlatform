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

        public KurseviServices(IDatabaseSettings podesavanja)
        {
            var client = new MongoClient(podesavanja.ConnectionString);
            var database = client.GetDatabase(podesavanja.DatabaseName);
            this.kursevi = database.GetCollection<Kursevi>("Kursevi");
        }



        public List<Kursevi> Read()
        {
            // selektovanje svih kurseva
            var k = kursevi.Find(k => true);
            return k.ToList();
        }

        public Kursevi Find(string id) =>
          kursevi.Find(sub => sub.kursID == id).SingleOrDefault();

        //trazi sve kurseve koji imaju odredjen id kategorije
      public List<Kursevi> findCourses(string kategorijaID)
        {
            var k = kursevi.Find(k => k.kategorijaID == kategorijaID);
            return k.ToList();
        }

        public List<Kursevi> ReadPage(int stranica, int velicinaStranice)
        {
            int skip = velicinaStranice * (stranica - 1);

            List<Kursevi> k = kursevi.Find(s => true)
                .Skip(skip)
                .Limit(velicinaStranice)
                .ToList();

            return k;
        }

        public List<Kursevi> ReadPageKat(int stranica, int velicinaStranice,string kategorijaID)
        {
            int skip = velicinaStranice * (stranica - 1);
       
            

            List<Kursevi> k = kursevi.Find(k => k.kategorijaID == kategorijaID)
                .Skip(skip)
                .Limit(velicinaStranice)
                .ToList();

            return k;
        }

        public long Count(string name)
        {
            if (name != null)
                return kursevi.CountDocuments(k => k.imekursa.ToLower().Contains(name.ToLower()));
            return kursevi.CountDocuments(k => true);
        }

        public List<Kursevi> CourseSearch(string name, int stranica, int velicinaStranice)
        {
            int skip = velicinaStranice * (stranica - 1);

            var k = kursevi.Find(k => k.imekursa.ToLower().Contains(name.ToLower()))
                .Skip(skip)
                .Limit(velicinaStranice);

            return k.ToList();
        }


        public List<Kursevi> CourseSearchkat(string name, int stranica, int velicinaStranice, string kategorijaID)
        {
            int skip = velicinaStranice * (stranica - 1);

            var k = kursevi.Find(k => k.kategorijaID == kategorijaID &  k.imekursa.ToLower().Contains(name.ToLower())  )
                .Skip(skip)
                .Limit(velicinaStranice);

            return k.ToList();
        }
    }


}
