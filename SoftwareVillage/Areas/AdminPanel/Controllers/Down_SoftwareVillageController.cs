using SoftwareVillage.Data;
using Microsoft.AspNetCore.Mvc;
using SoftwareVillage.Models;
using Microsoft.EntityFrameworkCore;

namespace SoftwareVillage.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class Down_SoftwareVillageController : Controller
    {
        public readonly SoftwareVillageDbContext _context;
        public Down_SoftwareVillageController(SoftwareVillageDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Down_SoftwareVillage> down_SoftwareVillages = _context.Down_SoftwareVillages.ToList();
            return View(down_SoftwareVillages);
        }



        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Down_SoftwareVillage down_SoftwareVillage)
        {
            if (!ModelState.IsValid) return View();

            bool result = await _context.Down_SoftwareVillages.AnyAsync(p => p.Title1.Trim().ToLower() == down_SoftwareVillage.Title1.Trim().ToLower());

            if (result)
            {
                ModelState.AddModelError("Blogtitle", "Eyni adda Kurs artiq movcuddur...");
                return View();
            }
            await _context.Down_SoftwareVillages.AddAsync(down_SoftwareVillage);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }






        public async Task<IActionResult> Update(int Id)
        {
            if (Id == null || Id < 1)
            {
                return BadRequest();
            }

            Down_SoftwareVillage old = await _context.Down_SoftwareVillages.FirstOrDefaultAsync(o => o.Id == Id);
            if (old == null)
            {
                return NotFound();
            }

            return View(old);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int Id, Down_SoftwareVillage down_SoftwareVillage)
        {
            if (Id == null || Id < 1)
            {
                return BadRequest();
            }

            Down_SoftwareVillage old = await _context.Down_SoftwareVillages.FirstOrDefaultAsync(o => o.Id == Id);

            if (old == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View();
            }

            if (old.Icon1 == down_SoftwareVillage.Icon1 && old.Title1 == down_SoftwareVillage.Title1 && old.Icon2 == down_SoftwareVillage.Icon2 && old.Title2 == down_SoftwareVillage.Title2 && old.Icon3 == down_SoftwareVillage.Icon3 && old.Title3==down_SoftwareVillage.Title3)
            {

                return RedirectToAction(nameof(Index));

            }

            bool result = await _context.Down_SoftwareVillages.AnyAsync(p => p.Title1.Trim().ToLower() == down_SoftwareVillage.Title1.Trim().ToLower() && p.Id != old.Id);
            if (result)
            {
                ModelState.AddModelError("BlogTitle", "Bu adda basligi artiq var");
                return View(old);
            }

            old.Icon1 = down_SoftwareVillage.Icon1;
            old.Title1 = down_SoftwareVillage.Title1;

            old.Icon2 = down_SoftwareVillage.Icon2;
            old.Title2 = down_SoftwareVillage.Title2;

            old.Icon3 = down_SoftwareVillage.Icon3;
            old.Title3 = down_SoftwareVillage.Title3;





            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }




        public async Task<IActionResult> Delete(int? Id)
        {
            if (Id == null || Id < 1)
            {
                return BadRequest();
            }
            Down_SoftwareVillage down_SoftwareVillage = await _context.Down_SoftwareVillages.FirstOrDefaultAsync(o => o.Id == Id);
            if (down_SoftwareVillage == null) NotFound();

            _context.Down_SoftwareVillages.Remove(down_SoftwareVillage);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }


    }
}
