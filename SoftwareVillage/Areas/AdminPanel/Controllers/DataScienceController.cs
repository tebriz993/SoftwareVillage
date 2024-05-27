using SoftwareVillage.Data;
using Microsoft.AspNetCore.Mvc;
using SoftwareVillage.Models;
using Microsoft.EntityFrameworkCore;
using SoftwareVillage.ViewModels;

namespace SoftwareVillage.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class DataScienceController : Controller
    {
        public readonly SoftwareVillageDbContext _context;
        public DataScienceController(SoftwareVillageDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<DataScience> dataScience = _context.dataSciences.ToList();
            return View(dataScience);
            
        }



        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(DataScience dataScience)
        {
            if (!ModelState.IsValid) return View();

            //bool result = await _context.dataSciences.AnyAsync(p => p.BlogTitle.Trim().ToLower() == dataScience.BlogTitle.Trim().ToLower());

            //if (result)
            //{
            //    ModelState.AddModelError("Blogtitle", "Eyni adda Kurs artiq movcuddur...");
            //    return View();
            //}

            await _context.dataSciences.AddAsync(dataScience);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }






        public async Task<IActionResult> Update(int Id)
        {
            if (Id == null || Id < 1)
            {
                return BadRequest();
            }

            DataScience old = await _context.dataSciences.FirstOrDefaultAsync(o => o.Id == Id);
            if (old == null)
            {
                return NotFound();
            }

            return View(old);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int Id, DataScience dataScience)
        {
            if (Id == null || Id < 1)
            {
                return BadRequest();
            }

            DataScience old = await _context.dataSciences.FirstOrDefaultAsync(o => o.Id == Id);

            if (old == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View();
            }

            //if (old.BlogTitle == dataScience.BlogTitle && old.BlogSubtitle == dataScience.BlogSubtitle && old.SignOfMoney == dataScience.SignOfMoney && old.Payment == dataScience.Payment && old.Time == dataScience.Time && old.Description1 == dataScience.Description1 && old.Description2 == dataScience.Description2 && old.Description3 == dataScience.Description3 && old.Description4 == dataScience.Description4 && old.Description5 == dataScience.Description5)
            //{

            //    ModelState.AddModelError("BlogTitle", "Eyni kurs artıq var");
            //    return RedirectToAction(nameof(Index));

            //}

            //bool result = await _context.dataSciences.AnyAsync(p => p.BlogTitle.Trim().ToLower() == dataScience.BlogTitle.Trim().ToLower() && p.Id != old.Id);
            //if (result)
            //{
            //    ModelState.AddModelError("BlogTitle", "Bu adda kurs basligi artiq var");
            //    return View(old);
            //}

            old.BlogTitle = dataScience.BlogTitle;
            old.BlogSubtitle = dataScience.BlogSubtitle;
            old.SignOfMoney = dataScience.SignOfMoney;
            old.Payment = dataScience.Payment;
            old.Time = dataScience.Time;
            old.Description1 = dataScience.Description1;
            old.Description2 = dataScience.Description2;
            old.Description3 = dataScience.Description3;
            old.Description4 = dataScience.Description4;
            old.Description5 = dataScience.Description5;

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }




        public async Task<IActionResult> Delete(int? Id)
        {
            if (Id == null || Id < 1)
            {
                return BadRequest();
            }
            DataScience dataScience = await _context.dataSciences.FirstOrDefaultAsync(o => o.Id == Id);
            if (dataScience == null) NotFound();

            _context.dataSciences.Remove(dataScience);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }


    }
}
