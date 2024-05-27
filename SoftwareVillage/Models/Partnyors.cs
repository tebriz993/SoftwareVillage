using System.ComponentModel.DataAnnotations.Schema;

namespace SoftwareVillage.Models
{
    public class Partnyors
    {
        public int Id { get; set; }
        public string? Image { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }
    }
}
