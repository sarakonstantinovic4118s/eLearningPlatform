using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eLearning.Models;

namespace eLearning.ViewModels
{
    public class AdminViewModel
    {
        //KORISNICI
        public List<Korisnik> korisnici { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string tip { get; set; }


        //KURSEVI 
        public List<Kursevi> kursevi { get; set; }
        public string imekursa { get; set; }
        public string detaljikursa { get; set; }
        public string link { get; set; }
        public string slika { get; set; }
        public decimal nivoKursa { get; set; }
        public Kursevi kurs { get; internal set; }

        public Kursevi kursZaEdit { get; set; }

        //KATEGORIJE
        public List<Kategorije> kategorije { get; set; }
        public string imeKategorije { get; set; }
        public string kategorijaID { get; set; }

    }
}
