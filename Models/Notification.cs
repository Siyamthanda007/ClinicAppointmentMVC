namespace ClinicAppointmentMVC.Models
{
    public class Notification
    {
        public int NotificationID { get; set; }

        public int PatientID { get; set; }

        public string Message { get; set; } = "";

        public DateTime DateSent { get; set; }

        public string Status { get; set; } = "Unread";
    }
}