using DoctorTask.Entity;
using Microsoft.AspNetCore.Mvc.Rendering;
using X.PagedList;

namespace DoctorTask.ModelView
{
    public class BookingMV
    {
     public   IPagedList<Doctor>? Doctors { get; set; }

        public List<SelectListItem>? DoctorSpec { get; set; }
         public int specialicationId { get; set; }
        public  string? DoctorName { get; set; }

    }
}
