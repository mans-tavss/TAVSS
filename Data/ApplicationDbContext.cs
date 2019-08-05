using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TAVSS.Models;

namespace TAVSS.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<IdentityRole>().HasData(
                new { Id = "1", Name = "Admin" , NormalizedName="ADMIN" },
                new { Id = "2", Name = "Guest", NormalizedName = "GUEST" },
                new { Id = "3", Name = "Doctor", NormalizedName = "DOCTOR" },
                new { Id = "4", Name = "Student", NormalizedName = "STUDENT" },
                new { Id = "5", Name = "TA", NormalizedName = "TA" }

                );
            //Fluent API for Relations
            builder.Entity<StudentGroupModel>()
                   .HasKey(sg => new { sg.SId, sg.GId });

            builder.Entity<CourseTAModel>()
                .HasKey(CT => new { CT.CId, CT.TId });

        }

        public DbSet<StudentModel> Students { get; set; }
        public DbSet<DoctorModel> Doctors { get; set; }
        public DbSet<ProjectModel> Projects { get; set; }
        public DbSet<GroupModel> Groups { get; set; }
        public DbSet<TAModel> TAs { get; set; }
        public DbSet<CourseModel> Courses { get; set; }

    }
}
