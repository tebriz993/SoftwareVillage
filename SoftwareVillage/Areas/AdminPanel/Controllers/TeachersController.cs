using SoftwareVillage.Data;
using SoftwareVillage.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Security.Cryptography;

namespace SoftwareVillage.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class TeachersController : Controller
    {
        public readonly SoftwareVillageDbContext _context;
        private readonly IWebHostEnvironment _env;

        public TeachersController(SoftwareVillageDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;

        }

        public async Task<IActionResult> Index()
        {
            List<AkademiyaTeachers> teacher = await _context.akademiyaTeachers
                .Include(s => s.SocialMedia)
                .Include(p=>p.Profession)
                .ToListAsync();

            return View(teacher);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.SocialMedias = await _context.socialMediaOfTeachers.ToListAsync();
            ViewBag.Professions = await _context.professions.ToListAsync();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AkademiyaTeachers akademiyaTeachers)
        {
            bool socialMediaExists = await _context.socialMediaOfTeachers.AnyAsync(p => p.Id == akademiyaTeachers.SocialMediaId);
            bool professionExists = await _context.professions.AnyAsync(p => p.Id == akademiyaTeachers.ProfessionId);

            if (!socialMediaExists)
            {
                ModelState.AddModelError("SocialMediaId", "Belə sosial media mövcud deyil");
                ViewBag.SocialMedias = await _context.socialMediaOfTeachers.ToListAsync();
                ViewBag.Professions = await _context.professions.ToListAsync();
                return View(akademiyaTeachers);
            }
            if (!professionExists)
            {
                ModelState.AddModelError("ProfessionId", "Belə vəzifə mövcud deyil");
                ViewBag.SocialMedias = await _context.socialMediaOfTeachers.ToListAsync();
                ViewBag.Professions = await _context.professions.ToListAsync();
                return View(akademiyaTeachers);
            }

            if (akademiyaTeachers.Photo == null)
            {
                ModelState.AddModelError("Photo", "Şəkil seçilməyib");
                return View(akademiyaTeachers);
            }

            if (!akademiyaTeachers.Photo.ContentType.Contains("image/"))
            {
                ModelState.AddModelError("Photo", "Tipi səhvdir");
                return View(akademiyaTeachers);
            }

            if (akademiyaTeachers.Photo.Length / 1024 > 200)
            {
                ModelState.AddModelError("Photo", "Ölçü uyğun deyil");
                return View(akademiyaTeachers);
            }

            var filename = Guid.NewGuid().ToString() + "_" + akademiyaTeachers.Photo.FileName;
            akademiyaTeachers.Image = filename;
            string path = Path.Combine(_env.WebRootPath, "assets/img", filename);
            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                await akademiyaTeachers.Photo.CopyToAsync(stream);
            }

            await _context.akademiyaTeachers.AddAsync(akademiyaTeachers);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Update(int Id)
        {
            if (Id == null || Id < 1)
            {
                return BadRequest();
            }

            AkademiyaTeachers exit = await _context.akademiyaTeachers.FirstOrDefaultAsync(p => p.Id == Id);
            if (exit == null)
            {
                return NotFound();
            }
            ViewBag.SocialMedias = await _context.socialMediaOfTeachers.ToListAsync();
            ViewBag.Professions = await _context.professions.ToListAsync();


            return View(exit);

        }

        [HttpPost]
        public async Task<IActionResult> Update(int Id, AkademiyaTeachers akademiyaTeachers)
        {
            if (Id == null || Id < 1)
            {
                return BadRequest();
            }

            AkademiyaTeachers exit = await _context.akademiyaTeachers.FirstOrDefaultAsync(p => p.Id == Id);
            if (exit == null)
            {
                return NotFound();
            }
            //bool result = await _context.studentsFeedbacks.AnyAsync(p => p.Id == akademiyaTeachers.SocialMediaId && p.Id == akademiyaTeachers.ProfessionId);
            bool result = await _context.studentsFeedbacks.AnyAsync(p => p.Id == akademiyaTeachers.SocialMediaId);
            bool result1 = await _context.studentsFeedbacks.AnyAsync(p => p.Id == akademiyaTeachers.ProfessionId);

            if (!result)
            {
                ModelState.AddModelError("SocialMediaId", "Bele vezife yoxdur");
                ViewBag.AkademiyaTeachers = await _context.studentsFeedbacks.ToListAsync();
                return View();
            }
            if (!result1)
            {
                ModelState.AddModelError("ProfessionId", "Bele vezife yoxdur");
                ViewBag.AkademiyaTeachers = await _context.studentsFeedbacks.ToListAsync();
                return View();
            }
            if (akademiyaTeachers.Photo != null)
            {
                if (!akademiyaTeachers.Photo.ContentType.Contains("image/"))
                {
                    ModelState.AddModelError("Photo", "Sekil tipi duzgun deyil");
                    return View();
                }
                if (akademiyaTeachers.Photo.Length / 1024 > 200)
                {
                    ModelState.AddModelError("Photo", "Olcu duzgun deyil");
                    return View();
                }
            }


            string path = Path.Combine(_env.WebRootPath + "img" + exit.Image);
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
            var fileName = Guid.NewGuid().ToString() + "" + akademiyaTeachers.Photo.FileName;
            exit.Image = fileName;

            string newpath = Path.Combine(_env.WebRootPath, "assets/img", fileName);
            using (FileStream stream = new FileStream(newpath, FileMode.Create))
            {
                await akademiyaTeachers.Photo.CopyToAsync(stream);
            }

            exit.SocialMediaId = akademiyaTeachers.SocialMediaId;
            exit.FullName = akademiyaTeachers.FullName;
            exit.ProfessionId = akademiyaTeachers.ProfessionId;

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> Delete(int Id)
        {
            if (!ModelState.IsValid) return View();

            AkademiyaTeachers teacher = await _context.akademiyaTeachers.FirstOrDefaultAsync(p => p.Id == Id);

            if (teacher == null) return NotFound();
            string path = Path.Combine(_env.WebRootPath + "img" + teacher.Image);
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }

            _context.akademiyaTeachers.Remove(teacher);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
