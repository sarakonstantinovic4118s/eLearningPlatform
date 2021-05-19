using eLearning.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eLearning.ViewModels.Admin
{
    public class CourseDetailsViewModel
    {
        public Kursevi kurs { get; set; }
        public Kategorije kategorija { get; set; }
        public Skola skola { get; set; }
    }
}
