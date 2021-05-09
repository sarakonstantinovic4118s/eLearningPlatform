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

       
      
        // GET: KurseviController

        public IActionResult Courses()
        {
            List<Kursevi> listKurseva = new List<Kursevi>();
            listKurseva = _kurseviServices.Read();

            List<Kategorije> listKategorija = new List<Kategorije>();
            listKategorija = _kategorijeServices.Read();

           var viewmodel = new KursKategorijaViewModel
            {
                kategorijes = listKategorija,
                kursevis = listKurseva
            };
           return View(viewmodel);
        }
          


        [HttpGet]

        public ActionResult<Kursevi> CourseDetails(string id) {
            var findKurs = _kurseviServices.Find(id);
           return View(findKurs);
        }
     
        public ActionResult<Kategorije> CategoryDetails(string id) {
            var findKategoriju = _kategorijeServices.Find(id);
            List<Kategorije> listKategorija = new List<Kategorije>();
            listKategorija = _kategorijeServices.Read();

            var viewmodel = new KursKategorijaViewModel
            {
                kategorijes = listKategorija,
               kategorijeSingle = findKategoriju,
           
            };
            // nalazi kurseve koji imaju odredjen id kategorije
            ViewBag.kursevi = _kurseviServices.findCourses(id);
            
            return View(viewmodel);
        }

        // search
        //[HttpGet("{firstName}/{lastName}/{address}")]
        //public string GetQuery(string id, string firstName, string lastName, string address)
        //{
        //    return $"{firstName}:{lastName}:{address}";
        //}











    }
}
