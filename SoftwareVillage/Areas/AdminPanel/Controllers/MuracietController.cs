using SoftwareVillage.Data;
using Microsoft.AspNetCore.Mvc;
using SoftwareVillage.Models;
using Microsoft.EntityFrameworkCore;

namespace SoftwareVillage.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class MuracietController : Controller
    {
        public readonly SoftwareVillageDbContext _context;
        public MuracietController(SoftwareVillageDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Muraciet> muraciet = _context.muracietler.ToList();
            return View(muraciet);
        }



        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Muraciet muraciet)
        {
            if (!ModelState.IsValid) return View();

            bool result = await _context.muracietler.AnyAsync(p => p.Bigtitle.Trim().ToLower() == muraciet.Bigtitle.Trim().ToLower());

            if (result)
            {
                ModelState.AddModelError("Blogtitle", "Eyni adda Kurs artiq movcuddur...");
                return View();
            }
            await _context.muracietler.AddAsync(muraciet);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }






        public async Task<IActionResult> Update(int Id)
        {
            if (Id == null || Id < 1)
            {
                return BadRequest();
            }

            Muraciet old = await _context.muracietler.FirstOrDefaultAsync(o => o.Id == Id);
            if (old == null)
            {
                return NotFound();
            }

            return View(old);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int Id, Muraciet muraciet)
        {
            if (Id == null || Id < 1)
            {
                return BadRequest();
            }

            Muraciet old = await _context.muracietler.FirstOrDefaultAsync(o => o.Id == Id);

            if (old == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View();
            }

            if (old.Bigtitle == muraciet.Bigtitle && old.Smalltitle1 == muraciet.Smalltitle1 && old.Smalltitle2 == muraciet.Smalltitle2 && old.Subtitle == muraciet.Subtitle && old.Smalltitle3 == muraciet.Smalltitle3 )
            {


                return RedirectToAction(nameof(Index));

            }

            bool result = await _context.muracietler.AnyAsync(p => p.Bigtitle.Trim().ToLower() == muraciet.Bigtitle.Trim().ToLower() && p.Id != old.Id);
            if (result)
            {
                ModelState.AddModelError("BlogTitle", "Bu adda basligi artiq var");
                return View(old);
            }

            old.Bigtitle = muraciet.Bigtitle;
            old.Smalltitle1 = muraciet.Smalltitle1;
            old.Smalltitle2 = muraciet.Smalltitle2;
            old.Subtitle = muraciet.Subtitle;
            old.Smalltitle3 = muraciet.Smalltitle3;




            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }




        public async Task<IActionResult> Delete(int? Id)
        {
            if (Id == null || Id < 1)
            {
                return BadRequest();
            }
            Muraciet muraciet = await _context.muracietler.FirstOrDefaultAsync(o => o.Id == Id);
            if (muraciet == null) NotFound();

            _context.muracietler.Remove(muraciet);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }


    }
}
