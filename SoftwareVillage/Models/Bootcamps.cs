namespace SoftwareVillage.Models
{
    public class Bootcamps
    {
        public int Id { get; set; }
        public string Name { get; set; }
        List<StudentsOfBootcamps> StudentsOfBootcamps { get; set; }
        List<StudentFeedbacks> StudentFeedbacks { get; set;}
        public Bootcamps()
        {
            
        }
    }
}
