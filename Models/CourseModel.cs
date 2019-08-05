using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TAVSS.Models
{
    public class CourseModel
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string CourseName { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Repos { get; set; } 

        // Relations
        [Required]
        public List<DoctorModel> Doctors { get; set; }
        

        public List<GroupModel> Groups { get; set; }

        public List<CourseTAModel> CTA { get; set; }


    }
}
