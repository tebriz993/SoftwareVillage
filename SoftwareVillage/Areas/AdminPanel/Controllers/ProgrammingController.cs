using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoftwareVillage.Data;
using SoftwareVillage.Models;
using SoftwareVillage.ViewModels;

namespace SoftwareVillage.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class ProgrammingController : Controller
    {
        public readonly SoftwareVillageDbContext _context;
        public ProgrammingController(SoftwareVillageDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Programming> programming = _context.programming.ToList();
            return View(programming);
        }



        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Programming programming)
        {
            if (!ModelState.IsValid) return View();

            bool result = await _context.programming.AnyAsync(p => p.BlogTitle.Trim().ToLower() == programming.BlogTitle.Trim().ToLower());
            //bool result1 = await _context.programming.AnyAsync(p => p.Description1.Trim().ToLower() == programming.Description1.Trim().ToLower());
            if (result)
            {
                ModelState.AddModelError("Blogtitle", "Eyni adda Kurs artiq movcuddur...");
                return View();
            }
            await _context.programming.AddAsync(programming);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }






        public async Task<IActionResult> Update(int Id)
        {
            if (Id == null || Id < 1)
            {
                return BadRequest();
            }

            Programming old = await _context.programming.FirstOrDefaultAsync(o => o.Id == Id);
            if (old == null)
            {
                return NotFound();
            }

            return View(old);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int Id, Programming programming)
        {
            if (Id == null || Id < 1)
            {
                return BadRequest();
            }

            Programming old = await _context.programming.FirstOrDefaultAsync(o => o.Id == Id);

            if (old == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View();
            }

            if (old.BlogTitle == programming.BlogTitle && old.BlogSubtitle==programming.BlogSubtitle && old.SignOfMoney == programming.SignOfMoney && old.Payment == programming.Payment && old.Time == programming.Time && old.Description1 == programming.Description1 && old.Description2 == programming.Description2 && old.Description3 == programming.Description3 && old.Description4 == programming.Description4 && old.Description5 == programming.Description5)
            {

               

                return RedirectToAction(nameof(Index));
                
            }

            bool result = await _context.programming.AnyAsync(p => p.BlogTitle.Trim().ToLower() == programming.BlogTitle.Trim().ToLower() && p.Id != old.Id);
            if (result)
            {
                ModelState.AddModelError("BlogTitle", "Bu adda kurs basligi artiq var");
                return View(old);
            }

            old.BlogTitle = programming.BlogTitle;
            old.BlogSubtitle = programming.BlogSubtitle;
            old.SignOfMoney = programming.SignOfMoney;
            old.Payment= programming.Payment;
            old.Time= programming.Time;
            old.Description1= programming.Description1;
            old.Description2= programming.Description2;
            old.Description3= programming.Description3;
            old.Description4= programming.Description4;
            old.Description5= programming.Description5;

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }




        public async Task<IActionResult> Delete(int? Id)
        {
            if (Id == null || Id < 1)
            {
                return BadRequest();
            }
            Programming programming = await _context.programming.FirstOrDefaultAsync(o => o.Id == Id);
            if (programming == null) NotFound();

            _context.programming.Remove(programming);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }


    }

}
