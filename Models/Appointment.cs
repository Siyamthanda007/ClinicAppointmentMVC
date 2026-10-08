using System.ComponentModel.DataAnnotations;

namespace ClinicAppointmentMVC.Models
{
    public class Appointment
    {
        public int AppointmentID { get; set; }

        [Required]
        public int PatientID { get; set; }

        [Required]
        public int DoctorID { get; set; }

        [Required]
        public int ServiceID { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime AppointmentDate { get; set; }

        [Required]
        public TimeSpan AppointmentTime { get; set; }

        public string Status { get; set; } = "Pending";

        public Patient? Patient { get; set; }

        public Doctor? Doctor { get; set; }

        public Service? Service { get; set; }
    }
}