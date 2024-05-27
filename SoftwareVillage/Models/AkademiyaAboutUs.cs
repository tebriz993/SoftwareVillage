using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoftwareVillage.Models
{
    public class AkademiyaAboutUs
    {
        [Required]
        public int Id { get; set; }
        
        public string AboutUs { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }

        public string Special1 { get; set; }
        public string Special2 { get; set; }
        public string Special3 { get; set; }
        public string Special4 { get; set; }

        
        [NotMapped]
        public IFormFile Photo { get; set; }
        public string? MyImage { get; set; }

    }
}
