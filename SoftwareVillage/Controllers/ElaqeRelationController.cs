using Microsoft.AspNetCore.Mvc;
using SoftwareVillage.Data;
using SoftwareVillage.Models;

namespace SoftwareVillage.Controllers.Elaqe
{
    public class ElaqeRelationController : Controller
    {
        private readonly SoftwareVillageDbContext _context;
        public ElaqeRelationController(SoftwareVillageDbContext context)
        {
                _context = context;
        }
        public IActionResult Index()
        {
            List<Relation> relation =_context.relation.ToList();
            return View(relation);
        }
    }
}
