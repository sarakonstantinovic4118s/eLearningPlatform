using eLearning.Interfaces;
using eLearning.Models;
using eLearning.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using eLearning.Services;

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

        // Pocetna stranica
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Registracija()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public IActionResult Login(KorisnikLoginViewModel korisnikVM)
        {
            if (!ModelState.IsValid)
                return View(korisnikVM);

            Korisnik korisnik = _korisnikServices.Find(korisnikVM.korisnickoIme);

            if (korisnik == null || korisnik.password != Security.Hash256(korisnikVM.password))
            {
                // poruka o neuspesnoj prijavi
                ModelState.AddModelError(string.Empty, "Invalid login attempt");
                return View(korisnikVM);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public IActionResult Registracija(KorisnikRegViewModel korisnikVM)
        {
            // provera da li je korisnik vec registrovan

            Korisnik k = new()
            {
                korisnickoIme = korisnikVM.korisnickoIme,
                email = korisnikVM.email,
                password = Security.Hash256(korisnikVM.password),
                tip = 1
            };
            _korisnikServices.Insert(k);
            return RedirectToAction("Index");
        }
    }
}
