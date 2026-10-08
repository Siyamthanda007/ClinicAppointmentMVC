using ClinicAppointmentMVC.Models;

namespace ClinicAppointmentMVC.ViewModels
{
    public class DashboardViewModel
    {
        public Patient? Patient { get; set; }

        public int UpcomingAppointments { get; set; }

        public int CompletedAppointments { get; set; }

        public int CancelledAppointments { get; set; }

        public Appointment? NextAppointment { get; set; }
    }
}