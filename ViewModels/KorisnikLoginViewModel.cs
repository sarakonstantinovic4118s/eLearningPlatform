using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eLearning.ViewModels
{
    public class KorisnikLoginViewModel
    {
        [DisplayName("User name")]
        [Required]
        public string korisnickoIme { get; set; }

        [DisplayName("Password")]
        [DataType(DataType.Password)]
        [Required]
        public string password { get; set; }

        public bool remember { get; set; }
    }
}
