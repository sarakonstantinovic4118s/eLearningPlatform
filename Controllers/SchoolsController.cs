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
        public IActionResult Index(string name, int? page)
        {
            List<Skola> skole;
            // prosledjivanje name parametra za pretragu u View radi njegovog pamcenja u formi. 
            ViewBag.name = name;

            // dodeljivanje podrazumevanih vrednosi ako su parametri null
            if (page == null) page = 1;
            int pageSize = 8;

            // popunjavanje liste sa skolama i popunjavanje promenjive za cuvanje ukupnog broja skola prema zadatim parametrima
            int schoolCount;
            (skole, schoolCount) = _schoolServices.GetSchools(name, (int)page, pageSize);

            // odredjivanje maksimalnog broja stranica
            double maxPages = schoolCount / (double)pageSize;
            maxPages = Math.Ceiling(maxPages);

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
