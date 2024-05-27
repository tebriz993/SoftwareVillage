using Microsoft.AspNetCore.Mvc;
using SoftwareVillage.Data;
using SoftwareVillage.Models;

namespace SoftwareVillage.Controllers
{
    public class AkademiyaAboutUsController : Controller
    {
        private readonly SoftwareVillageDbContext _context;
        public AkademiyaAboutUsController(SoftwareVillageDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<AkademiyaAboutUs> akademiyaAboutUs= _context.akademiyaAboutUs.ToList();
            return View(akademiyaAboutUs);
        }
    }
}
