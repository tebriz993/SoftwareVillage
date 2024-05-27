using Microsoft.AspNetCore.Mvc;
using SoftwareVillage.Data;
using SoftwareVillage.Models;
using SoftwareVillage.ViewModels;
using System;
using System.Linq;

namespace SoftwareVillage.Controllers
{
    public class KurslarDataScienceController : Controller
    {
        private readonly SoftwareVillageDbContext _context;

        public KurslarDataScienceController(SoftwareVillageDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
           

            

            // Modeli oluştur
            var carouselAndDataScience = new DataScience_VM
            {
                Carousel_DataSciences = _context.carousel_DataSciences.ToList(),
                DataSciences = _context.dataSciences.ToList()



                
            };

          

            return View(carouselAndDataScience);
        }
    }
}
