using SoftwareVillage.Data;
using Microsoft.AspNetCore.Mvc;
using SoftwareVillage.Models;
using Microsoft.EntityFrameworkCore;

namespace SoftwareVillage.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class ElaqeController : Controller
    {
        public readonly SoftwareVillageDbContext _context;
        public ElaqeController(SoftwareVillageDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Relation> relation = _context.relation.ToList();
            return View(relation);
        }



        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Relation relation)
        {
            if (!ModelState.IsValid) return View();

            bool result = await _context.relation.AnyAsync(p => p.Number_Title.Trim().ToLower() == relation.Number_Title.Trim().ToLower());

            if (result)
            {
                ModelState.AddModelError("Blogtitle", "Eyni adda Kurs artiq movcuddur...");
                return View();
            }
            await _context.relation.AddAsync(relation);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }






        public async Task<IActionResult> Update(int Id)
        {
            if (Id == null || Id < 1)
            {
                return BadRequest();
            }

            Relation old = await _context.relation.FirstOrDefaultAsync(o => o.Id == Id);
            if (old == null)
            {
                return NotFound();
            }

            return View(old);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int Id, Relation relation)
        {
            if (Id == null || Id < 1)
            {
                return BadRequest();
            }

            Relation old = await _context.relation.FirstOrDefaultAsync(o => o.Id == Id);

            if (old == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View();
            }

            if (old.Number_Title == relation.Number_Title && old.Number == relation.Number && old.Email_Title == relation.Email_Title && old.Email == relation.Email && old.Address_Title == relation.Address_Title && old.Address == relation.Address)
            {

                return RedirectToAction(nameof(Index));

            }

            bool result = await _context.relation.AnyAsync(p => p.Number_Title.Trim().ToLower() == relation.Number_Title.Trim().ToLower() && p.Id != old.Id);
            if (result)
            {
                ModelState.AddModelError("BlogTitle", "Bu adda basligi artiq var");
                return View(old);
            }

            old.Number_Title = relation.Number_Title;
            old.Number = relation.Number;
            old.Email_Title = relation.Email_Title;
            old.Email = relation.Email;
            old.Address_Title = relation.Address_Title;
            old.Address = relation.Address;




            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }




        public async Task<IActionResult> Delete(int? Id)
        {
            if (Id == null || Id < 1)
            {
                return BadRequest();
            }
            Relation relation = await _context.relation.FirstOrDefaultAsync(o => o.Id == Id);
            if (relation == null) NotFound();

            _context.relation.Remove(relation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }


    }
}
