using HospitalManagement.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagement.DataAccess
{
    public class HospitalContext : DbContext
    {
        public DbSet<Doctor> Doctors { get; set; }
        
        public DbSet<Patient> Patients { get; set; }
        
        public DbSet<Appointment> Appointments { get; set; }
        
        public DbSet<Speciality> Specialities { get; set; }
        
        public DbSet<PatientBlank> PatientBlanks { get; set; }

        public HospitalContext(DbContextOptions options) : base(options) 
        {
        
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appointment>(builder =>
            {
                builder.HasKey(a => a.AppointmentId);

                builder.HasOne(a => a.Patient)
                    .WithMany(a => a.Appointments);

                builder.HasOne(a => a.Doctor)
                    .WithMany(a => a.Appointments);
            });

            modelBuilder.Entity<Doctor>(builder =>
            {
                builder.HasKey(d => d.DoctorId);

                builder.HasOne(d => d.Speciality)
                    .WithMany(s => s.Doctors);
            });

            modelBuilder.Entity<Patient>(builder =>
            {
                builder.HasKey(p => p.PatientId);
            });

            modelBuilder.Entity<PatientBlank>(builder =>
            {
                builder.HasKey(r => r.PatientBlankId);

                builder.HasOne(r => r.Patient)
                    .WithOne(r => r.PatientBlank)
                    .HasForeignKey<PatientBlank>(r => r.PatientId);
            });

            modelBuilder.Entity<Speciality>(builder =>
            {
                builder.HasKey(r => r.SpecialityId);
            });
        }
    }
}
