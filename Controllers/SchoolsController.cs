using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eLearning.Controllers
{
    public class SchoolsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
