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
    public class LearningController : Controller
    {
        // instanciranje servisa (svih funkcija koje su navedene u IKorisnikServices i implementirane u KorisnikServices) za kontrolu korisnika
        private readonly IKorisnikServices _korisnikServices;
        // 
        public LearningController(IKorisnikServices korisnikServices)
        {
            _korisnikServices = korisnikServices;
        }

        // Pocetna stranica (login je na pocetnoj)
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Registracija()
        {
            // instanciranje modela koji se koristi u formi unutar View
            KorisnikRegViewModel korisnik = new();
            return View(korisnik);
        }

        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registracija(KorisnikRegViewModel korisnikVM)
        {
            Korisnik k = new()
            {
                korisnickoIme = korisnikVM.korisnickoIme,
                email = korisnikVM.email,
                password = korisnikVM.password,
                tip = 1
            };
            _korisnikServices.Insert(k);
            return RedirectToAction("Index");
        }
    }
}
