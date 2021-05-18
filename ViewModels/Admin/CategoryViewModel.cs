using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eLearning.ViewModels.Admin
{
    public class CategoryViewModel
    {
        [Required]
        public string naziv { get; set; }
    }
}
