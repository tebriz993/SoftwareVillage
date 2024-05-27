using System.ComponentModel.DataAnnotations;

namespace SoftwareVillage.Models
{
    public class Relation
    {
        [Required]
        public int Id { get; set; }
        public string Number_Title { get; set; }
        public string Number { get; set; }

        public string Email_Title { get; set; }
        public string Email { get; set; }

        public string Address_Title { get; set; }
        public string Address { get; set; }
    }
}
