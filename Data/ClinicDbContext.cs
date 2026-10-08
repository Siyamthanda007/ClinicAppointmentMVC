using ClinicAppointmentMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicAppointmentMVC.Data
{
    public class ClinicDbContext : DbContext
    {
        public ClinicDbContext(
            DbContextOptions<ClinicDbContext> options)
            : base(options)
        {
        }

        public DbSet<Patient> Patients { get; set; }

        public DbSet<Doctor> Doctors { get; set; }

        public DbSet<Appointment> Appointments { get; set; }

        public DbSet<Service> Services { get; set; }

        public DbSet<Schedule> Schedules { get; set; }

        public DbSet<Notification> Notifications { get; set; }

        protected override void OnModelCreating(
            ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Appointment relationships

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Patient)
                .WithMany(p => p.Appointments)
                .HasForeignKey(a => a.PatientID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Doctor)
                .WithMany(d => d.Appointments)
                .HasForeignKey(a => a.DoctorID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Service)
                .WithMany(s => s.Appointments)
                .HasForeignKey(a => a.ServiceID)
                .OnDelete(DeleteBehavior.Restrict);


            // SAMPLE SERVICES

            modelBuilder.Entity<Service>().HasData(

                
            );
        }
    }
}