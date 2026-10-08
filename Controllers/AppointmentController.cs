using ClinicAppointmentMVC.Data;
using ClinicAppointmentMVC.Models;
using ClinicAppointmentMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ClinicAppointmentMVC.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly ClinicDbContext _context;

        public AppointmentController(ClinicDbContext context)
        {
            _context = context;
        }


        // ==========================================
        // BOOK APPOINTMENT - GET
        // ==========================================

        [HttpGet]
        public IActionResult Book()
        {
            var patientId =
                HttpContext.Session.GetInt32("PatientID");

            if (patientId == null)
            {
                return RedirectToAction(
                    "Login",
                    "Account");
            }

            var model = CreateAppointmentViewModel();

            return View(model);
        }


        // ==========================================
        // BOOK APPOINTMENT - POST
        // ==========================================

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Book(
            AppointmentViewModel model)
        {
            var patientId =
                HttpContext.Session.GetInt32("PatientID");

            if (patientId == null)
            {
                return RedirectToAction(
                    "Login",
                    "Account");
            }


            // Check doctor

            var doctors = _context.Doctors
    .Select(d => new SelectListItem
    {
        Value = d.DoctorID.ToString(),
        Text = "Dr. " + d.Name + " " + d.Surname
    })
    .ToList();


            // Check service

            var service = _context.Services
                .FirstOrDefault(s =>
                    s.ServiceID == model.ServiceID);

            if (service == null)
            {
                ModelState.AddModelError(
                    "ServiceID",
                    "Please select a valid service.");
            }


            // Check date

            if (model.AppointmentDate.Date
                < DateTime.Today)
            {
                ModelState.AddModelError(
                    "AppointmentDate",
                    "Please select a future date.");
            }


            // Check time

            if (model.AppointmentTime
                == TimeSpan.Zero)
            {
                ModelState.AddModelError(
                    "AppointmentTime",
                    "Please select an appointment time.");
            }


            // ==========================================
            // DOUBLE BOOKING CHECK
            // ==========================================

            var alreadyBooked =
                _context.Appointments.Any(a =>
                    a.DoctorID == model.DoctorID &&
                    a.AppointmentDate.Date ==
                    model.AppointmentDate.Date &&
                    a.AppointmentTime ==
                    model.AppointmentTime &&
                    a.Status != "Cancelled");


            if (alreadyBooked)
            {
                ModelState.AddModelError(
                    "",
                    "This doctor is already booked for the selected date and time. Please choose another time.");
            }


            if (!ModelState.IsValid)
            {
                model = CreateAppointmentViewModel(model);

                return View(model);
            }


            // ==========================================
            // CREATE APPOINTMENT
            // ==========================================

            var appointment = new Appointment
            {
                PatientID = patientId.Value,

                DoctorID = model.DoctorID,

                ServiceID = model.ServiceID,

                AppointmentDate =
                    model.AppointmentDate.Date,

                AppointmentTime =
                    model.AppointmentTime,

                Status = "Pending"
            };


            _context.Appointments.Add(appointment);

            _context.SaveChanges();


            TempData["Success"] =
                "Your appointment has been booked successfully!";


            return RedirectToAction(
                "Index",
                "Appointment");
        }


        // ==========================================
        // MY APPOINTMENTS
        // ==========================================

        public IActionResult Index()
        {
            var patientId =
                HttpContext.Session.GetInt32("PatientID");

            if (patientId == null)
            {
                return RedirectToAction(
                    "Login",
                    "Account");
            }


            var appointments =
                _context.Appointments

                .Include(a => a.Doctor)

                .Include(a => a.Service)

                .Where(a =>
                    a.PatientID == patientId)

                .OrderBy(a =>
                    a.AppointmentDate)

                .ThenBy(a =>
                    a.AppointmentTime)

                .ToList();


            return View(appointments);
        }


        // ==========================================
        // CANCEL APPOINTMENT
        // ==========================================

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Cancel(int id)
        {
            var patientId =
                HttpContext.Session.GetInt32("PatientID");

            if (patientId == null)
            {
                return RedirectToAction(
                    "Login",
                    "Account");
            }


            var appointment =
                _context.Appointments.FirstOrDefault(a =>
                    a.AppointmentID == id &&
                    a.PatientID == patientId);


            if (appointment == null)
            {
                return NotFound();
            }


            appointment.Status = "Cancelled";

            _context.SaveChanges();


            TempData["Success"] =
                "Your appointment has been cancelled.";


            return RedirectToAction("Index");
        }


        // ==========================================
        // CREATE VIEW MODEL
        // ==========================================

        private AppointmentViewModel
            CreateAppointmentViewModel(
                AppointmentViewModel? existing = null)
        {
            var model = existing ??
                new AppointmentViewModel
                {
                    AppointmentDate =
                        DateTime.Today.AddDays(1)
                };


            model.Doctors =
                _context.Doctors

                .OrderBy(d => d.Surname)

                .Select(d => new SelectListItem
                {
                    Value =
                        d.DoctorID.ToString(),

                    Text =
                        $"Dr. {d.Name} {d.Surname} — {d.Specialisation}"
                })

                .ToList();


            model.Services =
                _context.Services

                .OrderBy(s => s.ServiceName)

                .Select(s => new SelectListItem
                {
                    Value =
                        s.ServiceID.ToString(),

                    Text =
                        s.ServiceName
                })

                .ToList();


            return model;
        }
    }
}