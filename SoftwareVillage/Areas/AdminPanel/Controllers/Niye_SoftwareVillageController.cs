using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoftwareVillage.Data;
using SoftwareVillage.Models;


namespace SoftwareVillage.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class Niye_SoftwareVillageController : Controller
    {
        private readonly SoftwareVillageDbContext _context;
        private readonly IWebHostEnvironment _env;
        public Niye_SoftwareVillageController(SoftwareVillageDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }


        public IActionResult Index()
        {
            List<Niye_SoftwareVillage> niye_SoftwareVillages = _context.niye_SoftwareVillage.ToList();

            return View(niye_SoftwareVillages);
        }
        public IActionResult Create()
        {

            return View();
        }



        [HttpPost]
        public async Task<IActionResult> Create(Niye_SoftwareVillage niye_SoftwareVillage)
        {

            if (!ModelState.IsValid) return View();

            if (niye_SoftwareVillage == null)

            {
                ModelState.AddModelError("Photo", "Sekil Secilmeyib");
                return View();



            }

            if (!niye_SoftwareVillage.Photo.ContentType.Contains("image/"))
            {
                ModelState.AddModelError("Photo", "Tipi sehvdir");
                return View();

            }



            if (niye_SoftwareVillage.Photo.Length / 1024 > 200)
            {
                ModelState.AddModelError("Photo", "Olcu Odemir");
                return View();
            }

            var filename = Guid.NewGuid().ToString() + "_" + niye_SoftwareVillage.Photo.FileName;
            niye_SoftwareVillage.Image = filename;
            string path = Path.Combine(_env.WebRootPath, "assets/img", filename);
            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                await niye_SoftwareVillage.Photo.CopyToAsync(stream);
            }
            await _context.niye_SoftwareVillage.AddAsync(niye_SoftwareVillage);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }
        public async Task<IActionResult> Update(int id)
        {
            if (id == null || id < 1)
            {
                return BadRequest();

            }
            Niye_SoftwareVillage news = await _context.niye_SoftwareVillage.FirstOrDefaultAsync(n => n.Id == id);
            if (news == null)
            {
                return NotFound();
            }
            return View(news);
        }





        [HttpPost]
        public async Task<IActionResult> Update(Niye_SoftwareVillage niye_SoftwareVillage)
        {
            if (!ModelState.IsValid) return View();

            Niye_SoftwareVillage old = await _context.niye_SoftwareVillage.FirstOrDefaultAsync(o => o.Id == niye_SoftwareVillage.Id);
            if (old == null)
            {
                return NotFound();
            }


            if (niye_SoftwareVillage.Photo != null)
            {
                if (!niye_SoftwareVillage.Photo.ContentType.Contains("image/"))
                {
                    ModelState.AddModelError("Photo", "Sekil tipi duzgun deyil");
                    return View();
                }
                if (niye_SoftwareVillage.Photo.Length / 1024 > 200)
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
            var fileName = Guid.NewGuid().ToString() + "" + niye_SoftwareVillage.Photo.FileName;
            old.Image = fileName;

            string newpath = Path.Combine(_env.WebRootPath, "assets/img", fileName);
            using (FileStream stream = new FileStream(newpath, FileMode.Create))
            {
                await niye_SoftwareVillage.Photo.CopyToAsync(stream);
            }
           
            old.Title1 = niye_SoftwareVillage.Title1;
            old.Subtitle1 = niye_SoftwareVillage.Subtitle1;
            old.Title2 = niye_SoftwareVillage.Title2;
            old.Subtitle2 = niye_SoftwareVillage.Subtitle2;
            old.Title3 = niye_SoftwareVillage.Title3;
            old.Subtitle3 = niye_SoftwareVillage.Subtitle3;
            old.Title4 = niye_SoftwareVillage.Title4;
            old.Subtitle4 = niye_SoftwareVillage.Subtitle4;




            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (id == null || id < 1)
            {
                return BadRequest();
            }
            Niye_SoftwareVillage news = await _context.niye_SoftwareVillage.FirstOrDefaultAsync(n => n.Id == id);
            if (news == null)
            {
                return NotFound();
            }
            string path = Path.Combine(_env.WebRootPath + "img" + news.Image);
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
            _context.niye_SoftwareVillage.Remove(news);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }
    }
}




