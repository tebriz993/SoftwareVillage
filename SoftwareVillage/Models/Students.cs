using System.ComponentModel.DataAnnotations;

namespace SoftwareVillage.Models
{
    public class Students
    {
        [Required]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Phone { get; set; }
        public int AdditionPhone { get; set; }

        List<StudentsOfBootcamps> StudentsOfBootcamps { get; set; }


        public double Payment { get; set; }
        public string Time { get; set; }

        List<StudentsOfAkademiyaTeachers> StudentsOfTeachers { get; set; }

        public Students()
        {
            
        }

    }
}
