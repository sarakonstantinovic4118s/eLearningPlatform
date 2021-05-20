using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eLearning.Models;

namespace eLearning.ViewModels
{
    public class KursKategorijaViewModel
    {
        public List<Kategorije> kategorijes { get; set; }
        public List<DetailsForCourseViewModel> kursevis { get; set; }

        public Kategorije kategorijeSingle { get; set; }
        public List<Kursevi> KurseviKategorije { get; set; }

       
    }
}
