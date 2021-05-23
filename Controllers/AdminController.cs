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
using eLearning.ViewModels.Admin;
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

        public object CourseViewModel { get; private set; }

        public AdminController(IKorisnikServices korisnikServices, IKurseviServices kurseviServices,
                                IKategorijeServices kategorijeServices, ISchoolServices schoolServices)
        {
            _korisnikServices = korisnikServices;
            _kurseviServices = kurseviServices;
            _kategorijeServices = kategorijeServices;
            _schoolServices = schoolServices;
        }

        public IActionResult Index()
        {
            return RedirectToAction("adminPanel");
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

            CourseViewModel courseViewModel = new();
            courseViewModel.kategorije = listKategorije;
            courseViewModel.skole = listSkole;

            List<CourseDetailsViewModel> list = new List<CourseDetailsViewModel>();

            foreach (var course in listKursevi)
            {
                CourseDetailsViewModel cd = new()
                {
                    kurs = course,
                    kategorija = _kategorijeServices.Find(course.kategorijaID),
                    skola = _schoolServices.Find(course.skolaID)
                };
                list.Add(cd);
            }

            var viewmodel = new AdminViewModel
            {
                korisnici = listKorisnik,
                kategorije = listKategorije,
                kursevi = list,
                skole = listSkole,
                courseViewModel = courseViewModel
            };

            ViewBag.adminViewModel = viewmodel;

            return View();
        }

        public ActionResult<Kategorije> editCategory(string id) => View(_kategorijeServices.Find(id));
        public ActionResult<Korisnik> editUser(string id) => View(_korisnikServices.FindID(id));


        //CREATE CATEGORY
        public IActionResult insertCategory(CategoryViewModel c)
        {
            if (!ModelState.IsValid)
                return View();

            Kategorije kategorija = new()
            {
                imekategorije = c.naziv
            };
            _kategorijeServices.Insert(kategorija);
            return RedirectToAction("adminPanel");
        }

        //SET EDIT CATEGORY
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SetEditCategory(Kategorije kategorija)
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
        public IActionResult isnertCourse(CourseViewModel c)
        {
            if (ModelState.IsValid)
            {
                Kursevi kurs = new()
                {
                    imekursa = c.imekursa,
                    detaljikursa = c.detaljikursa,
                    link = c.link,
                    slika = "no-image.jpg",
                    nivoKursa = (int)c.nivoKursa,
                    kategorijaID = c.kategorijaID,
                    skolaID = c.skolaID
                };

                var file = c.slika;
                if (file != null)
                {
                    kurs.slika = kurs.kursID + "-Original-" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".png";
                    var filePath = Directory.GetCurrentDirectory() + "/wwwroot/images/Kursevi";
                    if (Directory.Exists(filePath))
                    {
                        Directory.CreateDirectory(filePath);
                    }

                    var path = Path.Combine(filePath, kurs.slika);
                    FileStream fs = new FileStream(path, FileMode.Create);
                    file.CopyTo(fs);
                    fs.Close();
                }

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
        public IActionResult setEditCourse(Kursevi kurs)
        {
            var file = HttpContext.Request.Form.Files["slika2"];
            if (file != null)
            {
                kurs.slika = kurs.kursID + "-Update-" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".png";
                var filePath = Directory.GetCurrentDirectory() + "/wwwroot/images/Kursevi";
                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }
                var path = Path.Combine(filePath, kurs.slika);
                FileStream fs = new FileStream(path, FileMode.Create);
                file.CopyTo(fs);
                fs.Close();
            }
            _kurseviServices.UpdateCourse(kurs);
            return RedirectToAction("adminPanel", kurs);
        }

        //DELETE COURSE
        [HttpGet]
        public IActionResult DeleteCourse(string id)
        {
            _kurseviServices.DeleteCourse(id);
            return RedirectToAction("adminPanel");
        }

        // CREATE USER
        public IActionResult insertKorisnik(UserViewModel u)
        {
            Korisnik k = new()
            {
                korisnickoIme = u.username,
                email = u.email,
                password = Security.Hash256(u.password),
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
        public IActionResult insertSchool(SchoolViewModel s)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("adminPanel");

            Skola skola = new()
            {
                naziv = s.naziv,
                logo = "no-image.jpg"
            };

            var file = s.logo;
            if (file != null)
            {
                skola.logo = s.naziv + "-Original-" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".png";
                var filePath = Directory.GetCurrentDirectory() + "/wwwroot/images/Skole";
                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }

                var path = Path.Combine(filePath, skola.logo);
                FileStream fs = new FileStream(path, FileMode.Create);
                file.CopyTo(fs);
                fs.Close();
            }

            _schoolServices.Insert(skola);
            return RedirectToAction("adminPanel");
        }

        //UPDATE SCHOOL
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult setEditSChool(Skola skola)
        {
            var file = HttpContext.Request.Form.Files["logo2"];
            if (file != null)
            {
                skola.logo = skola.naziv + "-Update-" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".png";
                var filePath = Directory.GetCurrentDirectory() + "/wwwroot/images/Skole";
                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }
                var path = Path.Combine(filePath, skola.logo);
                FileStream fs = new FileStream(path, FileMode.Create);
                file.CopyTo(fs);
                fs.Close();
            }

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
