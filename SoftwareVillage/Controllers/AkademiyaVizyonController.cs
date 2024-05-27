using Microsoft.AspNetCore.Mvc;
using SoftwareVillage.Data;
using SoftwareVillage.Models;

namespace SoftwareVillage.Controllers
{
    public class AkademiyaVizyonController : Controller
    {
        private readonly SoftwareVillageDbContext _context;
        public AkademiyaVizyonController(SoftwareVillageDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Missiyamız> missiya=_context.Missiyamız.ToList();
            return View(missiya);
        }
    }
}
