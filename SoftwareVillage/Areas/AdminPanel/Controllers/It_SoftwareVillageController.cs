using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoftwareVillage.Data;
using SoftwareVillage.Models;
using SoftwareVillage.ViewModels;


namespace SoftwareVillage.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class It_SoftwareVillageController : Controller
    {
        private readonly SoftwareVillageDbContext _context;
        private readonly IWebHostEnvironment _env;
        public It_SoftwareVillageController(SoftwareVillageDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public IActionResult Index()
        {
            List<It_SoftwareVillage> it_SoftwareVillages = _context.it_SoftwareVillages.ToList();

            return View(it_SoftwareVillages);
        }
        public IActionResult Create()
        {

            return View();
        }



        [HttpPost]
        public async Task<IActionResult> Create(It_SoftwareVillage it_SoftwareVillage)
        {

            if (!ModelState.IsValid) return View();

            if (it_SoftwareVillage == null)

            {
                ModelState.AddModelError("Photo", "Sekil Secilmeyib");
                return View();

            }

            if (!it_SoftwareVillage.Photo.ContentType.Contains("image/"))
            {
                ModelState.AddModelError("Photo", "Tipi sehvdir");
                return View();

            }


            if (it_SoftwareVillage.Photo.Length / 1024 > 200)
            {
                ModelState.AddModelError("Photo", "Olcu Odemir");
                return View();
            }

            var filename = Guid.NewGuid().ToString() + "_" + it_SoftwareVillage.Photo.FileName;
            it_SoftwareVillage.Image = filename;
            string path = Path.Combine(_env.WebRootPath, "assets/img", filename);
            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                await it_SoftwareVillage.Photo.CopyToAsync(stream);
            }
            await _context.it_SoftwareVillages.AddAsync(it_SoftwareVillage);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }
        public async Task<IActionResult> Update(int id)
        {
            if (id == null || id < 1)
            {
                return BadRequest();

            }
            It_SoftwareVillage news = await _context.it_SoftwareVillages.FirstOrDefaultAsync(n => n.Id == id);
            if (news == null)
            {
                return NotFound();
            }
            return View(news);
        }





        [HttpPost]
        public async Task<IActionResult> Update(It_SoftwareVillage it_SoftwareVillage)
        {
            if (!ModelState.IsValid) return View();

            It_SoftwareVillage old = await _context.it_SoftwareVillages.FirstOrDefaultAsync(o => o.Id == it_SoftwareVillage.Id);
            if (old == null)
            {
                return NotFound();
            }


            if (it_SoftwareVillage.Photo != null)
            {
                if (!it_SoftwareVillage.Photo.ContentType.Contains("image/"))
                {
                    ModelState.AddModelError("Photo", "Sekil tipi duzgun deyil");
                    return View();
                }
                if (it_SoftwareVillage.Photo.Length / 1024 > 200)
                {
                    ModelState.AddModelError("Photo", "Olcu duzgun deyil");
                    return View();
                }


            }


            string path = Path.Combine(_env.WebRootPath + "img" + old.Image);
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
            var fileName = Guid.NewGuid().ToString() + "" + it_SoftwareVillage.Photo.FileName;
            old.Image = fileName;

            string newpath = Path.Combine(_env.WebRootPath, "assets/img", fileName);
            using (FileStream stream = new FileStream(newpath, FileMode.Create))
            {
                await it_SoftwareVillage.Photo.CopyToAsync(stream);
            }

            old.BigTitle = it_SoftwareVillage.BigTitle;
            old.LittleTitle = it_SoftwareVillage.LittleTitle;




            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (id == null || id < 1)
            {
                return BadRequest();
            }
            It_SoftwareVillage news = await _context.it_SoftwareVillages.FirstOrDefaultAsync(n => n.Id == id);
            if (news == null)
            {
                return NotFound();
            }
            string path = Path.Combine(_env.WebRootPath + "img" + news.Image);
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
            _context.it_SoftwareVillages.Remove(news);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }
    }
}



