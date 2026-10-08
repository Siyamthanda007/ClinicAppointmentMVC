using System.ComponentModel.DataAnnotations;

namespace ClinicAppointmentMVC.Models
{
    public class Service
    {
        public int ServiceID { get; set; }

        [Required]
        public string ServiceName { get; set; } = "";

        public string Description { get; set; } = "";

        public ICollection<Appointment> Appointments { get; set; }
            = new List<Appointment>();
    }
}