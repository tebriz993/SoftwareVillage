using Microsoft.AspNetCore.Mvc;
using SoftwareVillage.Data;
using SoftwareVillage.ViewModels;
using System.Linq;
using SoftwareVillage.Models;

namespace SoftwareVillage.Controllers
{
    public class KurslarProgrammingController : Controller
    {
        private readonly SoftwareVillageDbContext _context;

        public KurslarProgrammingController(SoftwareVillageDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {

            var carouselProgramming = _context.carouselProgrammings.ToList();
            var programming = _context.programming.ToList();


            var programming_VM = new Programming_VM
            {

                CarouselProgrammings = carouselProgramming,
                Programmings = programming
            };

            return View(programming_VM);
        }
    }
}
