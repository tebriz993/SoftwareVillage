using System.ComponentModel.DataAnnotations;

namespace SoftwareVillage.Models
{
    public class StudentsOfBootcamps
    {
        [Required]
        public int Id { get; set; }

        public int BootcampId { get; set; }
        public Bootcamps Bootcamp { get; set; }

        public int StudentId { get; set; }
        public Students Students { get; set; }


    }
}
