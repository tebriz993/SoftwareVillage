using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoftwareVillage.Data;
using SoftwareVillage.Models;
using SoftwareVillage.ViewModels;


namespace SoftwareVillage.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class Carousel_ITandCybersecurityController : Controller
    {
        private readonly SoftwareVillageDbContext _context;
        private readonly IWebHostEnvironment _env;
        public Carousel_ITandCybersecurityController(SoftwareVillageDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public IActionResult Index()
        {
            List<Carousel_ITAndCybersecurity> carousel_ITAndCybersecurities = _context.carousel_ITAndCybersecurities.ToList();
            return View(carousel_ITAndCybersecurities);
        }
        public IActionResult Create()
        {

            return View();
        }



        [HttpPost]
        public async Task<IActionResult> Create(Carousel_ITAndCybersecurity carousel_ITAndCybersecurity)
        {

            if (!ModelState.IsValid) return View();

            if (carousel_ITAndCybersecurity == null)

            {
                ModelState.AddModelError("Photo", "Sekil Secilmeyib");
                return View();

            }

            if (!carousel_ITAndCybersecurity.Photo.ContentType.Contains("image/"))
            {
                ModelState.AddModelError("Photo", "Tipi sehvdir");
                return View();

            }



            if (carousel_ITAndCybersecurity.Photo.Length / 1024 > 200)
            {
                ModelState.AddModelError("Photo", "Olcu Odemir");
                return View();
            }

            var filename = Guid.NewGuid().ToString() + "_" + carousel_ITAndCybersecurity.Photo.FileName;
            carousel_ITAndCybersecurity.Image = filename;
            string path = Path.Combine(_env.WebRootPath, "assets/img", filename);
            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                await carousel_ITAndCybersecurity.Photo.CopyToAsync(stream);
            }
            await _context.carousel_ITAndCybersecurities.AddAsync(carousel_ITAndCybersecurity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }
        public async Task<IActionResult> Update(int id)
        {
            if (id == null || id < 1)
            {
                return BadRequest();

            }
            Carousel_ITAndCybersecurity news = await _context.carousel_ITAndCybersecurities.FirstOrDefaultAsync(n => n.Id == id);
            if (news == null)
            {
                return NotFound();
            }
            return View(news);
        }





        [HttpPost]
        public async Task<IActionResult> Update(Carousel_ITAndCybersecurity carousel_ITAndCybersecurity)
        {
            if (!ModelState.IsValid) return View();

            Carousel_ITAndCybersecurity old = await _context.carousel_ITAndCybersecurities.FirstOrDefaultAsync(o => o.Id == carousel_ITAndCybersecurity.Id);
            if (old == null)
            {
                return NotFound();
            }


            if (carousel_ITAndCybersecurity.Photo != null)
            {
                if (!carousel_ITAndCybersecurity.Photo.ContentType.Contains("image/"))
                {
                    ModelState.AddModelError("Photo", "Sekil tipi duzgun deyil");
                    return View();
                }
                if (carousel_ITAndCybersecurity.Photo.Length / 1024 > 200)
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
            var fileName = Guid.NewGuid().ToString() + "" + carousel_ITAndCybersecurity.Photo.FileName;
            old.Image = fileName;

            string newpath = Path.Combine(_env.WebRootPath, "assets/img", fileName);
            using (FileStream stream = new FileStream(newpath, FileMode.Create))
            {
                await carousel_ITAndCybersecurity.Photo.CopyToAsync(stream);
            }

            old.Title = carousel_ITAndCybersecurity.Title;
            old.Subtitle = carousel_ITAndCybersecurity.Subtitle;




            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (id == null || id < 1)
            {
                return BadRequest();
            }
            Carousel_ITAndCybersecurity news = await _context.carousel_ITAndCybersecurities.FirstOrDefaultAsync(n => n.Id == id);
            if (news == null)
            {
                return NotFound();
            }
            string path = Path.Combine(_env.WebRootPath + "img" + news.Image);
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
            _context.carousel_ITAndCybersecurities.Remove(news);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }
    }
}



