using System.Diagnostics;
using DoctorTask.DataAccess;
using DoctorTask.Entity;
using DoctorTask.Models;
using DoctorTask.ModelView;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using X.PagedList.Extensions;
namespace DoctorTask.Controllers
{
    public class HomeController : Controller
    {

        private readonly ApplicationDbContext _db;
        public HomeController(ApplicationDbContext db)
        {
            _db = db;
        }


        public IActionResult Index(AppointmentUserMV AppointmentData)
        {
            return View(AppointmentData);
        }
        public IActionResult GetAvailableDates(int docId)
        {
                

            return Json(new { success = true  ,  d = docId });
        }

        public IActionResult Booking(BookingMV BookingMV , int page = 1)
        {
            var DoctorsList = _db.doctors.Include(d => d.dcotorSecialicationType).Where(d => d.Name.Contains(BookingMV.DoctorName ?? "")).ToList();
            
            if (BookingMV.specialicationId != 0)
            {
                DoctorsList = DoctorsList.Where(d => d.SpecializationId == BookingMV.specialicationId).ToList();
            }

            var DoctorsListView = DoctorsList.ToPagedList(page, 3);

            BookingMV bookingMV = new BookingMV() { 
            Doctors = DoctorsListView,
            DoctorName = BookingMV.DoctorName,
            specialicationId = BookingMV.specialicationId,
            DoctorSpec = _db.dcotorSecialicationTypes.Select(d => new SelectListItem{Value = d.Id.ToString(),Text = d.Name}).ToList()
            };

            ViewBag.PageCount = DoctorsListView.PageCount;
            ViewBag.CurrentPage = page;
            return View(bookingMV);

        }



        [HttpGet]
       public IActionResult BookAppointment(int DoctorId = 0)
        {

        var AppointmentData = new AppointmentUserMV();
            var Doctor = new Doctor();

            if(_db.doctors.Any(d => d.Id == DoctorId))
            {
                Doctor = _db.doctors.FirstOrDefault(d => DoctorId == d.Id);
                AppointmentData.DoctorId = DoctorId;
                AppointmentData.DoctorName = Doctor?.Name ?? "";

            } else
            {
                return NotFound("not found");
            }
                return View(AppointmentData);
        }

        [HttpPost]
        public IActionResult BookAppointment(AppointmentUserMV AppointmentData)
        {
            if(!ModelState.IsValid)
            {
                return View(AppointmentData);
            }
            string dateTimeString = $"{AppointmentData.Date} {AppointmentData.Time}";


            
            DateTime appointmentDateTime = DateTime.Parse(dateTimeString);

            bool IsDateExist = _db.appointments.Include(d => d.Doctor).Any(d => d.AppointmentDateTime == appointmentDateTime && d.Doctor.Id == AppointmentData.DoctorId);

            if(!IsDateExist)
            {
            AppointmentData.DateConfirmed = true;
                User User = new User()
                {
                    Name = AppointmentData.UserName
                };

                _db.Users.Add(User);
                _db.SaveChanges();

                Appointment UserDate = new Appointment()
                {
                    UserId = User.Id,
                    DoctorId = AppointmentData.DoctorId,
                    AppointmentDateTime = appointmentDateTime
                };
                _db.appointments.Add(UserDate);
                _db.SaveChanges();
            } else
            {
             AppointmentData.DateConfirmed = false;
             TempData["DateTaken"] = "This date is already taken!";

                DateTime userDate = DateTime.Parse(AppointmentData.Date);
                
                DateTime startTime = userDate.Date.AddHours(10);  
                DateTime endTime = userDate.Date.AddHours(17);    
                List<DateTime> timeSlots = new List<DateTime>();
                while (startTime < endTime)
                {
                    timeSlots.Add(startTime);
                    startTime = startTime.AddMinutes(30);
                }
                List<DateTime> Appointments = _db.appointments.Where(a => a.Doctor.Id == AppointmentData.DoctorId).Select(a => a.AppointmentDateTime).ToList();

                List<DateTime> AvailableDates = timeSlots.Where(slot => !Appointments.Any(app => app.TimeOfDay == slot.TimeOfDay)).ToList();

                AppointmentData.AvailableDates.AddRange(AvailableDates);

            }

                return View(AppointmentData);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }



    }
}
