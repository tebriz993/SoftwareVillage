using Microsoft.AspNetCore.Mvc;
using SoftwareVillage.Data;
using SoftwareVillage.Models;

namespace SoftwareVillage.Controllers
{
    public class AkademiyaPartnyorlarController : Controller
    {
        private readonly SoftwareVillageDbContext _context;
        public AkademiyaPartnyorlarController(SoftwareVillageDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Partnyors>? partnyors = _context.Partnyors.ToList();
            return View(partnyors);
        }
    }
}
