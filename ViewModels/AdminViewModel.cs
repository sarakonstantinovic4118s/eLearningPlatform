using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using eLearning.Models;
using eLearning.ViewModels.Admin;

namespace eLearning.ViewModels
{
    public class AdminViewModel
    {
        //KORISNICI
        public List<Korisnik> korisnici { get; set; }
        //public string username { get; set; }
        //public string password { get; set; }
        //public string email { get; set; }
        //public string tip { get; set; }

        //SKOLE
        public List<Skola> skole { get; set; }
        //public Skola skola { get; internal set; }
        public string skolaID { get; set; }

        //[DisplayName("School name")]
        //[Required]
        //public string naziv { get; set; }

        //[DisplayName("School logo")]
        //[Required]
        //public string logo { get; set; }

        //KURSEVI 
        public List<CourseDetailsViewModel> kursevi { get; set; }
        public List<Kursevi> kursevi2 { get; set; }
        public string imekursa { get; set; }
        public string detaljikursa { get; set; }
        public string link { get; set; }
        public string slika { get; set; }
        public Int32 nivoKursa { get; set; }
        public Kursevi kurs { get;  set; }

        //[DisplayName("Course name")]
        //[Required]
        //public string imekursa { get; set; }

        //[DisplayName("About course")]
        //[Required]
        //public string detaljikursa { get; set; }

        //[DisplayName("Course link")]
        //[Required]
        //public string link { get; set; }
        //public string slika { get; set; }

        //[DisplayName("Course level")]
        //[Required]
        //public decimal nivoKursa { get; set; }

        //KATEGORIJE
        public List<Kategorije> kategorije { get; set; }

        //[DisplayName("Category name")]
        //[Required]
        //public string imeKategorije { get; set; }
        //public string kategorijaID { get; set; }

        public CourseViewModel courseViewModel { get; set; }

    }
}
