using System.ComponentModel.DataAnnotations;

namespace DoctorTask.Entity
{
    public class User
    {

        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;
    }
}
