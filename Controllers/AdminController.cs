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
using Microsoft.AspNetCore.Http;
using System.IO;

namespace eLearning.Controllers
{
    [Authorize(Policy = "Admin")]
    public class AdminController : Controller
    {
        private readonly IKorisnikServices _korisnikServices;
        private readonly IKurseviServices _kurseviServices;
        private readonly IKategorijeServices _kategorijeServices;
        private readonly ISchoolServices _schoolServices;

        public AdminController(IKorisnikServices korisnikServices, IKurseviServices kurseviServices,
                                IKategorijeServices kategorijeServices, ISchoolServices schoolServices)
        {
            _korisnikServices = korisnikServices;
            _kurseviServices = kurseviServices;
            _kategorijeServices = kategorijeServices;
            _schoolServices = schoolServices;
        }

        //SEARCH READ (CATEGORY)
        public IActionResult searchReadCategory(string name)
        {
            List<Kategorije> kategorije;

            ViewBag.name = name;

            if (name != null)
            {
                kategorije = _kategorijeServices.searchReadCategory(name);
            }
            else
            {
                kategorije = _kategorijeServices.Read();
            }

            var viewmodel = new AdminViewModel
            {
                kategorije = kategorije
            };

            return View(viewmodel);
        }

        public IActionResult adminPanel()
        {
            List<Korisnik> listKorisnik = new List<Korisnik>();
            List<Kategorije> listKategorije = new List<Kategorije>();
            List<Kursevi> listKursevi = new List<Kursevi>();
            List<Skola> listSkole = new List<Skola>();

            //READ
            listKorisnik = _korisnikServices.Read();
            listKategorije = _kategorijeServices.Read();
            listKursevi = _kurseviServices.Read();
            listSkole = _schoolServices.Read();

            var viewmodel = new AdminViewModel
            {
                korisnici = listKorisnik,
                kategorije = listKategorije,
                kursevi = listKursevi,
                skole = listSkole
            };

            return View();
        }

        public ActionResult<Kategorije> editCategory(string id) => View(_kategorijeServices.Find(id));
        public ActionResult<Korisnik> editUser(string id) => View(_korisnikServices.FindID(id));


        //CREATE CATEGORY
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult insertCategory(AdminViewModel categoryVM)
        {
            if (ModelState.IsValid)
            {
                Kategorije kategorija = new()
                {
                    imekategorije = categoryVM.imeKategorije
                };
                _kategorijeServices.Insert(kategorija);
                return RedirectToAction("adminPanel");
            }
            //Zajebava view jer ti je sve na jednoj stranici proveri to
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult isnertCourse(AdminViewModel kursVM/*, IFormFile slika*/)
        {

            //if (slika != null)
            //{
            //    MemoryStream memoryStream = new MemoryStream();
            //    slika.OpenReadStream().CopyTo(memoryStream);
            //    kursVM.slika = Convert.ToBase64String(memoryStream.ToArray());
            //}
            //else
            //{
            //    kursVM.slika = "";
            //}

            if (ModelState.IsValid)
            {
                Kursevi kurs = new()
                {
                    imekursa = kursVM.imekursa,
                    detaljikursa = kursVM.detaljikursa,
                    link = kursVM.link,
                    slika = kursVM.slika,
                    nivoKursa = kursVM.nivoKursa,
                    kategorijaID = kursVM.kategorijaID,
                    skolaID = kursVM.skolaID
                };
                _kurseviServices.Insert(kurs);
                return RedirectToAction("adminPanel");

            }
            return RedirectToAction("adminPanel");
        }

        //GET EDIT KURS/KATEGORIJA/KORISNIK

        [HttpGet]
        public ActionResult<Kursevi> editCourse(string id, Kursevi kursevi)
        {
            var kod = kursevi;

            kod = _kurseviServices.Find(id);
            List<Kategorije> listKategorije = new List<Kategorije>();
            List<Skola> listSkole = new List<Skola>();

            listKategorije = _kategorijeServices.Read();
            listSkole = _schoolServices.Read();

            var viewmodel = new AdminViewModel
            {
                kurs = kod,
                kategorije = listKategorije,
                skole = listSkole
            };

            return View(viewmodel);
        }

        //SET EDIT COURSE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult setEditCourse(Kursevi kurs, string id)
        {

            _kurseviServices.UpdateCourse(kurs);
            return RedirectToAction("adminPanel",kurs);
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

        //GET SCHOOL ID
        public ActionResult<Korisnik> editSChool(string id) => View(_schoolServices.FindID(id));


        //CREATE Schooll
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult insertSchool(AdminViewModel kursVM)
        {
            if (ModelState.IsValid)
            {
                Skola skola = new()
                {
                    naziv = kursVM.naziv,
                    logo = kursVM.logo
                };
                _schoolServices.Insert(skola);
                return RedirectToAction("adminPanel");
            }
            return RedirectToAction("adminPanel");
        }

        //UPDATE SCHOOL
        //SET EDIT CATEGORY
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult setEditSChool(Skola skola)
        {
            _schoolServices.UpdateSchool(skola);
            return RedirectToAction("adminPanel");
        }


        //DELETE SCHOOL
        public IActionResult DeleteSchool(string id)
        {
            _schoolServices.DeleteSchool(id);
            return RedirectToAction("adminPanel");
        }

    }
}
