using System.ComponentModel.DataAnnotations;

namespace ClinicAppointmentMVC.Models
{
    public class Patient
    {
        public int PatientID { get; set; }

        [Required]
        public string Name { get; set; } = "";

        [Required]
        public string Surname { get; set; } = "";

        [Required]
        [EmailAddress]
        public string Email { get; set; } = "";

        [Required]
        public string Phone { get; set; } = "";

        [Required]
        public string Password { get; set; } = "";

        public ICollection<Appointment> Appointments { get; set; }
            = new List<Appointment>();
    }
}