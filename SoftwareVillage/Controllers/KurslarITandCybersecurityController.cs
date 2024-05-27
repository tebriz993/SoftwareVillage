using Microsoft.AspNetCore.Mvc;
using SoftwareVillage.Data;
using SoftwareVillage.Models;
using SoftwareVillage.ViewModels;
using System.Linq;

namespace SoftwareVillage.Controllers
{
    public class KurslarITandCybersecurityController : Controller
    {
        private readonly SoftwareVillageDbContext _context;

        public KurslarITandCybersecurityController(SoftwareVillageDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {

            var carouselItAndCybersecurities = _context.carousel_ITAndCybersecurities.ToList();
            var itAndCybersecurities = _context.ITandCybersecurities.ToList();


            var itAndCybersecurity_VM = new ITAndCybersecurity_VM
            {

                Carousel_ITAndCybersecurities = carouselItAndCybersecurities,
                ItandCybersecurities = itAndCybersecurities
            };

            return View(itAndCybersecurity_VM);
        }
    }
}
