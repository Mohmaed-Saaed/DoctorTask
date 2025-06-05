using DoctorTask.Entity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using X.PagedList;

namespace DoctorTask.ModelView
{
    public class AppointmentUserMV
    {

       public string DoctorName { get; set; } = string.Empty;
        [Required ]
        [Display(Name = "User Name")]
        public string UserName { get; set; }
        [Required]
        public string Date { get; set; }
        [Required]
        public string Time { get; set; }

        public int DoctorId { get; set; }

        public bool DateConfirmed { get; set; }

        public List<DateTime>? AvailableDates { get; set; } = new List<DateTime>();

    }
}
