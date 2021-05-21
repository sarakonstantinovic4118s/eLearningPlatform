﻿using eLearning.Interfaces;
using eLearning.Models;
using eLearning.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using Microsoft.AspNetCore.Authorization;

namespace eLearning.Controllers
{
    [Authorize]
    public class KurseviController : Controller
    {

        // instanciranje servisa (svih funkcija koje su navedene u IKorisnikServices i implementirane u KorisnikServices) za kontrolu korisnika
        private readonly IKurseviServices _kurseviServices;
        private readonly IKategorijeServices _kategorijeServices;
        private readonly ISchoolServices _schoolServices;
        // 
        public KurseviController(IKurseviServices kurseviServices, IKategorijeServices kategorijeServices, ISchoolServices schoolServices)
        {
            _kurseviServices = kurseviServices;
            _kategorijeServices = kategorijeServices;
            _schoolServices = schoolServices;
        }

        // GET: KurseviController

        [HttpGet("/courses/{naziv?}")]
        public IActionResult Courses(string naziv, string search, int? level, int? page, string schoolID)
        {
            // search
            ViewBag.search = search;
            ViewBag.level = level;

            if (schoolID != null)
                ViewBag.school = _schoolServices.Find(schoolID);
            else
                ViewBag.school = null;

            List<Kursevi> listKurseva;
            List<Kategorije> listKategorija;

            string kategorijaID = null;
            if (naziv != null)
            {
                var kategorija = _kategorijeServices.FindByName(naziv);
                if (kategorija == null) return NotFound();
                kategorijaID = kategorija.kategorijaID;
            }

            if (page == null)
            {
                page = 1;
            }
            int pageSize = 6;
            ViewBag.page = page;

            if (level == null)
                level = 0; // svi nivoi

            int courseCount;
            (listKurseva, courseCount) = _kurseviServices.GetCourses(kategorijaID, search, (int)level, (int)page, pageSize, schoolID);


            double maxPages = (double)courseCount / pageSize;
            ViewBag.maxPages = (int)Math.Ceiling(maxPages);
            ViewBag.total = courseCount;

            listKategorija = _kategorijeServices.Read();

          
            var kursevi = new List<DetailsForCourseViewModel>();
            foreach (var item in listKurseva)
            {
                // skracivanje opisa kursa
                if (item.detaljikursa.Length > 50)
                    item.detaljikursa = item.detaljikursa.Substring(0, 50) + "...";

                kursevi.Add(new DetailsForCourseViewModel()
                {
                    kurs = item,
                    nivo = _kurseviServices.getLevel(item.nivoKursa)
                });
            }
            var viewmodel = new KursKategorijaViewModel
            {
                kategorijes = listKategorija,
                kursevis = kursevi,
            };
            ViewBag.kursevi = kursevi;
            return View(viewmodel);
        }
          

        [HttpGet]
        public ActionResult<Kursevi> CourseDetails(string id) {
            var findKurs = _kurseviServices.Find(id);
            var skola = _schoolServices.Find(findKurs.skolaID);
            var level = _kurseviServices.getLevel(findKurs.nivoKursa);

            ViewBag.level = level;
            ViewBag.skola = skola;
            return View(findKurs);
        }
    }
}
