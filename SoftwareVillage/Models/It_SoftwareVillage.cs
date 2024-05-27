using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoftwareVillage.Models
{
    public class It_SoftwareVillage
    {
        [Required]
        public int Id { get; set; }
        public string? Image { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }

        public string LittleTitle { get; set; }
        public string BigTitle { get; set; }
    }
}
