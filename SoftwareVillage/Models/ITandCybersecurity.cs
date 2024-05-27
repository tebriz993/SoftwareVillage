using System.ComponentModel.DataAnnotations;

namespace SoftwareVillage.Models
{
    public class ITandCybersecurity
    {
        [Required]
        public int Id { get; set; }

        public string BlogTitle { get; set; }
        public string BlogSubtitle { get; set; }
        public string SignOfMoney { get; set; }
        public double Payment { get; set; }
        public string Time { get; set; }

        public string Description1 { get; set; }
        public string Description2 { get; set; }
        public string Description3 { get; set; }
        public string Description4 { get; set; }
        public string Description5 { get; set; }
    }
}
