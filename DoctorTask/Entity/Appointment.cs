using Microsoft.EntityFrameworkCore;

namespace DoctorTask.Entity
{

    public class Appointment
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public int  UserId { get; set; }
        public DateTime AppointmentDateTime { get; set; } 
        public Doctor? Doctor { get; set; }
        public User? User{ get; set; }

    }
}
