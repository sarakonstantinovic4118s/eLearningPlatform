using eLearning.Interfaces;
using eLearning.Models;
using eLearning.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using eLearning.Services;

namespace eLearning.Controllers
{
    [Authorize(Policy = "Admin")]
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

            //READ
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

        //GET EDIT KURS/KATEGORIJA/KORISNIK

        [HttpGet]
        public ActionResult<Kursevi> editCourse(string id, Kursevi kursevi)
        {
            var kod = kursevi;

            kod = _kurseviServices.Find(id);
            List<Kategorije> listKategorije = new List<Kategorije>();
            listKategorije = _kategorijeServices.Read();

            var viewmodel = new AdminViewModel
            {
                kurs = kod,
                kategorije = listKategorije
            };

            return View(viewmodel);
        }
        public ActionResult<Kategorije> editCategory(string id) => View(_kategorijeServices.Find(id));
        public ActionResult<Korisnik> editUser(string id) => View(_korisnikServices.FindID(id));

        //CREATE CATEGORY
        public IActionResult insertCategory(AdminViewModel categoryVM)
        {
            Kategorije kategorija = new()
            {
                imekategorije = categoryVM.imeKategorije
            };
            _kategorijeServices.Insert(kategorija);
            return RedirectToAction("adminPanel");
        }

        //SET EDIT CATEGORY
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult setEditCategory(Kategorije kategorija)
        {
            _kategorijeServices.UpdateCategory(kategorija);
            return RedirectToAction("adminPanel");
        }

        //DELETE CATEGORY
        public IActionResult DeleteCategory(string id)
        {
            _kategorijeServices.DeleteCategory(id);
            return RedirectToAction("adminPanel");
        }

        //CREATE COURSE
        public IActionResult isnertCourse(AdminViewModel kursVM)
        {

            Kursevi kurs = new()
            {
                imekursa = kursVM.imekursa,
                detaljikursa = kursVM.detaljikursa,
                link = kursVM.link,
                slika = kursVM.slika,
                nivoKursa = (int)kursVM.nivoKursa,
                kategorijaID = kursVM.kategorijaID
            };
            _kurseviServices.Insert(kurs);
            return RedirectToAction("adminPanel");
        }

        //SET EDIT COURSE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult setEditCourse(Kursevi kurs, string id)
        {
            List<Kategorije> listKategorije = new List<Kategorije>();
            listKategorije = _kategorijeServices.Read();

            var kurs1 = _kurseviServices.Find(id);

            var viewmodel = new AdminViewModel
            {
               kategorije = listKategorije,
               kursZaEdit = kurs1
            };

            _kurseviServices.UpdateCourse(kurs);
            return RedirectToAction("adminPanel",viewmodel);
        }

        //DELETE COURSE
        [HttpGet]
        public IActionResult DeleteCourse(string id)
        {
            _kurseviServices.DeleteCourse(id);
            return RedirectToAction("adminPanel");
        }


        // CREATE USER
        public IActionResult insertKorisnik(AdminViewModel korisnikVM)
        {
            Korisnik k = new()
            {
                korisnickoIme = korisnikVM.username,
                email = korisnikVM.email,
                password = Security.Hash256(korisnikVM.password),
                tip = 1
            };
            _korisnikServices.Insert(k);
            return RedirectToAction("adminPanel");
        }

        //SET EDIT USER
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult setEditUser(Korisnik korisnik)
        {
            korisnik.password = Security.Hash256(korisnik.password);
            _korisnikServices.UpdateUser(korisnik);
            return RedirectToAction("adminPanel");
        }

        //DELETE USER
        public IActionResult DeleteUser(string id)
        {
            _korisnikServices.DeleteUser(id);
            return RedirectToAction("adminPanel");
        }

    }
}
