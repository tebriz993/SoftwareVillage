using System.ComponentModel.DataAnnotations;

namespace SoftwareVillage.Models
{
    public class Missiyamız
    {
        [Required]
        public int Id { get; set; }
        public string? Icon { get; set; }

        public string Title { get; set; }
        public string Subtitle { get; set; }

        public string? Controller_Name { get; set; }
        public string? View_Name { get; set; }


    }
}
