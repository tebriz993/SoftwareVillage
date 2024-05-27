using SoftwareVillage.Data;
using Microsoft.AspNetCore.Mvc;
using SoftwareVillage.Models;
using Microsoft.EntityFrameworkCore;

namespace SoftwareVillage.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class DesignController : Controller
    {
        public readonly SoftwareVillageDbContext _context;
        public DesignController(SoftwareVillageDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Design> design = _context.designs.ToList();
            return View(design);
        }



        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]  
        public async Task<IActionResult> Create(Design design)
        {
            if (!ModelState.IsValid) return View();

            bool result = await _context.designs.AnyAsync(p => p.BlogTitle.Trim().ToLower() == design.BlogTitle.Trim().ToLower());

            if (result)
            {
                ModelState.AddModelError("Blogtitle", "Eyni adda Kurs artiq movcuddur...");
                return View();
            }
            await _context.designs.AddAsync(design);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }






        public async Task<IActionResult> Update(int Id)
        {
            if (Id == null || Id < 1)
            {
                return BadRequest();
            }

            Design old = await _context.designs.FirstOrDefaultAsync(o => o.Id == Id);
            if (old == null)
            {
                return NotFound();
            }

            return View(old);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int Id, Design design)
        {
            if (Id == null || Id < 1)
            {
                return BadRequest();
            }

            Design old = await _context.designs.FirstOrDefaultAsync(o => o.Id == Id);

            if (old == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View();
            }

            if (old.BlogTitle == design.BlogTitle && old.BlogSubtitle == design.BlogSubtitle && old.SignOfMoney == design.SignOfMoney && old.Payment == design.Payment && old.Time == design.Time && old.Description1 == design.Description1 && old.Description2 == design.Description2 && old.Description3 == design.Description3 && old.Description4 == design.Description4 && old.Description5 == design.Description5)
            {
               
                return RedirectToAction(nameof(Index));

            }

            bool result = await _context.designs.AnyAsync(p => p.BlogTitle.Trim().ToLower() == design.BlogTitle.Trim().ToLower() && p.Id != old.Id);
            if (result)
            {
                ModelState.AddModelError("BlogTitle", "Bu adda kurs basligi artiq var");
                return View(old);
            }

            old.BlogTitle = design.BlogTitle;
            old.BlogSubtitle = design.BlogSubtitle;
            old.SignOfMoney = design.SignOfMoney;
            old.Payment = design.Payment;
            old.Time = design.Time;
            old.Description1 = design.Description1;
            old.Description2 = design.Description2;
            old.Description3 = design.Description3;
            old.Description4 = design.Description4;
            old.Description5 = design.Description5;

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }




        public async Task<IActionResult> Delete(int? Id)
        {
            if (Id == null || Id < 1)
            {
                return BadRequest();
            }
            Design design = await _context.designs.FirstOrDefaultAsync(o => o.Id == Id);
            if (design == null) NotFound();

            _context.designs.Remove(design);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }


    }
    public class BootcampsController
    {

    }
}
