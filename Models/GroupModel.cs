using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TAVSS.Models
{
    public class GroupModel
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string GName { get; set; }
        public List<ProjectModel> Projects { get; set; }
        public List<StudentModel> Students { get; set; }
        public TAModel TA { get; set; }
    }
}
