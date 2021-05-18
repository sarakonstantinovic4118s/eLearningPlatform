using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace eLearning.Models
{
    public class Kategorije
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string kategorijaID { get; set; }

        public string imekategorije { get; set; }

       
    }
}
