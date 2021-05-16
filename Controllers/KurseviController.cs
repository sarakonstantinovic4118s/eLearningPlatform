using eLearning.Interfaces;
using eLearning.Models;
using eLearning.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace eLearning.Controllers
{
    public class KurseviController : Controller
    {

        // instanciranje servisa (svih funkcija koje su navedene u IKorisnikServices i implementirane u KorisnikServices) za kontrolu korisnika
        private readonly IKurseviServices _kurseviServices;
        private readonly IKategorijeServices _kategorijeServices;
        // 
        public KurseviController(IKurseviServices kurseviServices, IKategorijeServices kategorijeServices)
        {
            _kurseviServices = kurseviServices;
            _kategorijeServices = kategorijeServices;
        }



   

        [HttpGet]
        public IActionResult Courses(string name, int? page, int? size)
        {
            List<Kategorije> listKategorija = new List<Kategorije>();
            listKategorija = _kategorijeServices.Read();


            List<Kursevi> kursevi;
            // prosledjivanje name parametra za pretragu u View radi njegovog pamcenja u formi. 
            ViewBag.name = name;

            // podrazumevana stranica i broj skola
            int defaultPage = 1;
            int defaultSize = 9;

            // dodeljivanje podrazumevanih vrednosti ako su parametri null
            if (page == null) page = defaultPage;
            if (size == null) size = defaultSize;

            // ucitavanje stranice sa kursevima
            // ako je unet parametar za pretragu ucitati kurseve
            int courseCount;
            if (name != null)
            {
                kursevi = _kurseviServices.CourseSearch(name, (int)page, (int)size);
                courseCount = (int)_kurseviServices.Count(name);
            }
            else
            {
                kursevi = _kurseviServices.ReadPage((int)page, (int)size);
                courseCount = (int)_kurseviServices.Count(null);
            }

            if (courseCount == 0) courseCount++;
            // odredjivanje maksimalnog broja stranica
            double maxPages = courseCount / (double)size;
            maxPages = Math.Ceiling(maxPages);

            // Ako je premasen broj mogucih stranica
            if (page > maxPages)
                return NotFound();

            // prosledjivanje u View zbog generisanja menija sa stranicama
            ViewBag.page = page;
            ViewBag.maxPages = maxPages;
            var viewmodel = new KursKategorijaViewModel
            {
                kursevi = kursevi,
                kategorije = listKategorija
            };

            return View(viewmodel);
        }

        [HttpGet]

        public ActionResult<Kursevi> CourseDetails(string id) {
            var findKurs = _kurseviServices.Find(id);
           return View(findKurs);
        }

       
        [HttpGet]
        public ActionResult CategoryDetails(string name, int? page, int? size , string id)
        {
            List<Kategorije> listKategorija = new List<Kategorije>();
            listKategorija = _kategorijeServices.Read();
       

            List<Kursevi> kursevi;
            // prosledjivanje name parametra za pretragu u View radi njegovog pamcenja u formi. 
            ViewBag.name = name;

            // podrazumevana stranica i broj skola
            int defaultPage = 1;
            int defaultSize = 9;

            // dodeljivanje podrazumevanih vrednosti ako su parametri null
            if (page == null) page = defaultPage;
            if (size == null) size = defaultSize;

            // ucitavanje stranice sa kursevima prema selektovanoj kategoriji
            // ako je unet parametar za pretragu ucitati kurseve koji pripadaju datoj kategoriji
            int courseCount;
            if (name != null)
            {
                kursevi = _kurseviServices.CourseSearchkat(name, (int)page, (int)size, (string) id);
                courseCount = (int)_kurseviServices.Count(name);
            }
            else
            {
                kursevi = _kurseviServices.ReadPageKat((int)page, (int)size, (string)id);
                courseCount = (int)_kurseviServices.Count(null);
            }

            if (courseCount == 0) courseCount++;
            // odredjivanje maksimalnog broja stranica
            double maxPages = courseCount / (double)size;
            maxPages = Math.Ceiling(maxPages);

            // Ako je premasen broj mogucih stranica
            if (page > maxPages)
                return NotFound();

            // prosledjivanje u View zbog generisanja menija sa stranicama
            ViewBag.page = page;
            ViewBag.maxPages = maxPages;
            var viewmodel = new KursKategorijaViewModel
            {
                kursevi = kursevi,
                kategorije = listKategorija
            };

            return View(viewmodel);
        }










    }
}
