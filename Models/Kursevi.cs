using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace eLearning.Models
{

    public class Kursevi 
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string kursID { get; set; }
      
        public string imekursa { get; set; }
   
        public string detaljikursa { get; set; }
     
        public string link { get; set; }
        public string slika { get; set; }
        public decimal nivoKursa { get; set; }
        public Kategorije kategorije { get; set; }

        public string KategorijaID { get; set; }
    }
}
