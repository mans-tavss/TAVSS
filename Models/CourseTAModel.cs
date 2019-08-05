using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TAVSS.Models
{
    public class CourseTAModel
    {
        [Key]
        [Required]
        public int CId { get; set; }

        [Key]
        [Required]
        public int TId { get; set; }


        // Relationships

        public CourseModel Course { get; set; }
        public TAModel TA { get; set; }
    }
}
