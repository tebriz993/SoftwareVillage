using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoftwareVillage.Data;
using SoftwareVillage.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SoftwareVillage.Controllers
{
    public class AkademiyaTeachersController : Controller
    {
        private readonly SoftwareVillageDbContext _context;
        public AkademiyaTeachersController(SoftwareVillageDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            List<AkademiyaTeachers> akademiyaTeachers = await _context.akademiyaTeachers
                .Include(t => t.SocialMedia)
                .Include(t => t.Profession)
                .ToListAsync();

            return View(akademiyaTeachers);
        }
    }
}
