using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


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
        public Int32 nivoKursa { get; set; }
    
        public string  kategorijaID { get; set; }
        public string skolaID { get; set; }

    }
}
