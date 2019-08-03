using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TAVSS.Models
{
    public class ProjectModel
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string PName { get; set; }

        [MaxLength(1000)]
        public string Repos { get; set; }

        public GroupModel Group { get; set; }



    }
}
