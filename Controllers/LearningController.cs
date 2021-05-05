using eLearning.Interfaces;
using eLearning.Models;
using eLearning.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
            if (User.Identity.IsAuthenticated)
            {
                string Id = HttpContext.User.Claims.First(c => c.Type == "KorisnikID").Value;
                Korisnik korisnik = _korisnikServices.Find(Id);
                ViewBag.korisnik = korisnik;
            }
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

        [HttpGet]
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


        /*
        // primer
        [Authorize]
        public IActionResult Protected()
        {
            ViewBag.ime = HttpContext.User.Claims.First(c => c.Type == "KorisnikID").Value;
            return View();
        }

        [Authorize(Policy = "Admin")]
        public IActionResult Admin()
        {
            return RedirectToAction("Protected");
        }
        */

        /*public IActionResult Authenticate()
        {

            List<Claim> userClaims = new()
            {
                new Claim("KorisnikID", "608ecb4f441e47bbb09e03d9"),
                new Claim("username", "Stefan"),
                new Claim(ClaimTypes.Role, "Admin"),
            };
            
            var userIdentity = new ClaimsIdentity(userClaims, "User Identity");
            var userPrincipal = new ClaimsPrincipal(new[] { userIdentity });

            HttpContext.SignInAsync(userPrincipal);

            return RedirectToAction("Index");
        }*/
    }
}
