using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TAVSS.Models
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "User Name")]
        public string Name { get; set; }



        [Required]
        [DataType(DataType.Password), MinLength(8), MaxLength(100)]
        public string Password { get; set; }
    }
}
