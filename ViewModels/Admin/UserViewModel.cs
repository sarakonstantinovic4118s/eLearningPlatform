using eLearning.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eLearning.ViewModels.Admin
{
    public class UserViewModel
    {
        //KORISNICI
        public List<Korisnik> korisnici { get; set; }

        [DisplayName("User name")]
        [Required]
        public string username { get; set; }

        [DisplayName("Password")]
        [Required]
        public string password { get; set; }

        [DisplayName("Email")]
        [Required]
        public string email { get; set; }

        public string tip { get; set; }
    }
}
