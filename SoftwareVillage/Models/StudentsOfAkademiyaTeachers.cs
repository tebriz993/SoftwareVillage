using System.ComponentModel.DataAnnotations;

namespace SoftwareVillage.Models
{
    public class StudentsOfAkademiyaTeachers
    {
        [Required]
        public int Id { get; set; }

        public int TeacherId { get; set; }
        public AkademiyaTeachers Teachers { get; set; }


        public int StudentId { get; set; }
        public Students Students { get; set; }

        public StudentsOfAkademiyaTeachers()
        {
            
        }
    }
}
