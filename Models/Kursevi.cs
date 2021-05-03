using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eLearning.Models
{
    public class Kursevi
    {
        public string kursID { get; set; }
        public string imeKursa { get; set; }
        public string detajiKursa { get; set; }
        public string link { get; set; }
        public string slika { get; set; }
        public decimal nivoKursa { get; set; }
    }
}
