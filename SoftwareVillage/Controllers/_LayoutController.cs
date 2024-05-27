using Microsoft.AspNetCore.Mvc;
using SoftwareVillage.Data;
using SoftwareVillage.ViewModels;
using System.Linq;

namespace SoftwareVillage.Controllers
{
    public class _LayoutController : Controller
    {
        private readonly SoftwareVillageDbContext _context;

        public _LayoutController(SoftwareVillageDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var layouts = _context.layout_Services.FirstOrDefault();
            var layout_VM = new Layout_VM
            {
                layout_Service = layouts
            };
            return View(layout_VM);
        }

    }
}
