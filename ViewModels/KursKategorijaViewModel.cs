using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eLearning.Models;

namespace eLearning.ViewModels
{
    public class KursKategorijaViewModel
    {
        public List<Kategorije> kategorije { get; set; }
        public List<Kursevi> kursevi { get; set; }

        public Kategorije kategorijeSingle { get; set; }
        public List<Kursevi> KurseviKategorije { get; set; }

       
    }
}
