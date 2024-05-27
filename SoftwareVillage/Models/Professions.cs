using System.ComponentModel.DataAnnotations;

namespace SoftwareVillage.Models
{
    public class Professions
    {
        [Required]
        public int Id { get; set; }
        public string Name { get; set; }
        List<AkademiyaTeachers>? akademiyaTeachers { get; set; }
    }
}
