using eLearning.Interfaces;
using eLearning.Models;
using eLearning.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eLearning.Controllers
{
    public class ProgramController : Controller
    {
        private readonly IProgramServices _programServices;
        private readonly IKurseviServices _kurseviServices;
        private readonly IKategorijeServices _kategorijeServices;
        private readonly ISchoolServices _schoolServices;

        public ProgramController(
            IProgramServices programServices,
            IKurseviServices kurseviServices,
            IKategorijeServices kategorijeServices,
            ISchoolServices schoolServices)
        {
            _programServices = programServices;
            _kurseviServices = kurseviServices;
            _kategorijeServices = kategorijeServices;
            _schoolServices = schoolServices;
        }

        public IActionResult Index()
        {
            // ucitavanje podataka iz baze
            List<SekcijaPrograma> sekcije = _programServices.Read();
            // sortiranje sekcija prema broju
            sekcije = sekcije.OrderBy(s => s.Broj).ToList();

            // Generisanje liste sekcija za prikaz korisniku
            List<SekcijaViewModel> ListaSekcija = new();

            foreach (SekcijaPrograma sekcija in sekcije)
            {
                // lista za smestanje kurseva koji se nalaze u sekciji
                List<KursSekcijeViewModel> kurseviVM = new();

                // sortiranje kurseva prema broju
                sekcija.Kursevi = sekcija.Kursevi.OrderBy(k => k.Broj).ToList();

                // Prolazak kroz niz ID kurseva
                foreach (var k in sekcija.Kursevi)
                {
                    // trazenje kursa prema ID
                    Kursevi dbKurs = _kurseviServices.Find(k.KursID);

                    // popunjavanje liste sa kursevima
                    if (dbKurs != null)
                    {
                        kurseviVM.Add(new KursSekcijeViewModel
                        {
                            Naziv = dbKurs.imekursa,
                            Nivo = _kurseviServices.getLevel(dbKurs.nivoKursa), 
                            NivoID = dbKurs.nivoKursa,
                            Broj = k.Broj,
                            Kategorija = _kategorijeServices.Find(dbKurs.kategorijaID).imekategorije,
                            Skola = _schoolServices.Find(dbKurs.skolaID).naziv,
                            Link = dbKurs.kursID
                        });
                        kurseviVM = kurseviVM.OrderBy(k => k.NivoID).ThenBy(k => k.Broj).ToList();
                    }
                }

                // popunjavanje liste sa sekcijama
                ListaSekcija.Add(new SekcijaViewModel
                {
                    Opis = sekcija.Opis,
                    Kursevi = kurseviVM
                });
            }

            return View(ListaSekcija);
        }

/*        //insert
          _programServices.Insert(new SekcijaPrograma
            {
                Opis = "Opis prve sekcije",
                Broj = 1,
                Kursevi = new List<KurseviSekcije>()
                {
                    new KurseviSekcije { KursID = "60a6ab7ee72d52bfeea8ce0d", Broj = 1 }
}
            });*/
    }
}
