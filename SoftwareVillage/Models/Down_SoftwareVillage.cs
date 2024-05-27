using System.ComponentModel.DataAnnotations;
using SoftwareVillage.Models;


namespace SoftwareVillage.Models
{
    public class Down_SoftwareVillage
    {
        [Required]
        public int Id { get; set; }
        public string Icon1 { get; set; }
        public string Title1 { get; set; }
        public int MaxCountOfTeachers { get; set; }

        public string Icon2 { get; set; }
        public string Title2 { get; set; }
        public int MaxCountOfStudents { get; set; }

        public string Icon3 { get; set; }
        public string Title3 { get; set; }
        public int MaxCountOfPartnyors { get; set; }

    }
}
