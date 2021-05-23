using eLearning.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eLearning.ViewModels.Admin
{
    public class CourseViewModel
    {
        //KURSEVI 
        public List<Kursevi> kursevi { get; set; }
        public Kursevi kurs { get; internal set; }

        [DisplayName("Course name")]
        [Required]
        public string imekursa { get; set; }

        [DisplayName("About course")]
        [Required]
        public string detaljikursa { get; set; }

        [DisplayName("Course link")]
        [Required]
        public string link { get; set; }

        [DisplayName("Picture")]
        public IFormFile slika { get; set; }

        [DisplayName("Course level")]
        [Required]
        public decimal nivoKursa { get; set; }

        public List<Kategorije> kategorije { get; set; }
        public List<Skola> skole { get; set; }
        public string kategorijaID { get; set; }
        public string imeKategorije { get; set; }
        public string skolaID { get; set; }
    }
}
