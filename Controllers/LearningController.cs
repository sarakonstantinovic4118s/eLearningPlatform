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
using System.Web.Helpers;

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

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public IActionResult Logovanje(KorisnikLoginViewModel korisnikVM)
        {
            Korisnik k = new()
            {
                korisnickoIme = korisnikVM.korisnickoIme,
                password = korisnikVM.password
            };
            if (ModelState.IsValid)
            {
                List<Korisnik> result = _korisnikServices.Read(k);

            }

                return RedirectToAction("Index");
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        public string hashPass(string password)
        {

            // generate a 128-bit salt using a secure PRNG
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            Console.WriteLine($"Salt: {Convert.ToBase64String(salt)}");

            // derive a 256-bit subkey (use HMACSHA1 with 10,000 iterations)
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));
            return hashed;
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public IActionResult Registracija(KorisnikRegViewModel korisnikVM)
        {
            
            Korisnik k = new()
            {
                korisnickoIme = korisnikVM.korisnickoIme,
                email = korisnikVM.email,
                password = Crypto.HashPassword(korisnikVM.password),
                tip = 1
            };
            _korisnikServices.Insert(k);
            return RedirectToAction("Index");
        }
    }
}
