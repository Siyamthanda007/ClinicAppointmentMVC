using ClinicAppointmentMVC.Models;

namespace ClinicAppointmentMVC.ViewModels
{
    public class DoctorDashboardViewModel
    {
        public Doctor? Doctor { get; set; }

        public int PendingAppointments { get; set; }

        public int ConfirmedAppointments { get; set; }

        public int CompletedAppointments { get; set; }

        public int CancelledAppointments { get; set; }

        public List<Appointment> Appointments { get; set; }
            = new List<Appointment>();
    }
}