﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eLearning.ViewModels.Admin
{
    public class SchoolViewModel
    {
        [Required]
        public string nazivSkole { get; set; }

        public string logoSkole { get; set; }
    }
}
