using Microsoft.AspNetCore.Mvc;
using SoftwareVillage.Data;
using SoftwareVillage.Models;

namespace SoftwareVillage.Controllers
{
    public class AkademiyaNiye_Software_VillageController : Controller
    {
        private readonly SoftwareVillageDbContext _context;
        public AkademiyaNiye_Software_VillageController(SoftwareVillageDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Niye_SoftwareVillage> niye_SoftwareVillage=_context.niye_SoftwareVillage.ToList();
            return View(niye_SoftwareVillage);
        }
    }
}
