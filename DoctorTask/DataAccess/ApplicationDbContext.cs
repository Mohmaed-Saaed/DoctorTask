using DoctorTask.Entity;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace DoctorTask.DataAccess
{
    public class ApplicationDbContext :DbContext
    {

        public DbSet<Doctor> doctors{ get; set; }
        public DbSet<User> Users{ get; set; }
        public DbSet<Appointment> appointments{ get; set; }
        public DbSet<DcotorSecialicationType> dcotorSecialicationTypes{ get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Doctor>()
                .HasData(new Doctor { Id = 1, Name = "Dr. John Smith", SpecializationId = 1, Img = "doctor1.jpg" },
            new Doctor { Id = 2, Name = "Dr. Sarah Johnson", SpecializationId = 2, Img = "doctor2.jpg" },
            new Doctor { Id = 3, Name = "Dr. Emily Davis", SpecializationId = 3, Img = "doctor4.jpg" },
            new Doctor { Id = 4, Name = "Dr. Michael Lee", SpecializationId = 4, Img = "doctor3.jpg" },
            new Doctor { Id = 5, Name = "Dr. William Clark", SpecializationId = 5, Img = "doctor5.jpg" }
            );



            modelBuilder.Entity<DcotorSecialicationType>()
               .HasData(
                    new DcotorSecialicationType { Id = 1, Name = "Cardiology" },
                    new DcotorSecialicationType { Id = 2, Name = "Pediatrics" },
                    new DcotorSecialicationType { Id = 3, Name = "Dermatology" },
                    new DcotorSecialicationType { Id = 4, Name = "Orthopedics" },
                    new DcotorSecialicationType { Id = 5, Name = "Neurology" }
               ); 
        }

    }
}
