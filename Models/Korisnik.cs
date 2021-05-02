using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace eLearning.Models
{
    public class Korisnik
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string userID { get; set; }
        public string korisnickoIme { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public int tip { get; set; }
    }
}
