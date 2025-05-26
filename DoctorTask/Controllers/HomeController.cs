using System.Diagnostics;
using DoctorTask.DataAccess;
using DoctorTask.Models;
using Microsoft.AspNetCore.Mvc;

namespace DoctorTask.Controllers
{
    public class HomeController : Controller
    {

        private readonly ApplicationDbContext _db;
        public HomeController(ApplicationDbContext db)
        {
            _db = db;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Booking()
        {
            var DoctorsList = _db.doctors.ToList();

            return View(DoctorsList);

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
