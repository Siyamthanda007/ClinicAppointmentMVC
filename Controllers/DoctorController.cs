using ClinicAppointmentMVC.Data;
using ClinicAppointmentMVC.Models;
using ClinicAppointmentMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClinicAppointmentMVC.Controllers
{
    public class DoctorController : Controller
    {
        private readonly ClinicDbContext _context;

        public DoctorController(ClinicDbContext context)
        {
            _context = context;
        }


        // =========================================
        // DOCTOR DASHBOARD
        // =========================================

        public IActionResult Dashboard()
        {
            var doctorId =
                HttpContext.Session.GetInt32("DoctorID");

            if (doctorId == null)
            {
                return RedirectToAction(
                    "Login",
                    "Account");
            }


            var doctor = _context.Doctors
                .FirstOrDefault(d =>
                    d.DoctorID == doctorId);


            if (doctor == null)
            {
                return NotFound();
            }


            var appointments = _context.Appointments

                .Include(a => a.Patient)

                .Include(a => a.Service)

                .Where(a =>
                    a.DoctorID == doctorId)

                .OrderBy(a =>
                    a.AppointmentDate)

                .ThenBy(a =>
                    a.AppointmentTime)

                .ToList();


            var model = new DoctorDashboardViewModel
            {
                Doctor = doctor,

                PendingAppointments =
                    appointments.Count(a =>
                        a.Status == "Pending"),

                ConfirmedAppointments =
                    appointments.Count(a =>
                        a.Status == "Confirmed"),

                CompletedAppointments =
                    appointments.Count(a =>
                        a.Status == "Completed"),

                CancelledAppointments =
                    appointments.Count(a =>
                        a.Status == "Cancelled"),

                Appointments = appointments
            };


            return View(model);
        }


        // =========================================
        // UPDATE APPOINTMENT STATUS
        // =========================================

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateStatus(
            int id,
            string status)
        {
            var doctorId =
                HttpContext.Session.GetInt32("DoctorID");

            if (doctorId == null)
            {
                return RedirectToAction(
                    "Login",
                    "Account");
            }


            var appointment =
                _context.Appointments

                .FirstOrDefault(a =>
                    a.AppointmentID == id &&
                    a.DoctorID == doctorId);


            if (appointment == null)
            {
                return NotFound();
            }


            // Only allow valid statuses

            var validStatuses = new[]
            {
                "Pending",
                "Confirmed",
                "Completed",
                "Cancelled"
            };


            if (!validStatuses.Contains(status))
            {
                TempData["Error"] =
                    "Invalid appointment status.";

                return RedirectToAction("Dashboard");
            }


            appointment.Status = status;

            _context.SaveChanges();


            TempData["Success"] =
                $"Appointment status updated to {status}.";


            return RedirectToAction("Dashboard");
        }
    }
}