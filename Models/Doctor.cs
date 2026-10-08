using System.ComponentModel.DataAnnotations;

namespace ClinicAppointmentMVC.Models
{
    public class Doctor
    {
        public int DoctorID { get; set; }

        [Required]
        public string Name { get; set; } = "";

        [Required]
        public string Surname { get; set; } = "";

        [Required]
        public string Specialisation { get; set; } = "";

        public string Phone { get; set; } = "";

        [EmailAddress]
        public string Email { get; set; } = "";

        [Required]
        public string Password { get; set; } = "";

        public ICollection<Appointment> Appointments { get; set; }
            = new List<Appointment>();

        public ICollection<Schedule> Schedules { get; set; }
            = new List<Schedule>();
    }
}