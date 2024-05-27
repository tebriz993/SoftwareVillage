using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoftwareVillage.Data;
using SoftwareVillage.Models;
using SoftwareVillage.ViewModels;


namespace SoftwareVillage.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class Carousel_DataScienceController : Controller
    {
        private readonly SoftwareVillageDbContext _context;
        private readonly IWebHostEnvironment _env;
        public Carousel_DataScienceController(SoftwareVillageDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public IActionResult Index()
        {
            List<Carousel_DataScience> carousel_DataSciences = _context.carousel_DataSciences.ToList();
            return View(carousel_DataSciences);
        }
        public IActionResult Create()
        {

            return View();
        }



        [HttpPost]
        public async Task<IActionResult> Create(Carousel_DataScience carousel_DataScience)
        {

            if (!ModelState.IsValid) return View();

            if (carousel_DataScience == null)

            {
                ModelState.AddModelError("Photo", "Sekil Secilmeyib");
                return View();

            }

            if (!carousel_DataScience.Photo.ContentType.Contains("image/"))
            {
                ModelState.AddModelError("Photo", "Tipi sehvdir");
                return View();

            }


            if (carousel_DataScience.Photo.Length / 1024 > 200)
            {
                ModelState.AddModelError("Photo", "Olcu Odemir");
                return View();
            }

            var filename = Guid.NewGuid().ToString() + "_" + carousel_DataScience.Photo.FileName;
            carousel_DataScience.Image = filename;
            string path = Path.Combine(_env.WebRootPath, "assets/img", filename);
            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                await carousel_DataScience.Photo.CopyToAsync(stream);
            }
            await _context.carousel_DataSciences.AddAsync(carousel_DataScience);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }
        public async Task<IActionResult> Update(int id)
        {
            if (id == null || id < 1)
            {
                return BadRequest();

            }
            Carousel_DataScience news = await _context.carousel_DataSciences.FirstOrDefaultAsync(n => n.Id == id);
            if (news == null)
            {
                return NotFound();
            }
            return View(news);
        }





        [HttpPost]
        public async Task<IActionResult> Update(Carousel_DataScience carousel_DataScience)
        {
            if (!ModelState.IsValid) return View();

            Carousel_DataScience old = await _context.carousel_DataSciences.FirstOrDefaultAsync(o => o.Id == carousel_DataScience.Id);
            if (old == null)
            {
                return NotFound();
            }


            if (carousel_DataScience.Photo != null)
            {
                if (!carousel_DataScience.Photo.ContentType.Contains("image/"))
                {
                    ModelState.AddModelError("Photo", "Sekil tipi duzgun deyil");
                    return View();
                }
                if (carousel_DataScience.Photo.Length / 1024 > 200)
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
            var fileName = Guid.NewGuid().ToString() + "" + carousel_DataScience.Photo.FileName;
            old.Image = fileName;

            string newpath = Path.Combine(_env.WebRootPath, "assets/img", fileName);
            using (FileStream stream = new FileStream(newpath, FileMode.Create))
            {
                await carousel_DataScience.Photo.CopyToAsync(stream);
            }

            old.Title = carousel_DataScience.Title;
            old.Subtitle = carousel_DataScience.Subtitle;




            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (id == null || id < 1)
            {
                return BadRequest();
            }
            Carousel_DataScience news = await _context.carousel_DataSciences.FirstOrDefaultAsync(n => n.Id == id);
            if (news == null)
            {
                return NotFound();
            }
            string path = Path.Combine(_env.WebRootPath + "img" + news.Image);
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
            _context.carousel_DataSciences.Remove(news);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }
    }
}



