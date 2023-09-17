using HospitalManagementSystem.Identity;
using HospitalManagementSystem.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementSystem.AppDbContext
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }

        public DbSet<Gender> Genders { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<PatientType> PatientTypes { get; set; }
       
        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Gender>().HasData(new Gender()
            {
                Id = 1,
                Sex = "Female"
            },
            new Gender()
            {
                Id = 2,
                Sex = "Male"
            }
            );
        }
*/
    }

    
}
