using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eLearning.ViewModels
{
    public class SekcijaViewModel
    {
        public string Opis { get; set; }
        public List<KursSekcijeViewModel> Kursevi { get; set; }
    }

    public class KursSekcijeViewModel
    {
        public string Naziv { get; set; }
        public string Skola { get; set; }
        public string Kategorija { get; set; }
        public string Nivo { get; set; }
        public int NivoID { get; set; }
        public int Broj { get; set; }
        public string Link { get; set; }
    }
}
