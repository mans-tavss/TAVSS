using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TAVSS.Models
{
    public class StudentGroupModel
    {
 
        [Required]
        public int SId { get; set; }

        [Required]
        public int GId { get; set; }

        // Relationship
        public StudentModel Student { get; set; }
        public GroupModel Group { get; set; }
    }
}
