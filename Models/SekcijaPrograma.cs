using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eLearning.Models
{
    public class SekcijaPrograma
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Opis { get; set; }
        public int Broj { get; set; }
        public List<KurseviSekcije> Kursevi { get; set; }
    }

    public class KurseviSekcije
    {
        public string KursID { get; set; }
        public int Broj { get; set; }
    }
}
