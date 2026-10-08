using ClinicAppointmentMVC.Data;
using ClinicAppointmentMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClinicAppointmentMVC.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ClinicDbContext _context;

        public DashboardController(ClinicDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var patientId = HttpContext.Session.GetInt32("PatientID");

            if (patientId == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var patient = _context.Patients
                .FirstOrDefault(p => p.PatientID == patientId);

            if (patient == null)
            {
                HttpContext.Session.Clear();

                return RedirectToAction("Login", "Account");
            }

            var today = DateTime.Today;

            var upcoming = _context.Appointments
                .Where(a =>
                    a.PatientID == patientId &&
                    a.AppointmentDate >= today &&
                    a.Status != "Cancelled")
                .Count();

            var completed = _context.Appointments
                .Where(a =>
                    a.PatientID == patientId &&
                    a.Status == "Completed")
                .Count();

            var cancelled = _context.Appointments
                .Where(a =>
                    a.PatientID == patientId &&
                    a.Status == "Cancelled")
                .Count();

            var nextAppointment = _context.Appointments
                .Include(a => a.Doctor)
                .Include(a => a.Service)
                .Where(a =>
                    a.PatientID == patientId &&
                    a.AppointmentDate >= today &&
                    a.Status != "Cancelled")
                .OrderBy(a => a.AppointmentDate)
                .ThenBy(a => a.AppointmentTime)
                .FirstOrDefault();

            var model = new DashboardViewModel
            {
                Patient = patient,

                UpcomingAppointments = upcoming,

                CompletedAppointments = completed,

                CancelledAppointments = cancelled,

                NextAppointment = nextAppointment
            };

            return View(model);
        }
    }
}