﻿using eLearning.Interfaces;
using eLearning.Models;
using eLearning.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eLearning.Controllers
{
    public class KurseviController : Controller
    {

        // instanciranje servisa (svih funkcija koje su navedene u IKorisnikServices i implementirane u KorisnikServices) za kontrolu korisnika
        private readonly IKurseviServices _kurseviServices;
        // 
        public KurseviController(IKurseviServices kurseviServices)
        {
            _kurseviServices = kurseviServices;
        }
        // GET: KurseviController
        public ActionResult Courses()
        {
            return View();
        }

        // GET: KurseviController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        
        
    }
}