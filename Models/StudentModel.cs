using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TAVSS.Models.Attributes;

namespace TAVSS.Models
{
    public class StudentModel
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Student Name")]
        public string SName { get; set; }


        [Required]
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [StringRange(AllowableValues = new[] { "M", "F" }, ErrorMessage = "Gender must be either 'M' or 'F'.")]
        public string Gender { get; set; }

        // Relationship
        public List<StudentGroupModel> SGroup { get; set; }
    }
}
