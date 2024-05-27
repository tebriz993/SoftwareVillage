using System.ComponentModel.DataAnnotations;

namespace SoftwareVillage.Models
{
    public class Muraciet
    {
        public int Id { get; set; }
        public string Bigtitle { get; set; }
        
        public string? Icon1 { get; set; }
        public string Smalltitle1 { get; set; }
        public string? Icon2 { get; set; }
        public string Smalltitle2 { get; set; }
        public string Subtitle { get; set; }
        public string? Icon3 { get; set; }
        public string Smalltitle3 { get; set; }
        public string Number { get; set; }
    }
}
