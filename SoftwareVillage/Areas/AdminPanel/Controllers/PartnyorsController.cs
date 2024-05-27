using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoftwareVillage.Data;
using SoftwareVillage.Models;


namespace SoftwareVillage.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class PartnyorsController : Controller
    {
        private readonly SoftwareVillageDbContext _context;
        private readonly IWebHostEnvironment _env;
        public PartnyorsController(SoftwareVillageDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public IActionResult Index()
        {
            List<Partnyors> partnyors = _context.Partnyors.ToList();

            return View(partnyors);
        }
        public IActionResult Create()
        {

            return View();
        }



        [HttpPost]
        public async Task<IActionResult> Create(Partnyors partnyors)
        {

            if (!ModelState.IsValid) return View();

            if (partnyors == null)

            {
                ModelState.AddModelError("Photo", "Sekil Secilmeyib");
                return View();

            }

            if (!partnyors.Photo.ContentType.Contains("image/"))
            {
                ModelState.AddModelError("Photo", "Tipi sehvdir");
                return View();

            }



            if (partnyors.Photo.Length / 1024 > 200)
            {
                ModelState.AddModelError("Photo", "Olcu Odemir");
                return View();
            }

            var filename = Guid.NewGuid().ToString() + "_" + partnyors.Photo.FileName;
            partnyors.Image = filename;
            string path = Path.Combine(_env.WebRootPath, "assets/img", filename);
            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                await partnyors.Photo.CopyToAsync(stream);
            }
            await _context.Partnyors.AddAsync(partnyors);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }
        public async Task<IActionResult> Update(int id)
        {
            if (id == null || id < 1)
            {
                return BadRequest();

            }
            Partnyors news = await _context.Partnyors.FirstOrDefaultAsync(n => n.Id == id);
            if (news == null)
            {
                return NotFound();
            }
            return View(news);
        }





        [HttpPost]
        public async Task<IActionResult> Update(Partnyors partnyors)
        {
            if (!ModelState.IsValid) return View();

            Partnyors old = await _context.Partnyors.FirstOrDefaultAsync(o => o.Id == partnyors.Id);
            if (old == null)
            {
                return NotFound();
            }


            if (partnyors.Photo != null)
            {
                if (!partnyors.Photo.ContentType.Contains("image/"))
                {
                    ModelState.AddModelError("Photo", "Sekil tipi duzgun deyil");
                    return View();
                }
                if (partnyors.Photo.Length / 1024 > 200)
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
            var fileName = Guid.NewGuid().ToString() + "" + partnyors.Photo.FileName;
            old.Image = fileName;

            string newpath = Path.Combine(_env.WebRootPath, "assets/img", fileName);
            using (FileStream stream = new FileStream(newpath, FileMode.Create))
            {
                await partnyors.Photo.CopyToAsync(stream);
            }



            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (id == null || id < 1)
            {
                return BadRequest();
            }
            Partnyors news = await _context.Partnyors.FirstOrDefaultAsync(n => n.Id == id);
            if (news == null)
            {
                return NotFound();
            }
            string path = Path.Combine(_env.WebRootPath + "img" + news.Image);
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
            _context.Partnyors.Remove(news);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }
    }
}



