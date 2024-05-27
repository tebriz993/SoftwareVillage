using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoftwareVillage.Data;
using SoftwareVillage.Models;
using System.Collections.Generic;
using System.Linq;

namespace SoftwareVillage.Controllers
{
    public class KaryeranıQur_UğurluTələbələrimizController : Controller
    {
        private readonly SoftwareVillageDbContext _context;
        public KaryeranıQur_UğurluTələbələrimizController(SoftwareVillageDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<StudentFeedbacks> studentFeedbacks = _context.studentsFeedbacks
                .Include(b => b.Bootcamp)
                .ToList();
            return View(studentFeedbacks);
        }
    }
}
