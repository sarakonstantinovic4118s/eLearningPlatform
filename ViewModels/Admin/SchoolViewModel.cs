using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eLearning.ViewModels.Admin
{
    public class SchoolViewModel
    {
        [Required]
        public string naziv{ get; set; }

        public IFormFile logo { get; set; }
        public string nazivSkole { get; set; }
    }
}
