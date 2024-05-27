using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoftwareVillage.Models
{
    public class Niye_SoftwareVillage
    {
        [Required]
        public int Id { get; set; }
   
        public string Title1 { get; set; }
        public string Subtitle1 { get; set; }

        public string Title2 { get; set; }
        public string Subtitle2 { get; set; }

        public string? Image { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }

        public string Title3 { get; set; }
        public string Subtitle3 { get; set; }

        public string Title4 { get; set; }
        public string Subtitle4 { get; set; }
    }
}
