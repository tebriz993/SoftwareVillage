using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoftwareVillage.Models
{
    public class StudentFeedbacks
    {
        [Required]
        public int Id { get; set; }
        public string? Image { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }

        public string FullName { get; set; }

        public int BootcampId { get; set; }
        public Bootcamps Bootcamp { get; set; }

        public string Feedbacks {  get; set; }

        public StudentFeedbacks()
        {

        }
    }
}
