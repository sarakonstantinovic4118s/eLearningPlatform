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
        public string korisnickoIme { get; set; }

        [DisplayName("Password")]
        [DataType(DataType.Password)]
        public string password { get; set; }
    }
}
