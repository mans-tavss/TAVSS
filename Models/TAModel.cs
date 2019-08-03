using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TAVSS.Models.Attributes;

namespace TAVSS.Models
{
    public class TAModel
    {

 

        [Required]
        [Display(Name = "Teaching Assistant Name")]
        public string TAname { get; set; }

        [Required]
        [DataType(DataType.Password), MinLength(8), MaxLength(100)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [StringRange(AllowableValues = new[] { "M", "F" }, ErrorMessage = "Gender must be either 'M' or 'F'.")]
        public string Gender { get; set; }

        [MaxLength(600)]
        public string Pic { get; set; }



    }
}
