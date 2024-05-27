using Microsoft.AspNetCore.Mvc;
using SoftwareVillage.Data;
using SoftwareVillage.ViewModels;
using System.Linq;

namespace SoftwareVillage.Controllers
{
    public class KurslarDesignController : Controller
    {
        private readonly SoftwareVillageDbContext _context;

        public KurslarDesignController(SoftwareVillageDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {

            var carouselDesign = _context.carousel_Designs.ToList();
            var design = _context.designs.ToList();


            var design_VM = new Design_VM
            {

                Carousel_Designs = carouselDesign,
                Designs = design
            };

            return View(design_VM);
        }
    }
}
