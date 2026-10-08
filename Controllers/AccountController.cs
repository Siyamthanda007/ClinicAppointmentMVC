using ClinicAppointmentMVC.Data;
using ClinicAppointmentMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClinicAppointmentMVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly ClinicDbContext _context;

        public AccountController(ClinicDbContext context)
        {
            _context = context;
        }

        // GET: /Account/Login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // POST: /Account/Login
        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            if (string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(password))
            {
                ViewBag.Error =
                    "Please enter your email and password.";

                return View();
            }

            // Check Patient
            var patient = _context.Patients
                .FirstOrDefault(p =>
                    p.Email == email &&
                    p.Password == password);

            if (patient != null)
            {
                HttpContext.Session.SetInt32(
                    "PatientID",
                    patient.PatientID);

                HttpContext.Session.SetString(
                    "PatientName",
                    patient.Name);

                return RedirectToAction(
                    "Index",
                    "Dashboard");
            }

            // Check Doctor / Clinic
            var doctor = _context.Doctors
                .FirstOrDefault(d =>
                    d.Email == email &&
                    d.Password == password);

            if (doctor != null)
            {
                HttpContext.Session.SetInt32(
                    "DoctorID",
                    doctor.DoctorID);

                HttpContext.Session.SetString(
                    "DoctorName",
                    doctor.Name + " " + doctor.Surname);

                return RedirectToAction(
                    "Dashboard",
                    "Doctor");
            }

            ViewBag.Error =
                "Invalid email or password.";

            return View();
        }

        // GET: /Account/Register
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }


        // GET: /Account/PatientRegister
        [HttpGet]
        public IActionResult PatientRegister()
        {
            return View();
        }


        // POST: /Account/PatientRegister
        [HttpPost]
        public IActionResult PatientRegister(Patient patient)
        {
            if (!ModelState.IsValid)
            {
                return View(patient);
            }

            var existingPatient = _context.Patients
                .FirstOrDefault(p => p.Email == patient.Email);

            if (existingPatient != null)
            {
                ModelState.AddModelError(
                    "Email",
                    "This email is already registered.");

                return View(patient);
            }

            _context.Patients.Add(patient);

            _context.SaveChanges();

            TempData["Success"] =
                "Your patient account has been created successfully.";

            return RedirectToAction("Login");
        }

        // GET: /Account/DoctorRegister
        [HttpGet]
        public IActionResult DoctorRegister()
        {
            return View();
        }


        // POST: /Account/DoctorRegister
        [HttpPost]
        public IActionResult DoctorRegister(Doctor doctor)
        {
            if (!ModelState.IsValid)
            {
                return View(doctor);
            }

            var existingDoctor = _context.Doctors
                .FirstOrDefault(d => d.Email == doctor.Email);

            if (existingDoctor != null)
            {
                ModelState.AddModelError(
                    "Email",
                    "This doctor/clinic email is already registered.");

                return View(doctor);
            }

            _context.Doctors.Add(doctor);

            _context.SaveChanges();

            TempData["Success"] =
                "Doctor / Clinic account created successfully.";

            return RedirectToAction("Login");
        }

        // Logout
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();

            return RedirectToAction(
                "Login",
                "Account");
        }
    }
}