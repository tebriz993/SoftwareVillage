using SoftwareVillage.Data;
using Microsoft.AspNetCore.Mvc;
using SoftwareVillage.Models;
using Microsoft.EntityFrameworkCore;

namespace SoftwareVillage.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class VizyonController : Controller
    {
        public readonly SoftwareVillageDbContext _context;
        public VizyonController(SoftwareVillageDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Missiyamız> missiyamız = _context.Missiyamız.ToList();
            return View(missiyamız);
        }



        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Missiyamız missiyamiz)
        {
            if (!ModelState.IsValid) return View();

            bool result = await _context.Missiyamız.AnyAsync(p => p.Title.Trim().ToLower() == missiyamiz.Title.Trim().ToLower());

            if (result)
            {
                ModelState.AddModelError("Blogtitle", "Eyni adda Kurs artiq movcuddur...");
                return View();
            }
            await _context.Missiyamız.AddAsync(missiyamiz);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }






        public async Task<IActionResult> Update(int Id)
        {
            if (Id == null || Id < 1)
            {
                return BadRequest();
            }

            Missiyamız old = await _context.Missiyamız.FirstOrDefaultAsync(o => o.Id == Id);
            if (old == null)
            {
                return NotFound();
            }

            return View(old);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int Id, Missiyamız missiyamız)
        {
            if (Id == null || Id < 1)
            {
                return BadRequest();
            }

            Missiyamız old = await _context.Missiyamız.FirstOrDefaultAsync(o => o.Id == Id);

            if (old == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View();
            }

            if (old.Title == missiyamız.Title && old.Subtitle == missiyamız.Subtitle && old.Controller_Name == missiyamız.Controller_Name && old.View_Name == missiyamız.Controller_Name)
            {


                return RedirectToAction(nameof(Index));

            }

            bool result = await _context.Missiyamız.AnyAsync(p => p.Title.Trim().ToLower() == missiyamız.Title.Trim().ToLower() && p.Id != old.Id);
            if (result)
            {
                ModelState.AddModelError("BlogTitle", "Bu adda kurs basligi artiq var");
                return View(old);
            }

            old.Title = missiyamız.Title;
            old.Subtitle = missiyamız.Subtitle;
            old.Controller_Name = missiyamız.Controller_Name;
            old.View_Name = missiyamız.View_Name;
            
          

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }




        public async Task<IActionResult> Delete(int? Id)
        {
            if (Id == null || Id < 1)
            {
                return BadRequest();
            }
            Missiyamız missiyamiz = await _context.Missiyamız.FirstOrDefaultAsync(o => o.Id == Id);
            if (missiyamiz == null) NotFound();

            _context.Missiyamız.Remove(missiyamiz);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }


    }
}
