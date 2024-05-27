namespace SoftwareVillage.Models
{
    public class SocialMedias
    {
        public int Id { get; set; }
        public string TwitterLink { get; set; }
        public string FacebookLink { get; set; }
        public string InstagramLink { get; set; }
        public string LinkedlnLink { get; set; }

        List<AkademiyaTeachers>? akademiyaTeachers { get; set; }

        public SocialMedias()
        {
            
        }

    }
}
