namespace ClinicAppointmentMVC.Models
{
    public class Schedule
    {
        public int ScheduleID { get; set; }

        public int DoctorID { get; set; }

        public DateTime AvailableDate { get; set; }

        public TimeSpan StartTime { get; set; }

        public TimeSpan EndTime { get; set; }

        public Doctor? Doctor { get; set; }
    }
}