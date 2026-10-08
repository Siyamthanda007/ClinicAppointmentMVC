using ClinicAppointmentMVC.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ClinicAppointmentMVC.ViewModels
{
    public class AppointmentViewModel
    {
        public int DoctorID { get; set; }

        public int ServiceID { get; set; }

        public DateTime AppointmentDate { get; set; }

        public TimeSpan AppointmentTime { get; set; }

        public List<SelectListItem> Doctors { get; set; }
            = new List<SelectListItem>();

        public List<SelectListItem> Services { get; set; }
            = new List<SelectListItem>();

        public List<string> AvailableTimes { get; set; }
            = new List<string>();
    }
}