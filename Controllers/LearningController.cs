using eLearning.Interfaces;
using eLearning.Models;
using eLearning.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
            //if (User.Identity.IsAuthenticated)
            //{
            //    string Id = HttpContext.User.Claims.First(c => c.Type == "KorisnikID").Value;
            //    Korisnik korisnik = _korisnikServices.Find(Id);
            //    ViewBag.korisnik = korisnik;
            //}
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

            string role = "Korisnik";
            if (korisnik.tip == 2)
                role = "Admin";

            List<Claim> userClaims = new()
            {
                new Claim("KorisnikID", korisnik.userID),
                new Claim("username", korisnik.korisnickoIme),
                new Claim(ClaimTypes.Role, role),
            };

            var userIdentity = new ClaimsIdentity(userClaims, "User Identity");
            var userPrincipal = new ClaimsPrincipal(new[] { userIdentity });

            HttpContext.SignInAsync(userPrincipal, new AuthenticationProperties
            {
                IsPersistent = korisnikVM.remember,
                ExpiresUtc = DateTime.Now.AddHours(1)
            });

            // dodavanje auth cookie
            return RedirectToAction("Index");
        }

        [Authorize]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
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
