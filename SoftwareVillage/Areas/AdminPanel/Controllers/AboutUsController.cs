using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoftwareVillage.Data;
using SoftwareVillage.Models;


namespace SoftwareVillage.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class AboutUsController : Controller
    {
        private readonly SoftwareVillageDbContext _context;
        private readonly IWebHostEnvironment _env;
        public AboutUsController(SoftwareVillageDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }


        public IActionResult Index()
        {
            List<AkademiyaAboutUs> akademiyaAboutUs = _context.akademiyaAboutUs.ToList();

            return View(akademiyaAboutUs);
        }
        public IActionResult Create()
        {

            return View();
        }



        [HttpPost]
        public async Task<IActionResult> Create(AkademiyaAboutUs akademiyaAboutUs)
        {

            if (!ModelState.IsValid) return View();

            if (akademiyaAboutUs == null)

            {
                ModelState.AddModelError("Photo", "Sekil Secilmeyib");
                return View();



            }

            if (!akademiyaAboutUs.Photo.ContentType.Contains("image/"))
            {
                ModelState.AddModelError("Photo", "Tipi sehvdir");
                return View();

            }



            if (akademiyaAboutUs.Photo.Length / 1024 > 200)
            {
                ModelState.AddModelError("Photo", "Olcu Odemir");
                return View();
            }

            var filename = Guid.NewGuid().ToString() + "_" + akademiyaAboutUs.Photo.FileName;
            akademiyaAboutUs.MyImage = filename;
            string path = Path.Combine(_env.WebRootPath, "assets/img", filename);
            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                await akademiyaAboutUs.Photo.CopyToAsync(stream);
            }
            await _context.akademiyaAboutUs.AddAsync(akademiyaAboutUs);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }
        public async Task<IActionResult> Update(int id)
        {
            if (id == null || id < 1)
            {
                return BadRequest();

            }
            AkademiyaAboutUs news = await _context.akademiyaAboutUs.FirstOrDefaultAsync(n => n.Id == id);
            if (news == null)
            {
                return NotFound();
            }
            return View(news);
        }





        [HttpPost]
        public async Task<IActionResult> Update(AkademiyaAboutUs akademiyaAboutUs)
        {
            if (!ModelState.IsValid) return View();

            AkademiyaAboutUs old = await _context.akademiyaAboutUs.FirstOrDefaultAsync(o => o.Id == akademiyaAboutUs.Id);
            if (old == null)
            {
                return NotFound();
            }


            if (akademiyaAboutUs.Photo != null)
            {
                if (!akademiyaAboutUs.Photo.ContentType.Contains("image/"))
                {
                    ModelState.AddModelError("Photo", "Sekil tipi duzgun deyil");
                    return View();
                }
                if (akademiyaAboutUs.Photo.Length / 1024 > 200)
                {
                    ModelState.AddModelError("Photo", "Olcu duzgun deyil");
                    return View();
                }
                
                
            }
            
            
            string path = Path.Combine(_env.WebRootPath + "img" + old.MyImage);
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
            var fileName = Guid.NewGuid().ToString() + "" + akademiyaAboutUs.Photo.FileName;
            old.MyImage = fileName;

            string newpath = Path.Combine(_env.WebRootPath, "assets/img", fileName);
            using (FileStream stream = new FileStream(newpath, FileMode.Create))
            {
                await akademiyaAboutUs.Photo.CopyToAsync(stream);
            }
            old.AboutUs = akademiyaAboutUs.AboutUs;
            old.Title = akademiyaAboutUs.Title;
            old.Subtitle = akademiyaAboutUs.Subtitle;
            old.Special1 = akademiyaAboutUs.Special1;
            old.Special2 = akademiyaAboutUs.Special2;
            old.Special3 = akademiyaAboutUs.Special3;
            old.Special4 = akademiyaAboutUs.Special4;
            


            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (id == null || id < 1)
            {
                return BadRequest();
            }
            AkademiyaAboutUs news = await _context.akademiyaAboutUs.FirstOrDefaultAsync(n => n.Id == id);
            if (news == null)
            {
                return NotFound();
            }
            string path = Path.Combine(_env.WebRootPath + "img" + news.MyImage);
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
            _context.akademiyaAboutUs.Remove(news);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }
    }
}

          

           
