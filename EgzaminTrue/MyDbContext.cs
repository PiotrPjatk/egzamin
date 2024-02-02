using EgzaminTrue.Models;
using Microsoft.EntityFrameworkCore;

namespace EgzaminTrue;

public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<Medicament> Medications { get; set; }
        public DbSet<Prescription_Medicament> Prescription_Medications { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuring the relationships
            modelBuilder.Entity<Prescription>()
                .HasOne(p => p.Patient)
                .WithMany(b => b.Prescriptions)
                .HasForeignKey(p => p.IdPatient);

            modelBuilder.Entity<Prescription>()
                .HasOne(p => p.Doctor)
                .WithMany(d => d.Prescriptions)
                .HasForeignKey(p => p.IdDoctor);

            modelBuilder.Entity<Prescription_Medicament>()
                .HasKey(pm => new { pm.IdMedicament, pm.IdPrescription });

            modelBuilder.Entity<Prescription_Medicament>()
                .HasOne(pm => pm.Prescription)
                .WithMany(p => p.Prescription_Medicament)
                .HasForeignKey(pm => pm.IdPrescription);

            modelBuilder.Entity<Prescription_Medicament>()
                .HasOne(pm => pm.Medicament)
                .WithMany(m => m.Prescription_Medicament)
                .HasForeignKey(pm => pm.IdMedicament);

            // Seed data for Doctor
            modelBuilder.Entity<Doctor>().HasData(
                new Doctor { IdDoctor = 1, FirstName = "John", LastName = "Doe", Email = "johndoe@example.com" },
                new Doctor { IdDoctor = 2, FirstName = "Jane", LastName = "Smith", Email = "janesmith@example.com" }
            );

            // Seed data for Patient
            modelBuilder.Entity<Patient>().HasData(
                new Patient { IdPatient = 1, FirstName = "Michael", LastName = "Johnson", Birthdate = new DateTime(1985, 4, 12) },
                new Patient { IdPatient = 2, FirstName = "Linda", LastName = "Brown", Birthdate = new DateTime(1992, 8, 23) }
            );

            // Seed data for Medication
            modelBuilder.Entity<Medicament>().HasData(
                new Medicament { IdMedicament = 1, Name = "Medication A", Description = "Description A", Type = "Type A" },
                new Medicament { IdMedicament = 2, Name = "Medication B", Description = "Description B", Type = "Type B" }
            );

            // Seed data for Prescription
            modelBuilder.Entity<Prescription>().HasData(
                new Prescription { IdPrescription = 1, Date = DateTime.Now, DueDate = DateTime.Now.AddDays(30), IdPatient = 1, IdDoctor = 1 },
                new Prescription { IdPrescription = 2, Date = DateTime.Now, DueDate = DateTime.Now.AddDays(30), IdPatient = 2, IdDoctor = 2 }
            );

            // Seed data for Prescription_Medication
            modelBuilder.Entity<Prescription_Medicament>().HasData(
                new Prescription_Medicament { IdMedicament = 1, IdPrescription = 1, Dose = 1, Details = "Take once daily" },
                new Prescription_Medicament { IdMedicament = 2, IdPrescription = 2, Dose = 2, Details = "Take twice daily" }
            );
        }
    }