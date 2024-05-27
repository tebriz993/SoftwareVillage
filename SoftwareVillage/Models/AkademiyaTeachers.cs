using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoftwareVillage.Models
{
    public class AkademiyaTeachers
    {
        public int Id { get; set; }
        public string? Image { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }

        public int SocialMediaId { get; set; }
        public SocialMedias SocialMedia { get; set; }

        public string FullName { get; set; }

        public int ProfessionId { get; set; }
        public Professions Profession { get; set; }

        public List<StudentsOfAkademiyaTeachers> StudentsOfAkademiyaTeachers { get; set; }

        public AkademiyaTeachers()
        {
           StudentsOfAkademiyaTeachers = new List<StudentsOfAkademiyaTeachers>();
        }
    }
}
