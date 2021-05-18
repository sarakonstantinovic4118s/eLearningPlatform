using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eLearning.Models
{
    public class Skola
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string skolaID { get; set; }
        public string naziv { get; set; }
        public string logo { get; set; }
    }
}
