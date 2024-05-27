using SoftwareVillage.Data;
using Microsoft.AspNetCore.Mvc;
using SoftwareVillage.Models;
using Microsoft.EntityFrameworkCore;
using SoftwareVillage.ViewModels;

namespace SoftwareVillage.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class ITandCybersecurityController : Controller
    {
        public readonly SoftwareVillageDbContext _context;
        public ITandCybersecurityController(SoftwareVillageDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
           
            List<ITandCybersecurity> itAndCybersecurities = _context.ITandCybersecurities.ToList();
            return View(itAndCybersecurities);
        }



        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ITandCybersecurity itandCybersecurity)
        {
            if (!ModelState.IsValid) return View();

            bool result = await _context.ITandCybersecurities.AnyAsync(p => p.BlogTitle.Trim().ToLower() == itandCybersecurity.BlogTitle.Trim().ToLower());

            if (result)
            {
                ModelState.AddModelError("Blogtitle", "Eyni adda Kurs artiq movcuddur...");
                return View();
            }
            await _context.ITandCybersecurities.AddAsync(itandCybersecurity);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }






        public async Task<IActionResult> Update(int Id)
        {
            if (Id == null || Id < 1)
            {
                return BadRequest();
            }

            ITandCybersecurity old = await _context.ITandCybersecurities.FirstOrDefaultAsync(o => o.Id == Id);
            if (old == null)
            {
                return NotFound();
            }

            return View(old);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int Id, ITandCybersecurity itandCybersecurity)
        {
            if (Id == null || Id < 1)
            {
                return BadRequest();
            }

            ITandCybersecurity old = await _context.ITandCybersecurities.FirstOrDefaultAsync(o => o.Id == Id);

            if (old == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View();
            }

            if (old.BlogTitle == itandCybersecurity.BlogTitle && old.BlogSubtitle == itandCybersecurity.BlogSubtitle && old.SignOfMoney == itandCybersecurity.SignOfMoney && old.Payment == itandCybersecurity.Payment && old.Time == itandCybersecurity.Time && old.Description1 == itandCybersecurity.Description1 && old.Description2 == itandCybersecurity.Description2 && old.Description3 == itandCybersecurity.Description3 && old.Description4 == itandCybersecurity.Description4 && old.Description5 == itandCybersecurity.Description5)
            {
                await Console.Out.WriteLineAsync("Hec bir deyisiklik etmediniz.");
                return RedirectToAction(nameof(Index));

            }

            bool result = await _context.ITandCybersecurities.AnyAsync(p => p.BlogTitle.Trim().ToLower() == itandCybersecurity.BlogTitle.Trim().ToLower() && p.Id != old.Id);
            if (result)
            {
                ModelState.AddModelError("BlogTitle", "Bu adda kurs basligi artiq var");
                return View(old);
            }

            old.BlogTitle = itandCybersecurity.BlogTitle;
            old.BlogSubtitle = itandCybersecurity.BlogSubtitle;
            old.SignOfMoney = itandCybersecurity.SignOfMoney;
            old.Payment = itandCybersecurity.Payment;
            old.Time = itandCybersecurity.Time;
            old.Description1 = itandCybersecurity.Description1;
            old.Description2 = itandCybersecurity.Description2;
            old.Description3 = itandCybersecurity.Description3;
            old.Description4 = itandCybersecurity.Description4;
            old.Description5 = itandCybersecurity.Description5;

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }




        public async Task<IActionResult> Delete(int? Id)
        {
            if (Id == null || Id < 1)
            {
                return BadRequest();
            }
            ITandCybersecurity itandCybersecurity = await _context.ITandCybersecurities.FirstOrDefaultAsync(o => o.Id == Id);
            if (itandCybersecurity == null) NotFound();

            _context.ITandCybersecurities.Remove(itandCybersecurity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }


    }
}
