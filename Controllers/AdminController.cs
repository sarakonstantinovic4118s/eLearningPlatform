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
    public class AdminController : Controller
    {
        private readonly IKorisnikServices _korisnikServices;
        private readonly IKurseviServices _kurseviServices;
        private readonly IKategorijeServices _kategorijeServices;

        public AdminController(IKorisnikServices korisnikServices, IKurseviServices kurseviServices, IKategorijeServices kategorijeServices)
        {
            _korisnikServices = korisnikServices;
            _kurseviServices = kurseviServices;
            _kategorijeServices = kategorijeServices;
        }

        public IActionResult adminPanel()
        {
            List<Korisnik> listKorisnik = new List<Korisnik>();
            List<Kategorije> listKategorije = new List<Kategorije>();
            List<Kursevi> listKursevi = new List<Kursevi>();

            listKorisnik = _korisnikServices.Read();
            listKategorije = _kategorijeServices.Read();
            listKursevi = _kurseviServices.Read();

            var viewmodel = new AdminViewModel
            {
                korisnici = listKorisnik,
                kategorije = listKategorije,
                kursevi = listKursevi
            };

            return View(viewmodel);
        }

        //GET EDIT KURS
        [HttpGet]
        public IActionResult editCourse(string id)
        {
            var findKurs = _kurseviServices.Find(id);

            var viewmodel = new AdminViewModel
            {
                kursZaEdit = findKurs
            };
            return View(viewmodel);
        }
        //SET EDIT KURS
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult setEditCourse(Kursevi kurs)
        {
            _kurseviServices.UpdateCourse(kurs);
            return RedirectToAction("adminPanel");
        }

        //UPDATE VERZIJA 2
        //public IActionResult UpdateCourse(Kursevi kurs)
        //{
        //    return Ok(_kurseviServices.UpdateCourse(kurs));
        //}

        //DELETE COURSE
        [HttpGet]
        public IActionResult  DeleteCourse(string id)
        {
            _kurseviServices.DeleteCourse(id);
            return RedirectToAction("adminPanel");
        }


        //DODAVANJE NOVE KATEGORIJE SA ADMIN PANELA
        public IActionResult insertCategory(AdminViewModel categoryVM)
        {
            Kategorije kategorija = new()
            {
                imekategorije = categoryVM.imeKategorije
            };
            _kategorijeServices.Insert(kategorija);
            return RedirectToAction("adminPanel");
        }

        //DODVANJE NOVOG KURSA SA ADMIN PANELA
        public IActionResult isnertCourse(AdminViewModel kursVM)
        {

            Kursevi kurs = new()
            {
                imekursa = kursVM.imekursa,
                detaljikursa = kursVM.detaljikursa,
                link = kursVM.link,
                slika = kursVM.slika,
                nivoKursa = kursVM.nivoKursa,
                kategorijaID = kursVM.kategorijaID
            };
            _kurseviServices.Insert(kurs);
            return RedirectToAction("adminPanel");
        }

       // DODVANJE NOVOG KORISNIKA SA ADMIN PANELA
        public IActionResult insertKorisnik(AdminViewModel korisnikVM)
        {
            Korisnik k = new()
            {
                korisnickoIme = korisnikVM.username,
                email = korisnikVM.email,
                password = korisnikVM.password,
                tip = 1
            };
            _korisnikServices.Insert(k);
            return RedirectToAction("adminPanel");
        }
    }
}
