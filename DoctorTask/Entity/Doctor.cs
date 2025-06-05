using System.ComponentModel.DataAnnotations.Schema;

namespace DoctorTask.Entity
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Img { get; set; }
        public int SpecializationId { get; set; }
        [ForeignKey(nameof(SpecializationId))]

        public DcotorSecialicationType dcotorSecialicationType { get; set; }

    }
}
