using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoftwareVillage.Data;
using SoftwareVillage.Models;


namespace SoftwareVillage.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class Carousel_ProgrammingController : Controller
    {
        private readonly SoftwareVillageDbContext _context;
        private readonly IWebHostEnvironment _env;
        public Carousel_ProgrammingController(SoftwareVillageDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public IActionResult Index()
        {
            List<CarouselProgramming> carouselProgrammings = _context.carouselProgrammings.ToList();

            return View(carouselProgrammings);
        }
        public IActionResult Create()
        {

            return View();
        }



        [HttpPost]
        public async Task<IActionResult> Create(CarouselProgramming carouselProgramming)
        {

            if (!ModelState.IsValid) return View();

            if (carouselProgramming == null)

            {
                ModelState.AddModelError("Photo", "Sekil Secilmeyib");
                return View();

            }

            if (!carouselProgramming.Photo.ContentType.Contains("image/"))
            {
                ModelState.AddModelError("Photo", "Tipi sehvdir");
                return View();

            }



            if (carouselProgramming.Photo.Length / 1024 > 200)
            {
                ModelState.AddModelError("Photo", "Olcu Odemir");
                return View();
            }

            var filename = Guid.NewGuid().ToString() + "_" + carouselProgramming.Photo.FileName;
            carouselProgramming.Image = filename;
            string path = Path.Combine(_env.WebRootPath, "assets/img", filename);
            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                await carouselProgramming.Photo.CopyToAsync(stream);
            }
            await _context.carouselProgrammings.AddAsync(carouselProgramming);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }
        public async Task<IActionResult> Update(int id)
        {
            if (id == null || id < 1)
            {
                return BadRequest();

            }
            CarouselProgramming news = await _context.carouselProgrammings.FirstOrDefaultAsync(n => n.Id == id);
            if (news == null)
            {
                return NotFound();
            }
            return View(news);
        }





        [HttpPost]
        public async Task<IActionResult> Update(CarouselProgramming carouselProgramming)
        {
            if (!ModelState.IsValid) return View();

            CarouselProgramming old = await _context.carouselProgrammings.FirstOrDefaultAsync(o => o.Id == carouselProgramming.Id);
            if (old == null)
            {
                return NotFound();
            }


            if (carouselProgramming.Photo != null)
            {
                if (!carouselProgramming.Photo.ContentType.Contains("image/"))
                {
                    ModelState.AddModelError("Photo", "Sekil tipi duzgun deyil");
                    return View();
                }
                if (carouselProgramming.Photo.Length / 1024 > 200)
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
            var fileName = Guid.NewGuid().ToString() + "" + carouselProgramming.Photo.FileName;
            old.Image = fileName;

            string newpath = Path.Combine(_env.WebRootPath, "assets/img", fileName);
            using (FileStream stream = new FileStream(newpath, FileMode.Create))
            {
                await carouselProgramming.Photo.CopyToAsync(stream);
            }
            
            old.Title = carouselProgramming.Title;
            old.Subtitle = carouselProgramming.Subtitle;
            



            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (id == null || id < 1)
            {
                return BadRequest();
            }
            CarouselProgramming news = await _context.carouselProgrammings.FirstOrDefaultAsync(n => n.Id == id);
            if (news == null)
            {
                return NotFound();
            }
            string path = Path.Combine(_env.WebRootPath + "img" + news.Image);
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
            _context.carouselProgrammings.Remove(news);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }
    }
}



