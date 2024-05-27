
using SoftwareVillage.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace SoftwareVillage.Data
{
    public class SoftwareVillageDbContext:DbContext
    {
        public SoftwareVillageDbContext(DbContextOptions<SoftwareVillageDbContext> options) : base(options)
        {

        }

        public DbSet<Down_SoftwareVillage> Down_SoftwareVillages { get; set; }
        public DbSet<It_SoftwareVillage> it_SoftwareVillages { get; set; }
        public DbSet<AkademiyaAboutUs> akademiyaAboutUs { get; set; }
        public DbSet<AkademiyaTeachers> akademiyaTeachers { get; set; }
        public DbSet<Professions> professions { get; set; }
        public DbSet<SocialMedias> socialMediaOfTeachers { get; set; }
        public DbSet<Relation> relation { get; set; }
        public DbSet<DataScience> dataSciences { get; set; }
        public DbSet<Design> designs { get; set; }
        public DbSet<ITandCybersecurity> ITandCybersecurities { get; set; }
        public DbSet<Programming> programming { get; set; }
        public DbSet<Bootcamps> bootcamps { get; set; }
        public DbSet<Students> students { get; set; }
        public DbSet<StudentFeedbacks> studentsFeedbacks { get; set; }
        public DbSet<StudentsOfAkademiyaTeachers> studentsOfTeachers { get; set; }
        public DbSet<StudentsOfBootcamps> studentsOfBootcamps { get; set; }
        public DbSet<Niye_SoftwareVillage> niye_SoftwareVillage { get; set; }
        public DbSet<Missiyamız> Missiyamız { get; set; }
        public DbSet<Partnyors> Partnyors { get; set; }
        public DbSet<CarouselProgramming> carouselProgrammings { get; set; }
        public DbSet<Carousel_DataScience> carousel_DataSciences { get; set; }
        public DbSet<Carousel_Design> carousel_Designs { get; set; }
        public DbSet<Carousel_ITAndCybersecurity> carousel_ITAndCybersecurities { get; set; }
        public DbSet<Layout_Service> layout_Services { get; set; }
        public DbSet<Muraciet> muracietler { get; set; }



    }
}
