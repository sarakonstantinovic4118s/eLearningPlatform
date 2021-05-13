using eLearning.Interfaces;
using eLearning.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eLearning.Controllers
{
    public class SchoolsController : Controller
    {
        private readonly ISchoolServices _schoolServices;
        private readonly IKurseviServices _kurseviServices;

        public SchoolsController(ISchoolServices schoolServices, IKurseviServices kurseviServices)
        {
            _schoolServices = schoolServices;
            _kurseviServices = kurseviServices;
        }

        [HttpGet]
        public IActionResult Index(string name, int? page, int? size)
        {
            List<Skola> skole;
            // prosledjivanje name parametra za pretragu u View radi njegovog pamcenja u formi. 
            ViewBag.name = name;

            // podrazumevana stranica i broj skola
            int defaultPage = 1;
            int defaultSize = 8;

            // dodeljivanje podrazumevanih vrednosi ako su parametri null
            if (page == null) page = defaultPage;
            if (size == null) size = defaultSize;

            // ucitavanje stranice sa skolama
            // ako je unet parametar za pretragu ucitati skole
            int schoolCount;
            if (name != null)
            {
                skole = _schoolServices.FindByName(name, (int)page, (int)size);
                schoolCount = (int)_schoolServices.Count(name);
            }
            else
            {
                skole = _schoolServices.ReadPage((int)page, (int)size);
                schoolCount = (int)_schoolServices.Count(null);
            }

            if (schoolCount == 0) schoolCount++;
            // odredjivanje maksimalnog broja stranica
            double maxPages = schoolCount / (double)size;
            maxPages = Math.Ceiling(maxPages);

            // Ako je premasen broj mogucih stranica
            if (page > maxPages)
                return NotFound();

            // prosledjivanje u View zbog generisanja menija sa stranicama
            ViewBag.page = page;
            ViewBag.maxPages = maxPages;

            return View(skole);
        }

        // Metoda koja vraca parcijalni view za ispis kurseva prema skoli
        [HttpPost]
        public IActionResult SchoolCourses(string schoolID)
        {
            List<Kursevi> courses = _kurseviServices.FindBySchool(schoolID);
            ViewBag.skola = _schoolServices.Find(schoolID);
            return PartialView("_SchoolCourses", courses);
        }
    }
}
